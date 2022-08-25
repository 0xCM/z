//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;
    using static Arrays;
    using static Spans;

    using S = ToolSettings;

    public class Tooling : WfSvc<Tooling>
    {
        const byte FieldCount = ToolProfile.FieldCount;

        public static SettingLookup lookup(FilePath src, char sep = Chars.Eq)
            => Settings.lookup(src, sep);

        public static string format<T,C>(C src)
            where C : IToolCmd,new()
            where T : ITool, new()
        {
            var dst = text.emitter();
            
            return dst.Emit();
        }

        public static async Task<int> start(ToolCmdSpec cmd, CmdContext context, Action<string> status, Action<string> error)
        {
            var info = new ProcessStartInfo
            {
                FileName = cmd.Tool.Format(),
                Arguments = cmd.Format(),
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                RedirectStandardInput = true
            };

            var process = new Process {StartInfo = info};

            if (!context.WorkingDir.IsNonEmpty)
                process.StartInfo.WorkingDirectory = context.WorkingDir.Name;

            iter(context.EnvVars, v => process.StartInfo.Environment.Add(v.Name, v.Value));
            process.OutputDataReceived += (s,d) => status(d.Data ?? EmptyString);
            process.ErrorDataReceived += (s,d) => error(d.Data ?? EmptyString);
            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            return await wait(process);

            static async Task<int> wait(Process process)
            {
                return await Task.Run(() => {
                    process.WaitForExit();
                    return Task.FromResult(process.ExitCode);
                });
            }
        }

        public static ToolSettings settings(FilePath src)
        {
            var data = Settings.env(src);
            var dst = new ToolSettings();
            var setting = EmptyString;
            if(data.Find(nameof(S.ToolId), out setting))
                dst.ToolId = setting;
            if(data.Find(nameof(S.Group), out setting))
                dst.Group = setting;
            if(data.Find(nameof(S.ToolEnv), out setting))
                dst.ToolEnv = FS.uri(setting);
            if(data.Find(nameof(S.InstallBase), out setting))
                dst.InstallBase = FS.dir(setting);
            if(data.Find(nameof(S.ToolHome), out setting))
                dst.ToolHome = FS.dir(setting);
            if(data.Find(nameof(S.ToolLogs), out setting))
                dst.ToolLogs = FS.dir(setting);
            if(data.Find(nameof(S.ToolDocs), out setting))
                dst.ToolDocs = FS.dir(setting);
            if(data.Find(nameof(S.ToolScripts), out setting))
                dst.ToolScripts = FS.dir(setting);
            return dst;
        }

        [Op]
        public static void render(ToolCmdArgs src, ITextBuffer dst)
        {
            var count = src.Count;
            for(var i=0u; i<count; i++)
            {
                dst.Append(src[i].Format());
                if(i != count - 1)
                    dst.Append(Space);
            }
        }

        public static string serialize(IToolCmd src)
        {
            var count = src.Args.Count;
            var buffer = text.buffer();
            buffer.AppendFormat("{0}{1}", src.Tool, Chars.LParen);
            for(var i=0; i<count; i++)
            {
                ref readonly var arg = ref src.Args[i];
                buffer.AppendFormat(RpOps.Assign, arg.Name, arg.Value);
                if(i != count - 1)
                    buffer.Append(", ");
            }

            buffer.Append(Chars.RParen);
            return buffer.Emit();
        }

        [Op, Closures(UInt64k)]
        public static ToolCmdSpec cmdspec<T>(Tool tool, in T spec)
            where T : struct
        {
            var t = typeof(T);
            var fields = Clr.fields(t);
            var count = fields.Length;
            var reflected = sys.alloc<ClrFieldValue>(count);
            ClrFields.values(spec, fields, reflected);
            var buffer = sys.alloc<ToolCmdArg>(count);
            var target = span(buffer);
            var source = @readonly(reflected);
            for(var i=0u; i<count; i++)
            {
                ref readonly var fv = ref skip(source,i);
                seek(target,i) = new ToolCmdArg(fv.Field.Name, fv.Value?.ToString() ?? EmptyString);
            }
            return new ToolCmdSpec(tool, CmdTypes.identify(t), buffer);
        }

        public static ToolCmdArgs cmdargs<T>(T src)
            where T : struct, IToolCmd
        {
            var fields = typeof(T).DeclaredInstanceFields();
            return fields.Select(f => new ToolCmdArg(f.Name, f.GetValue(src)?.ToString() ?? EmptyString));
        }
     
        public static ToolScript script(FilePath script, CmdVars vars)
            => new ToolScript(script, vars);

        public static Tool tool(CmdArgs args, byte index = 0)
            => arg(args,index).Value;

        public FilePath ConfigScript(Tool tool)
            => Home(tool).ConfigScript(ApiAtomic.config, FileKind.Cmd);

        public FilePath Script(Tool tool, string name, FileKind kind)
            => Home(tool).Script(name, kind);
        public IDbArchive Docs(Tool tool)
            => Home(tool).Docs();

        [MethodImpl(Inline), Op]
        public static ToolCmdLine cmdline(IToolWs ws, Actor tool, CmdModifier modifier, params string[] src)
            => new ToolCmdLine(tool, modifier, new CmdLine(src));

        [MethodImpl(Inline), Op]
        public static ToolCmdLine cmdline(IToolWs ws, Actor tool, params string[] src)
            => new ToolCmdLine(tool, new CmdLine(src));

        public IToolWs Home(Tool tool)
            => new ToolWs(tool, ToolBase.Sources(tool.Name).Root);

        public IDbArchive ToolBase
            => AppDb.Toolbase();

        public FilePath ScriptPath(Actor tool, string name, FileKind kind)
            => Home(tool).Script(name, kind);

        public Outcome Run(IToolWs tool, string name, FilePath src, FS.FolderPath dst)
        {
            var cmd = new CmdLine(tool.Script(name, FileKind.Cmd).Format(PathSeparator.BS));
            var vars = WsCmdVars.create();
            vars.DstDir = dst;
            vars.SrcDir = src.FolderPath;
            vars.SrcFile = src.FileName;
            var result = OmniScript.Run(cmd, vars.ToCmdVars(), out var response);
            if(result)
            {
               var items = CmdResponse.parse(response);
               iter(items, item => Write(item));
            }
            return result;
        }

        public SettingLookup LoadEnv(Tool tool)
        {
            var path = Home(tool).Script("tools", FileKind.Env);
            return Settings.parse(path.ReadNumberedLines(), Chars.Colon);
        }

        void LoadProfiles(FilePath src, Lookup<Actor,ToolProfile> dst)
        {
            var content = src.ReadUnicode();
            var result = TextGrids.parse(content, out var grid);
            if(result)
            {
                if(grid.ColCount != FieldCount)
                    Error(Tables.FieldCountMismatch.Format(FieldCount, grid.ColCount));
                else
                {
                    var count = grid.RowCount;
                    for(var i=0; i<count; i++)
                    {
                        result = parse(grid[i], out ToolProfile profile);
                        if(result)
                            dst.Include(profile.Id, profile);
                        else
                            break;
                    }
                }
            }
        }

        public SettingLookup LoadEnv()
        {
            var path =  AppDb.Toolbase().Path(FS.file("tools", FileKind.Env));
            return Settings.parse(path.ReadNumberedLines(), Chars.Eq);
        }

        public ConstLookup<Actor,ToolProfile> InferProfiles(FS.FolderPath src)
        {
            var @base = FS.FolderPath.Empty;
            var members = Index<Actor>.Empty;
            var config = src + FS.file("toolset", FS.Settings);
            if(!config.Exists)
            {
                Error(FS.missing(config));
                return dict<Actor,ToolProfile>();
            }

            using var reader = config.Utf8LineReader();
            while(reader.Next(out var line))
            {
                ref readonly var content = ref line.Content;
                var i = text.index(content, Chars.Colon);
                if(i >=0)
                {
                    var name = text.left(content,i);
                    var value = text.right(content,i);
                    if(name == "InstallBase")
                    {
                        var root = FS.dir(value);
                        if(root.Exists)
                            @base = root;
                    }
                }
            }

            return LoadProfileLookup(src);
        }

        public FilePath ToolPath(FS.FolderPath root, Tool tool)
        {
            if(LoadProfileLookup(root).Find(tool, out var profile))
                return profile.Path;
            else
                return FilePath.Empty;
        }

        public SettingLookup Setup(Tool tool)
        {
            var script = ConfigScript(tool);
            var result = OmniScript.Run(script, out _);
            return LoadEnv(tool);
        }

        public Outcome RunScript(Actor tool, string name)
        {
            var path = Script(tool, name, FileKind.Cmd);
            if(!path.Exists)
                return (false, FS.missing(path));
            else
                return OmniScript.Run(path, out var _);
        }

        public Index<string> LoadDocs(string tool)
        {
            var src = Docs(tool);
            var dst = bag<string>();
            iter(src.Files(), file => dst.Add(file.ReadText()));
            return dst.ToIndex();
        }

        public ConstLookup<Actor,FilePath> CalcHelpPaths(FS.FolderPath src)
        {
            var dst = new Lookup<Actor,FilePath>();
            var profiles = LoadProfileLookup(src).Values;
            var count = profiles.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var profile = ref skip(profiles,i);
                ref readonly var tool = ref profile.Id;
                if(profile.HelpCmd.IsEmpty)
                    continue;

                dst.Include(tool, src + FS.folder("help") + FS.file(tool.Format(), FS.Help));
            }

            return dst.Seal();
        }

        public Index<ToolCmdLine> BuildHelpCommands(IToolWs ws)
        {
            var profiles = LoadProfileLookup(ws.Location.Root).Values;
            var count = profiles.Length;
            var dst = list<ToolCmdLine>();
            for(var i=0; i<count; i++)
            {
                ref readonly var profile = ref skip(profiles,i);
                ref readonly var tool = ref profile.Id;
                if(profile.HelpCmd.IsEmpty)
                    continue;
                dst.Add(Tooling.cmdline(ws, tool, string.Format("{0} {1}", profile.Path.Format(PathSeparator.BS), profile.HelpCmd)));
            }
            dst.Sort();
            return dst.ToArray();
        }

        public Index<ToolHelpDoc> EmitHelp(IToolWs ws)
        {
            var result = Outcome.Success;
            var paths = CalcHelpPaths(ws.Location.Root);
            var commands = BuildHelpCommands(ws);
            var count = commands.Length;
            var docs = list<ToolHelpDoc>();
            for(var i=0; i<count; i++)
            {
                ref readonly var cmd = ref commands[i];
                var tool = cmd.Tool;
                result = OmniScript.Run(cmd.Command, CmdVars.Empty, out var response);
                if(result.Fail)
                {
                    Error(result.Message);
                    continue;
                }

                Babble(string.Format("Executed '{0}'", cmd.Format()));

                if(paths.Find(tool, out var path))
                {
                    var length = response.Length;
                    var emitting = EmittingFile(path);
                    using var writer = path.UnicodeWriter();
                    for(var j=0; j<length; j++)
                        writer.WriteLine(skip(response, j).Content);
                    EmittedFile(emitting,length);

                    docs.Add(new ToolHelpDoc(tool,path));
                }
                else
                    Warn(string.Format("{0} has no help path", tool));
            }

            return docs.ToArray();
        }

        // public void EmitIncludePaths()
        // {
        //     var result = Outcome.Success;
        //     var settings = LoadEnv();
        //     var env = ToolEnv.load(settings);
        //     var dst = AppDb.App().Path("env", FileKind.Log);
        //     var emitting = EmittingFile(dst);
        //     using var writer = dst.AsciWriter();
        //     var headers = env.HeaderIncludes();
        //     writer.WriteLine("Header Includes");
        //     writer.WriteLine(RP.PageBreak120);
        //     headers.Iter(h => writer.WriteLine(string.Format("{0,-8} {1,-8} {2}", "Header", h.Exists ? "Found" : "Mising", h)));
        //     writer.WriteLine();

        //     var libs = env.LibIncludes();
        //     writer.WriteLine("Lib Includes");
        //     writer.WriteLine(RP.PageBreak120);
        //     libs.Iter(lib => writer.WriteLine(string.Format("{0,-8} {1,-8} {2}", "Lib", lib.Exists ? "Found" : "Mising", lib)));

        //     EmittedFile(emitting, 2);
        // }

        public ConstLookup<ToolIdOld,ToolHelpDoc> LoadHelpDocs(IDbSources src)
        {
            var dst = dict<ToolIdOld,ToolHelpDoc>();
            var files = src.Files(FileKind.Help);
            iter(files, file =>{
                var fmt = file.FileName.Format();
                var i = text.index(fmt, Chars.Dot);
                if(i > 0)
                {
                    var tool = text.left(fmt,i);
                    dst.TryAdd(tool, new ToolHelpDoc(tool, file, file.ReadAsci()));
                }
            });
            return dst;
        }

        public ConstLookup<Actor,ToolProfile> LoadProfileLookup(FS.FolderPath dir)
        {
            var running = Running(string.Format("Loading tool profiles from {0}", dir));
            var sources = dir.Match("tool.profiles", FS.Csv, true);
            var dst = new Lookup<Actor,ToolProfile>();
            iter(sources, src => LoadProfiles(src,dst));
            var lookup = dst.Seal();
            Ran(running, string.Format("Collected {0} profile definitions", lookup.EntryCount));
            return lookup;
        }

        static Outcome parse(in TextRow src, out ToolProfile dst)
        {
            var result = Outcome.Success;
            dst = default;
            if(src.CellCount != FieldCount)
                result = (false,Tables.FieldCountMismatch.Format(FieldCount, src.CellCount));
            else
            {
                var i=0;
                dst.Id = src[i++].Text;
                dst.Modifier = src[i++].Text;
                dst.HelpCmd = src[i++].Text;
                dst.Memberhisp = src[i++].Text;
                dst.Path = FS.path(src[i++]);
            }
            return result;
        } 
    }
}