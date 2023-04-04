//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using System.Linq;

    [ApiHost]
    public unsafe partial class EcmaReader : IEcmaReader
    {
        public static unsafe EcmaReader create(MemoryAddress @base, ByteSize size)
            => new (new PEReader(@base.Pointer<byte>(), size).GetMetadata());

        public static EcmaReader create(EcmaFile src)
            => new EcmaReader(src);

        [Op]
        public static EcmaReader create(Assembly src)
            => new EcmaReader(src);

        [Op]
        public static EcmaReader create(MetadataReader src)
            => new EcmaReader(src);

        [Op]
        public static EcmaReader create(MemorySeg src)
            => new EcmaReader(src);

        [Op]
        public static EcmaReader create(PEMemoryBlock src)
            => new EcmaReader(src);

        [MethodImpl(Inline), Op]
        public static Address32 offset(MetadataReader reader, UserStringHandle handle)
            => (Address32)reader.GetHeapOffset(handle);

        public static AssemblyFiles assemblies(IWfChannel channel, IDbArchive src)
        {
            var dst = bag<AssemblyFile>();
            var counter = 0u;
            var running = channel.Running($"Searching {src.Root} for assemlies");
            iter(src.Enumerate(true, FileKind.Dll, FileKind.Exe), path => {
                try
                {
                    using var ecma = Ecma.file(path);
                    var reader = ecma.EcmaReader(); 
                    var def = reader.ReadAssemblyDef();                   
                    var kind = FileModuleKind.Managed;
                    if(path.Is(FileKind.Exe)) 
                        kind |= FileModuleKind.Exe;
                    else
                        kind |= FileModuleKind.Dll;
                    dst.Add(new AssemblyFile(path, def.GetAssemblyName()));
                    if(math.mod(inc(ref counter),1000) == 0)
                        channel.Babble($"Found {counter} assemblies");
                }
                catch(Exception e)
                {
                    channel.Error(e);
                }
            }
            );
            channel.Ran(running, $"Found {counter} assemblies");
            return dst.Array();
        }
        
        public static IEnumerable<EcmaTables.AssemblyRefRow> refs(IEnumerable<AssemblyFile> src)
        {
            foreach(var file in src.AsParallel())
            {
                using var ecma = Ecma.file(file.Path);
                var reader = Ecma.reader(ecma);
                var refs = reader.ReadAssemblyRefRows().Storage;
                foreach(var r in refs)
                    yield return r;                
            }
        }

        public ByteSize CalcTableSize(TableIndex table)
            => MD.GetTableRowCount(table)*MD.GetTableRowSize(table);

        [Op]
        public static uint describe(ReadOnlySpan<Assembly> src, Span<EcmaModuleInfo> dst)
        {
            var count = (uint)min(src.Length, dst.Length);
            for(var i=0; i<count; i++)
                seek(dst,i) = Ecma.describe(skip(src,i));
            return count;
        }

        readonly MetadataReader MD;

        public ref readonly MetadataReader MetadataReader
        {            
            [MethodImpl(Inline)]
            get => ref MD;
        }

        readonly MemorySeg Segment;

        GenericSignatureTypeProvider GSTP = new GenericSignatureTypeProvider();

        [MethodImpl(Inline)]
        public EcmaReader(Assembly src)
        {
            Segment = ClrAssembly.metadata(src);
            MD = new MetadataReader(Segment.BaseAddress.Pointer<byte>(), Segment.Size);
        }

        [MethodImpl(Inline)]
        public EcmaReader(MemorySeg src)
        {
            Segment = src;
            MD = new MetadataReader(Segment.BaseAddress.Pointer<byte>(), Segment.Size);            
        }

        [MethodImpl(Inline)]
        public EcmaReader(PEMemoryBlock src)
        {
            Segment = MemorySegs.define(src.Pointer, src.Length);
            MD = new MetadataReader(Segment.BaseAddress.Pointer<byte>(), Segment.Size);        
        }

        [MethodImpl(Inline)]
        public EcmaReader(MetadataReader src)
        {
            Segment = MemorySegs.define(src.MetadataPointer, src.MetadataLength);
            MD = src;
        }

        [MethodImpl(Inline)]
        public EcmaReader(EcmaFile src)
        {
            Segment = MemorySegs.define(src.MdReader.MetadataPointer, src.MdReader.MetadataLength);
            MD = src.MdReader;            
        }

        public ReadOnlySpan<EcmaConstInfo> ReadConstants(ref uint counter)
        {
            var reader = MD;
            var count = ConstantCount();
            var dst = sys.span<EcmaConstInfo>(count);
            for(var i=1u; i<=count; i++)
            {
                var k = MetadataTokens.ConstantHandle((int)i);
                var entry = reader.GetConstant(k);
                var parent = (EcmaToken)MD.GetToken(entry.Parent);
                var blob = reader.GetBlobBytes(entry.Value);
                ref var target = ref seek(dst, i - 1u);
                target.Seq = sys.inc(ref counter);
                target.Token = k;
                target.Parent = parent;
                target.DataType = entry.TypeCode;
                target.Content = blob;
            }
            return dst;
        }

        [MethodImpl(Inline), Op]
        public int ConstantCount()
            => MD.GetTableRowCount(TableIndex.Constant);

        AssemblyKey _AssemblyKey;

        AssemblyName _AssemblyName;

        [MethodImpl(Inline), Op]
        public string String(EcmaStringKey index)
            => MD.GetString(index);

        [MethodImpl(Inline), Op]
        public Guid Guid(EcmaGuidKey index)
            => MD.GetGuid(index);

        [MethodImpl(Inline), Op]
        public ReadOnlySpan<byte> Blob(EcmaBlobKey index)
            => MD.GetBlobBytes(index);

        [MethodImpl(Inline), Op]
        public byte[] BlobArray(EcmaBlobKey index)
            => MD.GetBlobBytes(index);

        [MethodImpl(Inline)]
        public MetadataMemory Memory(AssemblyKey assembly)
            => Ecma.memory(Segment, assembly);

        public EcmaMvid Mvid()
            => Guid(MD.GetModuleDefinition().Mvid);

        public AssemblyName AssemblyName()
        {
            if(_AssemblyName == null)
                _AssemblyName = MD.GetAssemblyDefinition().GetAssemblyName();
            return _AssemblyName;
        }

        Hash128 _ContentHash;

        Hash128 ContentHash()
        {
            if(_ContentHash.Hi == 0 && _ContentHash.Lo == 0)
            {
                _ContentHash = md5(Segment.View);
            }
            return _ContentHash;
        }

        public AssemblyKey AssemblyKey()
        {
            if(_AssemblyKey.IsEmpty)
                _AssemblyKey = new AssemblyKey(AssemblyName().SimpleName(), AssemblyName().Version, ReadTargetFramework(), Mvid(), ContentHash());
            return _AssemblyKey;            
        }

        public MemoryAddress BaseAddress
        {
            [MethodImpl(Inline)]
            get => Segment.BaseAddress;
        }

        public ByteSize MetaSize
        {
            [MethodImpl(Inline)]
            get => Segment.Size;
        }

        public ReadOnlySpan<byte> MetaBytes
        {
            [MethodImpl(Inline)]
            get => MemorySegs.view<byte>(Segment);
        }    
    }
}