//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Windows;

    using static sys;

    public class Dev : WfSvc<Dev>
    {
        public Task<ExecToken> VsCode<T>(T target)
            => ProcExec.start(Channel, Cmd.args("code.exe", $"{target}"));

        public Task<ExecToken> DevEnv<T>(T target)
            => ProcExec.start(Channel, Cmd.args("devenv.exe", $"{target}"));

        public void EmitMachineEnv()
            => Env.emit(Emitter, EnvVarKind.Machine, AppDb.EnvSpecs().Root);

        public void EmitUserEnv()
            => Env.emit(Emitter, EnvVarKind.User, AppDb.EnvSpecs().Root);

        public void EmitProcessEnv()
            => Env.emit(Emitter, EnvVarKind.Process, AppDb.EnvSpecs().Root);
    }
}