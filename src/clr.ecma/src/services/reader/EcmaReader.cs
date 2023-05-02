//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static Ecma;

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

        public static IEnumerable<AssemblyRefRow> refs(IEnumerable<AssemblyFile> src)
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

        [MethodImpl(Inline), Op]
        public BinaryCode Blob(BlobHandle src)
            => MD.GetBlobBytes(src);

        [Op]
        public string String(UserStringHandle handle)
            => MD.GetUserString(handle);

        [Op]
        public string String(DocumentNameBlobHandle handle)
            => MD.GetString(handle);

        [Op]
        public string String(StringHandle handle)
            => MD.GetString(handle);
                        
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

        // [MethodImpl(Inline)]
        // public MetadataMemory Memory(AssemblyKey assembly)
        //     => Ecma.memory(Segment, assembly);

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
                _AssemblyKey = new AssemblyKey(AssemblyName().GetVersionedName(), AssemblyName().Version, ReadTargetFramework(), Mvid());
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