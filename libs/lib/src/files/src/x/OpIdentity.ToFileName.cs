//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        [Op]
        public static FS.FileName ToFileName(this OpIdentity src, FS.FileExt ext)
            => FS.file(LegalIdentityBuilder.file(src), ext);

        [Op]
        public static FS.FileName ToFileName(this OpIdentity src, string suffix, FS.FileExt ext)
            => FS.file(LegalIdentityBuilder.file(src) + suffix, ext);
    }
}