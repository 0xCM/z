//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct WinCmd
    {
        [Op]
        public static CmdLine dir(FolderPath src)
            => string.Format("cmd /c dir {0} /s/b", src.Format(PathSeparator.BS));

        [Op]
        public static CmdLine script(FilePath src)
            => string.Format("cmd /c {0}", src.Format(PathSeparator.BS));
    }
}