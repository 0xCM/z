//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Tools
{
    public class Python : WfSvc<Python>
    {
        static IDbArchive PythonTools => AppSettings.Setting("PythonRoot").Folder().DbArchive();

        static FilePath PythonPath => PythonTools.Path("python",FileKind.Exe);

        public ExecToken RunScript(FilePath src)
        {
            var token = Tooling.start(Channel, PythonPath, Cmd.args(src)).Result;
            return token;
        }

        public ExecToken RunScript(FilePath src, CmdArgs args)
            => Tooling.start(Channel, PythonPath, Cmd.args(src) + args).Result;

        public ExecToken RunCommand(CmdArgs args)
            => Tooling.start(Channel, PythonPath, args).Result;
    }
}