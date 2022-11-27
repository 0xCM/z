//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Windows;

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

        [CmdOp("env/pid")]
        void ProcessId()
            => Write(Environment.ProcessId);

        [CmdOp("env/cpucore")]
        void ShowCurrentCore()
            => Emitter.Write(string.Format("Cpu:{0}", Kernel32.GetCurrentProcessorNumber()));

        [CmdOp("env/include")]
        void EnvInclude()
            => Env.paths(Channel, EnvPathKind.Include, ShellData);

        [CmdOp("env/path")]
        void EnvPath()
            => Env.paths(Channel, EnvPathKind.FileSystem, ShellData);

        [CmdOp("env/lib")]
        void EnvLib()
            => Env.paths(Channel, EnvPathKind.Lib, ShellData);

        [CmdOp("env/tools")]
        void EnvTools(CmdArgs args)
            => Env.tools(Channel, ShellData);

        [CmdOp("env/thread")]
        void ShowThread()
            => Channel.Row(string.Format("ThreadId:{0}", Kernel32.GetCurrentThreadId()));

        [CmdOp("env/id")]
        void EvId(CmdArgs args)
        {
            var id = Env.EnvId;
            var msg = EmptyString;
            if(args.IsNonEmpty)
            {
                Env.EnvId = args.First.Value;
                if(id.IsNonEmpty)
                    msg = $"{id} -> {Env.EnvId}";
                else
                    msg = $"{Env.EnvId}";
            }
            else
            {
                if(id.IsNonEmpty)
                    msg = id;
            }
            if(nonempty(msg))
                Channel.Write(msg);            
        }

        [CmdOp("env/args")]
        void CmdlLineArgs()
            => iter(Environment.GetCommandLineArgs(), arg => Write(arg));

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

        [CmdOp("symlink")]
        void Link(CmdArgs args)
        {
            var src = FS.dir(arg(args,0).Value);
            var dst = FS.dir(arg(args,1).Value);
            var result = FS.symlink(src,dst,true);
            if(result)
                Channel.Status($"symlink:{src} -> {dst}");
            else
                Channel.Error(result.Message);
        }
    }
}