//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    public sealed class ApiCmdServer : ApiServer<ApiCmdServer>
    {
        IDbArchive ShellData => Env.cd().DbArchive().Scoped(".data");

        [CmdOp("commands")]
        void EmitCommands()
            => ApiCmd.emit(Channel, ApiCmd.catalog(), ShellData.Path(ExecutingPart.Name.Format() + ".commands", FileKind.Csv));

        [CmdOp("env/stack")]
        void Stack()
            => Channel.Write(Environment.StackTrace);

        [CmdOp("env/pagesize")]
        void PageSize()
            => Channel.Write(Environment.SystemPageSize);

        [CmdOp("env/ticks")]
        void Ticks()
            => Channel.Write(Environment.TickCount64);

        [CmdOp("env/reports")]
        void EmitEnv(CmdArgs args)
            => Env.reports(Channel, ShellData);

        [CmdOp("env/machine")]
        void EmitMachineEnv()
            => Env.report(Channel, EnvVarKind.Machine, ShellData);

        [CmdOp("env/user")]
        void EmitUserEnv()
            => Env.report(Channel, EnvVarKind.User, ShellData);

        [CmdOp("env/process")]
        void EmitProcessEnv()
            => Env.report(Channel, EnvVarKind.Process, ShellData);

        [CmdOp("env/include")]
        void EnvInclude()
            => Channel.Row(Env.paths(EnvTokens.INCLUDE, EnvVarKind.Process).Delimit(Chars.NL));

        [CmdOp("env/path")]
        void EnvPath()
            => Channel.Row(Env.paths(EnvTokens.PATH, EnvVarKind.Process).Delimit(Chars.NL));

        [CmdOp("env/lib")]
        void EnvLib()
            => Channel.Row(Env.paths(EnvTokens.LIB, EnvVarKind.Process).Delimit(Chars.NL));

        [CmdOp("cd")]
        void Cd(CmdArgs args)
            => Channel.Row(Env.cd(args));

        [CmdOp("dir")]
        void Dir(CmdArgs args)
        {
            var root = Env.cd();
            if(args.Count != 0)
            root = FS.dir(args[0]);
            var folders = root.Folders();
            iter(folders, f => Channel.Row(f));
            var files = root.Files(false);
            iter(files, f => Channel.Row(((FileUri)f)));
        }        
    }
}