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
    }
}