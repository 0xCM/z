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
    }
}