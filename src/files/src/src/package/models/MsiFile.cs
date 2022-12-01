//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class MsiFile : FilePack<MsiFile>
    {
        public MsiFile(FileUri src)
            : base(src, PackageKind.Msi)
        {

        }

        public override FileKind FileKind => FileKind.Msi;
    }
}