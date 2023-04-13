//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;


    public partial class Tooling : WfAppCmd<Tooling>
    {
        [Op]
        public static CmdLine pwsh(string spec)
            => $"pwsh.exe {spec}";

        public static CmdLine pwsh(FilePath src, string args)
            => string.Format("pwsh.exe {0} {1}", src.Format(PathSeparator.BS), args);

        public static CmdLine pwsh(FilePath src)
            => string.Format("pwsh.exe {0}", src.Format(PathSeparator.BS));        

        public static CmdLine cmdline(params CmdArg[] args)
            => new CmdLine(args);

        public static CmdLine cmdline(params object[] args)
            => new CmdLine(args.Select(x => x?.ToString() ?? EmptyString));

        [Op]
        public static CmdLine cmd<T>(T src)
            => $"cmd.exe /c {src}";

        [Op]
        public static CmdLine cmd(string spec)
            => string.Format("cmd.exe /c {0}", spec);

        [Op]
        public static CmdLine cmd(FilePath src, CmdArgs args)
            => string.Format("cmd.exe /c {0} {1}", args.Format());

        [Op]
        public static CmdLine cmd(FilePath src, string args)
            => string.Format("cmd.exe /c {0} {1}", src.Format(PathSeparator.BS), args);

        [Op]
        public static CmdLine cmd(FilePath src)
            => string.Format("cmd.exe /c {0}", src.Format(PathSeparator.BS));

        [Op]
        public static CmdLine cmd(FilePath path, CmdKind kind)
        {
            return kind switch{
                CmdKind.Cmd => cmd(path),
                CmdKind.Tool => cmd(path),
                CmdKind.Pwsh => pwsh(path),
                _ => Z0.CmdLine.Empty
            };
        }

        [Op]
        public static CmdLine cmd(FilePath path, CmdKind kind, string args)
        {
            return kind switch{
                CmdKind.Cmd => cmd(path, args),
                CmdKind.Tool => cmd(path, args),
                CmdKind.Pwsh => pwsh(path, args),
                _ => Z0.CmdLine.Empty
            };
        }

        public static CmdLine cmdline(FilePath src)
        {
            if(src.Is(FileKind.Cmd))
                return cmd(src);
            else if(src.Is(FileKind.Ps1))
                return pwsh(src);
            else
                return sys.@throw<CmdLine>();
        }

        [CmdOp("tool/docs")]
        void ToolDocs(CmdArgs args)
            => iter(LoadDocs(arg(args,0).Value), doc => Channel.Write(doc));

        public static ToolCmd command(FilePath tool, params ToolCmdArg[] args)
            => new (tool,args, Env.cd(), EnvVars.Empty);

        public static ToolCmd command(FilePath tool, ToolCmdArgs args)
            => new (tool, args, Env.cd(), EnvVars.Empty);

        public static ToolCmd command(FilePath tool, ToolCmdArgs args, FolderPath work)
            => new (tool,args, work, EnvVars.Empty);

        public static ToolCmd command(FilePath tool, ToolCmdArgs args, FolderPath work, params EnvVar[] vars)
            => new (tool,args, work, vars);

        public static ToolCmdArg flag(ArgPrefixKind prefix, string name)
            => new ToolCmdArg{
                Prefix = prefix,
                Name = name,
            };

        public static ToolCmdArg flag(string src)
        {
            var prefix = ArgPrefixKind.None;
            var name = EmptyString;
            var dst = ToolCmdArg.Empty;
            var i = text.index(src,"--");
            if(i >= 0)
            {
                prefix = ArgPrefixKind.Dashes;
                name = text.right(src, i + "--".Length - 1);                
            }
            else
            {
                i = text.index(src,"-");
                if(i >=0)
                {
                    prefix = ArgPrefixKind.Dash;
                    name = text.right(src, i);
                }
                else
                {

                    i = text.index(src, "/");
                    if(i >=0)
                    {
                        prefix = ArgPrefixKind.FSlash;
                        name = text.right(src, i);
                    }
                }
            }

            if(nonempty(name))
            {   
                dst = flag(prefix,name);
            }

            return dst;                           
        }
    
        public static ToolCmdArg option(ArgPrefixKind prefix, string name, ArgSepKind sep, ArgValue value)
            => new ToolCmdArg{
                Prefix = prefix,
                Name = name,
                Sep = sep,
                Value = value
            };

        public static ToolCmdArg arg(string name, ArgValue value)
            => new ToolCmdArg{
                Name = name,
                Value = value
            };
        
        public static ToolCmdSpec spec(FolderPath? work = null, params EnvVar[] vars)
            => new (FilePath.Empty, CmdArgs.Empty, work ?? Env.cd(), vars, null, null);

        public static ToolCmdSpec spec(FolderPath work, params EnvVar[] vars)
            => new(FilePath.Empty, CmdArgs.Empty, work, vars, null, null);

        public static ToolCmdSpec spec(FolderPath work, EnvVars vars, Action<Process> created)
            => new(FilePath.Empty, CmdArgs.Empty, work, vars, created, null);

        public static ToolCmdSpec spec(FolderPath work, EnvVars vars, Action<Process> created, Action<int> exit)
            => new(FilePath.Empty, CmdArgs.Empty, work, vars, created, exit);

        public static ToolCmdSpec spec()
            => new(FilePath.Empty, CmdArgs.Empty, Env.cd(), EnvVars.Empty, null, null);

        public static ToolCmdSpec spec(FilePath tool, CmdArgs args)
            => new(tool, args,Env.cd(), EnvVars.Empty, null, null);

        public static IToolStreamWriter writer(FilePath src)
            => new ToolStreamWriter(src);
         
        public static Task<ExecToken> shell(IWfChannel channel, CmdArgs args)
        {
            ExecToken Run()
            {
                var profile = args[0].Value;
                var cwd = args.Count > 1 ? FS.dir(args[1]) : Env.cd();
                return shell(channel, profile, cwd);  
            }
            return sys.start(Run);
        }

        [Op]
        public static ExecToken shell(IWfChannel channel, string profile, FolderPath cwd)
        {
            var flow = channel.Running($"Launching {profile} shell");
            var psi = new ProcessStartInfo
            {
                FileName = @"d:\tools\wt\wt.exe",
                CreateNoWindow = false,
                UseShellExecute = false,
                Arguments = $"nt --profile {profile} -d {cwd}",
                RedirectStandardError = false,
                RedirectStandardOutput = false,
                RedirectStandardInput = false,
            };
            var process = sys.process(psi);
            var result = process.Start();
            var token = ExecToken.Empty;
            if(!result)
                channel.Error("Process creation failed");
            else
                token = channel.Ran(flow, $"Launched {profile} shell: {process.Id}");
            return token;
        }

        [MethodImpl(Inline), Op]
        public static ToolCmdLine cmdline(FilePath tool, params string[] src)
            => new ToolCmdLine(tool, src);

        public T Tool<T>()
            where T : IToolService, new()
                => ToolServices.Service<T>(Wf);

        public FilePath ConfigScript(Tool tool)
            => Home(tool).ConfigScript(ApiAtomic.config, FileKind.Cmd);

        public FilePath Script(Tool tool, string name, FileKind kind)
            => Home(tool).Script(name, kind);

        public IDbArchive Docs(Tool tool)
            => Home(tool).Docs();

        public IToolWs Home(Tool tool)
            => new ToolWs(tool, ToolBase.Sources(tool.Name).Root);

        public IDbArchive ToolBase
            => AppDb.Toolbase();

        public FilePath ScriptPath(Tool tool, string name, FileKind kind)
            => Home(tool).Script(name, kind);

        public SettingLookup LoadCfg(Tool tool)
            => Z0.Settings.lookup(Home(tool).Script("tools", FileKind.Cfg).ReadNumberedLines(), Chars.Eq);

        public FilePath ToolPath(FolderPath root, Tool tool)
            => root + FS.file(tool.Name, FileKind.Exe);

        public Index<string> LoadDocs(string tool)
        {
            var src = Docs(tool);
            var dst = bag<string>();
            iter(src.Files(), file => dst.Add(file.ReadText()));
            return dst.ToIndex();
        }
    }
}