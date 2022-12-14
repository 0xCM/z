//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct FS
    {
        [MethodImpl(Inline), Op]
        public static FileName file(PathPart name, FileExt ext)
            => new FileName(name, ext);

        [Op]
        public static FileName file(PartId part, FileExt ext)
            => file(part.Format(), ext);

        [Op]
        public static FileName file(PartId part, FileKind kind)
            => file(part.Format(), kind.Ext());

        [MethodImpl(Inline), Op]
        public static FileName file(Identifier name, string type)
            => new FileName(name.Content, FS.ext(type));

        public static FileName file(string name, FileKind kind)
            => new FileName(name, kind.Ext());

        [Op]
        public static FileName file(PathPart name, FileExt x1, FileExt x2)
            => new FileName(name, FS.combine(x1,x2));


        [MethodImpl(Inline), Op]
        public static FileName file(string name)
            => new FileName(name);

        [MethodImpl(Inline), Op]
        public static FileName file(@string name, string x)
            => new FileName(name.Format(), ext(x));
    }
}