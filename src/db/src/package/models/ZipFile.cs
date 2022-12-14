//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed record class ZipFile : Package<ZipFile>
    {
        public ZipFile(FileUri src)
            : base(src, PackageKind.Zip)
        {

        }
    }
}