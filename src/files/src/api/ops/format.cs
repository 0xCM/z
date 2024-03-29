//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct FS
    {
        public static string format(in RelativeFilePath src, PathSeparator sep, bool quote = false)
        {
            var result = string.Format("{0}" + $"{(char)sep}" + "{1}", src.Location.Format(sep), src.File);
            return quote ? RP.enquote(result) : result;
        }
    }
}