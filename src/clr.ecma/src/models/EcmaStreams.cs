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

}