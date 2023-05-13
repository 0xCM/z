//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct FS
    {
        public static string[] segments(FilePath src)
            => text.split(src.Format(PathSeparator.FS).Replace("//", "/"), Chars.FSlash);

        /// <summary>
        /// Returns a contiguous sequence of source paths that are contained by <paramref name='subdir'/>
        /// </summary>
        /// <param name="src">The paths to search</param>
        /// <param name="subdir">The root folder</param>
        public static ReadOnlySpan<FilePath> segment(ReadOnlySpan<FilePath> src, FolderPath subdir)
        {
            var count = src.Length;
            var j0 = 0u;
            var counter = 0u;
            for(var i=0u; i<count; i++)
            {
                ref readonly var path = ref skip(src,i);
                if(path.FolderPath == subdir)
                {
                    if(j0 == 0)
                        j0 = i;

                    counter++;
                }
                else
                {
                    if(j0 != 0)
                        break;
                }
            }
            if(j0 != 0)
                return slice(src,j0,counter);
            else
                return default;
        }
    }
}