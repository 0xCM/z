//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class EcmaStreams
    {
        public static EcmaTableStream tables(MetadataRoot root)
            => new EcmaTableStream(root.BaseAddress + root.TableStreamHeader.Offset, root.TableStreamHeader.Size);

        public static EcmaBlobStream blobs(MetadataRoot root)
            => new EcmaBlobStream(root.BaseAddress + root.BlobStreamHeader.Offset, root.BlobStreamHeader.Size);

        public static EcmaBlobStream guids(MetadataRoot root)
            => new EcmaBlobStream(root.BaseAddress + root.BlobStreamHeader.Offset, root.BlobStreamHeader.Size);

        public static EcmaStringStream strings(MetadataRoot root, bool user)
            => new EcmaStringStream(
                root.BaseAddress + (user ? root.UserStringStreamHeader.Offset : root.StringStreamHeader.Offset), 
                user ? root.UserStringStreamHeader.Size : root.StringStreamHeader.Size, 
                user);
    }

    public abstract record class EcmaStream
    {        
        public readonly MemoryAddress BaseAddress;

        public readonly ByteSize Size;

        public readonly EcmaStreamKind Kind;

        public EcmaStream(MemoryAddress @base, ByteSize size, EcmaStreamKind kind)
        {
            BaseAddress = @base;
            Size = size;
            Kind = kind;
        }
    }

    public record class EcmaTableStream : EcmaStream
    {
        public EcmaTableStream(MemoryAddress @base, ByteSize size)
            : base(@base,size,EcmaStreamKind.CompressedTable)
        {

        }
    }

    public record class EcmaStringStream : EcmaStream
    {
        public EcmaStringStream(MemoryAddress @base, ByteSize size, bool user)
            : base(@base,size,user ? EcmaStreamKind.UserString : EcmaStreamKind.String)
        {

        }
    }

    public record class EcmaBlobStream : EcmaStream
    {
        public EcmaBlobStream(MemoryAddress @base, ByteSize size)
            : base(@base,size,EcmaStreamKind.Blob)
        {

        }
    }

    public record class EcmaGuidStream : EcmaStream
    {
        public EcmaGuidStream(MemoryAddress @base, ByteSize size)
            : base(@base,size,EcmaStreamKind.Blob)
        {

        }
    }    
}