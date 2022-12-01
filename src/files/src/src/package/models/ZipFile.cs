//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO.Compression;

    public sealed class ZipFile : FilePack<ZipFile>
    {
        public ZipFile(FileUri src)
            : base(src, PackageKind.Zip)
        {

        }

        public override FileKind FileKind => FileKind.Zip;

    }
}