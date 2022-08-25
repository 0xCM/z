//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;

    partial class XFs
    {
        /// <summary>
        /// Opens a <see cref='FileStream'/>
        /// </summary>
        /// <param name="path">The target file path</param>
        /// <param name="mode"></param>
        /// <param name="access"></param>
        /// <param name="share"></param>
        public static FileStream Stream(this FilePath path,
            FileMode mode = FileMode.OpenOrCreate,
            FileAccess access = FileAccess.ReadWrite,
            FileShare share = FileShare.ReadWrite)
                => FS.stream(path, mode, access, share);
    }
}