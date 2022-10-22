//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class Dev : WfSvc<Dev>
    {
        public Task<ExecToken> VsCode<T>(T target)
            => ProcessControl.start(Channel, Cmd.args("code.exe", $"{target}"));

        public Task<ExecToken> DevEnv<T>(T target)
            => ProcessControl.start(Channel, Cmd.args("devenv.exe", $"{target}"));

        public Task<ExecToken> Redirect(CmdArgs args)
        {
            ExecToken Run()
            {
                var running = Channel.Running("cmd/redirect");
                var outAPath = AppDb.AppData().Path("a", FileKind.Log);
                var outBPath = AppDb.AppData().Path("b", FileKind.Log);
                using var outA = outAPath.Utf8Writer();
                using var outB = outBPath.Utf8Writer();

                void OnA(string msg)
                {
                    Channel.Row(msg, FlairKind.Data);
                    outA.WriteLine(msg);
                }

                void OnB(string msg)
                {
                    Channel.Row(msg, FlairKind.StatusData);
                    outB.WriteLine(msg);
                }

                ProcessControl.start(Channel, new SysIO(OnA,OnB), args).Wait();
                return Channel.Ran(running, outA);
            }
            return sys.start(Run);
        }
    }
}