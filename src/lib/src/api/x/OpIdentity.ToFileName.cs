//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        [Op]
        public static FileName ToFileName(this _OpIdentity src, FileExt ext)
            => FS.file(LegalIdentityBuilder.file(src), ext);

        [Op]
        public static FileName ToFileName(this _OpIdentity src, string suffix, FileExt ext)
            => FS.file(LegalIdentityBuilder.file(src) + suffix, ext);
    }
}