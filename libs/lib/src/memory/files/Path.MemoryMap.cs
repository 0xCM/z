//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        public static MemoryFile MemoryMap(this FS.FilePath src, bool stream = false)
            => MemoryFiles.map(src, stream);
    }
}