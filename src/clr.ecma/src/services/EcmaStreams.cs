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
        {
            var @base = root.BaseAddress + root.TableStreamHeader.Offset;
            var size = root.TableStreamHeader.Size;
            var dst =  new EcmaTableStream(@base, root.TableStreamHeader.Size);
            var reader = MemoryReaders.reader(@base,size);
            dst.Reserved1 = reader.Read<uint>();
            dst.MajorVersion = reader.Read<byte>();
            dst.MinorVersion = reader.Read<byte>();
            dst.HeapSizes = reader.Read<byte>();
            dst.Reserved2 = reader.Read<byte>();
            dst.Present = reader.Read<EcmaTableMask>();
            dst.Sorted = reader.Read<ulong>();
            dst.TableCount = (byte)bits.pop((ulong)dst.Present);
            var counts = alloc<uint>(dst.TableCount);
            for(var i=0; i<dst.TableCount; i++)
            {
                counts[i] = reader.Read<uint>();
            }
            dst.RowCounts = counts;
            return dst;
        }

        public static EcmaBlobStream blobs(MetadataRoot root)
            => new EcmaBlobStream(root.BaseAddress + root.BlobStreamHeader.Offset, root.BlobStreamHeader.Size);

        public static EcmaGuidStream guids(MetadataRoot root)
            => new EcmaGuidStream(root.BaseAddress + root.GuidStreamHeader.Offset, root.GuidStreamHeader.Size);

        public static EcmaStringStream strings(MetadataRoot root, bool user)
            => new EcmaStringStream(
                root.BaseAddress + (user ? root.UserStringStreamHeader.Offset : root.StringStreamHeader.Offset), 
                user ? root.UserStringStreamHeader.Size : root.StringStreamHeader.Size, 
                user);
    }
}