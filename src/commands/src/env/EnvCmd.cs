//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static Env;

    sealed class EnvCmd : ApiService<EnvCmd>
    {    
        static void emit(IWfChannel channel, ApiCmdCatalog src, FilePath dst)
        {
            var data = src.Values;
            iter(data, x => channel.Row(x.Uri.Name));
            Tables.emit(channel, data, dst);
        }

        [CmdOp("api/commands")]
        void EmitCommands()
            => emit(Channel, Cmd.catalog(), ShellData.Path(ExecutingPart.Name.Format() + ".commands", FileKind.Csv));

        [CmdOp("api/version")]
        void ApiVersion()
            => Channel.Write(typeof(Parts.Commands).Assembly.AssemblyVersion());

        [CmdOp("api/script")]
        void RunAppScript(CmdArgs args)
            => Cmd.start(Channel, args);

        [CmdOp("env/tools")]
        void EnvTools()
            => Z0.EnvTools.emit(Channel, Z0.EnvTools.Service.Known, ShellData);

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
            => reports(Channel, ShellData);

        [CmdOp("env/machine")]
        void EmitMachineEnv()
            => report(Channel, EnvVarKind.Machine, ShellData);

        [CmdOp("env/user")]
        void EmitUserEnv()
            => report(Channel, EnvVarKind.User, ShellData);

        [CmdOp("env/process")]
        void EmitProcessEnv()
            => report(Channel, EnvVarKind.Process, ShellData);

        [CmdOp("env/pid")]
        void ProcessId()
            => Channel.Write(Env.pid());

        [CmdOp("env/cpucore")]
        void ShowCurrentCore()
            => Emitter.Write(Env.cpucore());

        [CmdOp("env/include")]
        void EnvInclude()
            => Env.paths(Channel, EnvPathKind.Include, ShellData);

        [CmdOp("env/path")]
        void EnvPath()
            => Env.paths(Channel, EnvPathKind.FileSystem, ShellData);

        [CmdOp("env/lib")]
        void EnvLib()
            => Env.paths(Channel, EnvPathKind.Lib, ShellData);

        [CmdOp("env/tid")]
        void ShowThread()
            => Channel.Row(Env.tid());

        [CmdOp("env/root")]
        void SlnRoot(CmdArgs args)
        {
            if(args.Count == 1)
                Environment.CurrentDirectory = args.First.Value;
            Channel.Row(Env.cd());
        }

        [CmdOp("env/cfg")]
        void LoadCfg(CmdArgs args)
        {
            var src = args.Count != 0 ? FS.dir(args.First) : Env.cd();
            iter(src.Files(FileKind.Cfg), file => Channel.Row(Env.cfg(file).Format()));    
        }        

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
            => iter(Environment.GetCommandLineArgs(), arg => Channel.Write(arg));

        [CmdOp("cmd")]
        void Redirect(CmdArgs args)
            => CmdRunner.redirect(Channel, args);

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

        [CmdOp("develop")]
        void Develop(CmdArgs args)
        {
            var cd = Env.cd();
            var launcher = cd + FS.file("develop", FileKind.Cmd);
            if(launcher.Exists)
                CmdRunner.start(Channel, Cmd.args(launcher)); 
            else
            {
                var workspaces = cd.Files(FS.ext("code-workspace"));
                if(workspaces.IsNonEmpty)
                    DevTools.vscode(Channel, cd + workspaces[0].FileName);
                else
                    DevTools.vscode(Channel, cd); 
            }
        }

        [CmdOp("devenv")]
        void DevEnv(CmdArgs args)
            => DevTools.devenv(Channel, args[0].Value);

        [CmdOp("vscode")]
        void VsCode(CmdArgs args)
            => DevTools.vscode(Channel, args[0].Value);
    }
}