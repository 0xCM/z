//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;

    partial struct FS
    {
        /// <summary>
        /// Opens a <see cref='FileStream'/>
        /// </summary>
        /// <param name="src">The file path</param>
        /// <param name="mode">The stream mode</param>
        /// <param name="access">The stream access spec</param>
        /// <param name="share">Sharing options</param>
        [MethodImpl(Inline), Op]
        public static FileStream stream(FilePath src, 
            FileMode mode = FileMode.OpenOrCreate,
            FileAccess access = FileAccess.Write, 
            FileShare share = FileShare.Read) 
                => new FileStream(src.CreateParentIfMissing().Name, mode, access, share);
    }
}