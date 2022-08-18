//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct FS
    {
        /// <summary>
        /// Returns true if a path-identified file is a managed module of some sort; otherwise, false
        /// </summary>
        /// <param name="src">The source path</param>
        [Op]
        public static bool managed(FilePath src)
            => name(src, out var _);

        /// <summary>
        /// Returns true if a path-identified file is a managed module of some sort; otherwise, false
        /// </summary>
        /// <param name="src">The source path</param>
        [Op]
        public static bool managed(FilePath src, out AssemblyName assembly)
            => name(src, out assembly);

        /// <summary>
        /// Searches the source for managed modules
        /// </summary>
        /// <param name="src">The directory to search to search</param>
        /// <param name="dst">The buffer to populate</param>
        /// <param name="recurse">Specifies whether subdirectories should be searched</param>
        [Op]
        public static Files managed(FolderPath src, bool recurse = false, bool dll = true, bool exe = true)
        {
            var dst = Files.Empty;
            if(dll && exe)
                dst = files(src, recurse, Dll, Exe).Array().Where(managed);
            else if(!exe && dll)
                dst = files(src, recurse, Dll).Array().Where(managed);
            else if(exe && !dll)
                dst = files(src, recurse, Exe).Array().Where(managed);
            return dst;
        }
    }
}