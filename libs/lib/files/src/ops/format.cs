//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct FS
    {
        public static string format(FolderPaths src, char sep = Chars.Semicolon)
        {
            var dst = text.emitter();
            var count = src.Count;
            for(var i=0; i<count; i++)
            {
                dst.Append(src[i].Format(PathSeparator.BS));
                if(i != count - 1)
                    dst.Append(sep);
            }
            return dst.Emit();
        }

        public static string format(in RelativeFilePath src, PathSeparator sep, bool quote = false)
        {
            var result = string.Format("{0}" + $"{(char)sep}" + "{1}", src.Location.Format(sep), src.File);
            return quote ? RP.enquote(result) : result;
        }
    }
}