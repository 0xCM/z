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
        static readonly GenericSigTypeProvider _GSTP = new ();

        static readonly DisassemblingTypeProvider _DTP = new ();

        public static unsafe EcmaReader create(MemoryAddress @base, ByteSize size)
            => new (new PEReader(@base.Pointer<byte>(), size).GetMetadata());

        public static EcmaReader create(EcmaFile src)
            => new EcmaReader(src);

        [Op]
        public static EcmaReader create(Assembly src)
            => new (src);

        [Op]
        public static EcmaReader create(MetadataReader src)
            => new (src);

        [Op]
        public static EcmaReader create(MemorySegment src)
            => new (src);

        [Op]
        public static EcmaReader create(PEMemoryBlock src)
            => new (src);

        [MethodImpl(Inline), Op]
        public static Address32 offset(MetadataReader reader, UserStringHandle handle)
            => (Address32)reader.GetHeapOffset(handle);

        public static IEnumerable<AssemblyRefRow> refs(IEnumerable<AssemblyFile> src)
        {
            foreach(var file in src.AsParallel())
            {
                using var ecma = Ecma.file(file.Path);
                var reader = Ecma.reader(ecma);
                var refs = reader.ReadAssemblyRefRows();
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

        readonly MemorySegment Segment;

        [MethodImpl(Inline)]
        public EcmaReader(Assembly src)
        {
            Segment = ClrAssembly.metadata(src);
            MD = new MetadataReader(Segment.BaseAddress.Pointer<byte>(), Segment.Size);
        }

        [MethodImpl(Inline)]
        public EcmaReader(MemorySegment src)
        {
            Segment = src;
            MD = new MetadataReader(Segment.BaseAddress.Pointer<byte>(), Segment.Size);            
        }

        [MethodImpl(Inline)]
        public EcmaReader(PEMemoryBlock src)
        {
            Segment = new(src.Pointer, src.Length);
            MD = new MetadataReader(Segment.BaseAddress.Pointer<byte>(), Segment.Size);        
        }

        [MethodImpl(Inline)]
        public EcmaReader(MetadataReader src)
        {
            Segment = new(src.MetadataPointer, src.MetadataLength);
            MD = src;
        }

        [MethodImpl(Inline)]
        public EcmaReader(EcmaFile src)
        {
            Segment = new(src.MdReader.MetadataPointer, src.MdReader.MetadataLength);
            MD = src.MdReader;            
        }

        [MethodImpl(Inline), Op]
        public BinaryCode Blob(BlobHandle src)
            => MD.GetBlobBytes(src);

        public object? Constant(ConstantHandle handle)
        {
            var @const = MD.GetConstant(handle);            
            var bytes = MD.GetBlobBytes(@const.Value);
            var view = @readonly(bytes);
            var dst = default(object);
            switch(@const.TypeCode)
            {
                case ConstantTypeCode.Boolean:
                    dst = @bool(view);
                break;   
                case ConstantTypeCode.Char:
                    dst = c16(first(view));
                break;
                case ConstantTypeCode.SByte:
                    dst = i8(view);
                break;
                case ConstantTypeCode.Byte:
                    dst = u8(view);
                break;
                case ConstantTypeCode.Int16:
                    dst = i16(first(view));
                break;
                case ConstantTypeCode.UInt16:
                    dst = u16(view);
                break;
                case ConstantTypeCode.Int32:
                    dst = i32(view);
                break;
                case ConstantTypeCode.UInt32:
                    dst = u32(view);
                break;
                case ConstantTypeCode.Int64:
                    dst = i64(view);
                break;
                case ConstantTypeCode.UInt64:
                    dst = u64(view);
                break;
                case ConstantTypeCode.Single:
                    dst = f32(view);
                break;
                case ConstantTypeCode.Double:
                    dst = f64(view);
                break;
                case ConstantTypeCode.String:
                    dst = text.utf8(view);
                break;
            }

            return dst;                        
        }

        [Op]
        public string String(UserStringHandle handle)
            => MD.GetUserString(handle);

        [Op]
        public string String(DocumentNameBlobHandle handle)
            => MD.GetString(handle);

        [Op]
        public string String(StringHandle handle)
            => MD.GetString(handle);
        
        [MethodImpl(Inline), Op]
        public int ConstantCount()
            => MD.GetTableRowCount(TableIndex.Constant);

        AssemblyKey _AssemblyKey;

        AssemblyName _AssemblyName;

        [MethodImpl(Inline), Op]
        public bool HashGenericParameters(TypeDefinitionHandle src)
            => MD.GetTypeDefinition(src).GetGenericParameters().Count != 0;

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