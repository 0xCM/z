//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public static class XFiles
    {
        public static FileExt Ext(this FileKind src)
            => FileKinds.ext(src);

        public static string Format(this FileKind src)
            => FileKinds.format(src);

        public static FileKind FileKind(this FileExt src)
            => FileKinds.kind(src);

        public static FileKind FileKind(this FileName src)
            => FileKinds.kind(src);

        public static FileKind FileKind(this FilePath src)
            => FileKinds.kind(src);

        public static string SrcId(this FilePath src, params FileKind[] kinds)
            => src.FileName.SrcId(kinds);

        public static string SrcId(this FileName src, params FileKind[] kinds)
        {
            var file = src.Format();
            var count = kinds.Length;
            var id = EmptyString;
            for(var i=0; i<count; i++)
            {
                ref readonly var kind = ref skip(kinds,i);
                var ext = kind.Ext();
                var j = text.index(file, "." + ext);
                if(j >0)
                {
                    id = text.left(file,j);
                    break;
                }
            }
            return id;
        }
    }
}