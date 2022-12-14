//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed record class MsiFile : Package<MsiFile>
    {
        public MsiFile(FileUri src)
            : base(src, PackageKind.Msi)
        {

        }        
    }
}