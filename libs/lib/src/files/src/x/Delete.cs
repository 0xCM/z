//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;

    using static Algs;

    partial class XTend
    {
        /// <summary>
        /// Deletes the file if it exists
        /// </summary>
        /// <param name="src">The path to the file</param>
        [Op]
        public static FS.FilePath Delete(this FS.FilePath src)
            => FS.delete(src);

        /// <summary>
        /// Consigns the folder and its contents to oblivion
        /// </summary>
        /// <param name="recursive">How sure are you?</param>
        public static Option<int> Delete(this FS.FolderPath src, bool recursive = true)
        {
            try
            {
                if(Directory.Exists(src.Name))
                    Directory.Delete(src.Name, recursive);
                return 0;
            }
            catch(Exception e)
            {
                Console.Error.WriteLine($"{e}");
                return Option.none<int>();
            }
        }

        public static void Delete(this FS.FolderPath[] paths)
            => iter(paths, path => path.Delete(true));

        public static void Delete(this IEnumerable<FS.FolderPath> paths)
            => iter(paths, path => path.Delete(true));
    }
}