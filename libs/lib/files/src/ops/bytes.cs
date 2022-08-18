//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct FS
    {
        /// <summary>
        /// Reads the full content of a file into a byte array
        /// </summary>
        /// <param name="src">The file path</param>
        [Op]
        public static byte[] bytes(FS.FilePath src)
            => src.Exists ? File.ReadAllBytes(src.Name) : sys.empty<byte>();
    }
}