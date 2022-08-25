//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class WinCmdShell : Interpreter<WinCmdShell>
    {
        protected override FilePath ExePath
            => FS.file("cmd", FS.Exe).ToPath();

        public void echo(string msg)
            => Submit(string.Format("{0} {1}", nameof(echo), msg));
    }
}