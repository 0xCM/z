//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public abstract class WfSvc<S> : AppService<S>
        where S : WfSvc<S>, new()
    {
        protected static AppSettings AppSettings => AppSettings.Default;
        
        ConcurrentDictionary<ProjectId, ProjectContext> _Context = new();

        public FileCatalog ProjectFiles { get; protected set; }

        protected OmniScript OmniScript => Wf.OmniScript();

        protected static AppDb AppDb => AppDb.Service;

        protected static EtlTasks EtlDb => new EtlTasks(AppDb);
    
        [MethodImpl(Inline)]
        public IProjectWorkspace Project()
            => Projects.project();

        protected void Try(Action f, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
        {
            try
            {
                f();
            }
            catch (Exception e)
            {
                Channel.Error(e, caller, file, line);
            }
        }

        protected ProjectContext ProjectContext()
        {
            var project = Project();
            return _Context.GetOrAdd(project.ProjectId, _ => Projects.context(project));
        }

        [CmdOp("project/home")]
        protected void ProjectHome()
            => Write(ProjectContext().Project.Home());

        [CmdOp("project/files")]
        protected void ListProjectFiles(CmdArgs args)
        {
            if (args.Count != 0)
                iter(ProjectContext().Files.Docs(arg(args, 0)), file => Write(file.Format()));
            else
                iter(ProjectContext().Files.Docs(), file => Write(file.Format()));
        }

        [CmdOp("project")]
        public void LoadProject(CmdArgs args)
            => LoadProjectSources(EtlDb.EtlSource(arg(args, 0).Value));

        protected void LoadProjectSources(IProjectWorkspace ws)
        {
            var result = Outcome.Success;
            if (ws == null)
                Channel.Error("Project unspecified");
            else
            {
                Channel.Status($"Loading project from {ws.Home()}");
                Projects.project(ws);
                ProjectFiles = FileCatalog.load(Projects.project().ProjectFiles().Storage.ToSortedSpan());
                var dir = ws.Home();
                if (dir.Exists)
                    Files(ws.SourceFiles());
                Channel.Status($"Project={Projects.project()}");
            }
        }

        Outcome AsmExe(CmdArgs args)
        {
            var result = Outcome.Success;
            var id = arg(args,0).Value;
            var script = FilePath.Empty;
            result = ExecVarScript(id,script);
            if(result.Fail)
                return result;
            //var exe = AsmWs.ExePath(id);
            var exe = FilePath.Empty;
            var clock = Time.counter(true);
            var process = Process.Start(exe.Format());
            process.WaitForExit();
            var duration = clock.Elapsed();
            Write(string.Format("runtime:{0}", duration));
            return result;
        }

        Outcome ExecVarScript(string SrcId, FilePath script)
        {
            const string ScriptId = "build-exe";
            var result = Outcome.Success;
            var vars = CmdVars.load(("SrcId", SrcId));
            var cmd = new CmdLine(script.Format(PathSeparator.BS));
            return OmniScript.Run(cmd, vars, out var response);
        }

        Outcome AsmConfig(CmdArgs args)
        {
            var result = OmniScript.Run(FolderPath.Empty + FS.file("log-config",FileKind.Cmd), out var response);
            if(result.Fail)
                return result;

            var src = Settings.parse(response, Chars.Colon);
            var count = src.Length;
            var vars = new CmdVar[count];
            for(var i=0; i<count; i++)
            {
                ref readonly var facet = ref src[i];
                seek(vars,i) = CmdVars.var(facet.Name, facet.Value);
            }

            iter(vars, v => Write(v.Name,
                v.Evaluated ? string.Format("{0} (Evaluated)", v.Value) : string.Format("{0} (Symbolic)", v.Value))
                );

            return result;
        }

        public new void Babble(string pattern, params object[] args)
            => Emitter.Babble(pattern, args);

        public new void Status<T>(T content, FlairKind flair = FlairKind.Status)
            => Emitter.Status(content, flair);

        public void Warn<T>(T content, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => Emitter.Warn(content, caller, file, line);

        public new void Error<T>(T content, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => Emitter.Error(content, caller, file, line);

        public new void Write<T>(T content)
            => Emitter.Write(content);

        public void Write<T>(T content, FlairKind flair)
            => Emitter.Write(content, flair);

        public void Row<T>(T content)
            => Emitter.Row(content);

        public void Row<T>(T content, FlairKind flair)
            => Emitter.Row(content, flair);

        public void Write(string content, FlairKind flair)
            => Emitter.Write(content, flair);

        public void Write<T>(string name, T value)
            => Emitter.Write(name, value);

        public ExecFlow<T> Running<T>(T msg)
            => Emitter.Running(msg);

        public new ExecFlow<string> Running([CallerName] string msg = null)
            => Emitter.Running(msg);

        public new ExecToken Ran<T>(ExecFlow<T> flow, [CallerName] string msg = null)
            => Emitter.Ran(flow, msg);

        public ExecToken Ran<T,D>(ExecFlow<T> src, D data)
            => Emitter.Ran(src, data);

        public new FileEmission EmittingFile(FilePath dst)
            => Emitter.EmittingFile(dst);

        public ExecToken EmittedFile(FileEmission flow, int count)
            => Emitter.EmittedFile(flow, count);

        public ExecToken EmittedFile(FileEmission flow, uint count)
            => Emitter.EmittedFile(flow, count);

        public ExecToken EmittedBytes(FileEmission flow, ByteSize size)
            => Emitter.EmittedBytes(flow, size);

        public new TableFlow<T> EmittingTable<T>(FilePath dst)
            where T : struct
                => Emitter.EmittingTable<T>(dst);

        public new ExecToken EmittedTable<T>(TableFlow<T> flow, Count count, FilePath? dst = null)
            where T : struct
                => Emitter.EmittedTable(flow, count, dst);

        public ExecToken FileEmit<T>(T src, Count count, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci)
            => Emitter.FileEmit(src, count, dst, encoding);

        public ExecToken FileEmit<T>(T src, FilePath dst, ByteSize size, TextEncodingKind encoding = TextEncodingKind.Asci)
            => Emitter.FileEmit(src, dst, size, encoding);

        public ExecToken FileEmit<T>(T src, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci)
            => Emitter.FileEmit(src, dst, encoding);

        public ExecToken FileEmit<T>(T src, string msg, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci)
            => Emitter.FileEmit(src, msg, dst, encoding);

        public ExecToken FileEmit<T>(ReadOnlySpan<T> src, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci)
            => Emitter.FileEmit(src, dst, encoding);

        public ExecToken TableEmit<T>(ReadOnlySpan<T> src, ReadOnlySpan<byte> widths, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci)
            where T : struct
                => Emitter.TableEmit(src, widths, encoding, dst);

        public ExecToken TableEmit<T>(ReadOnlySpan<T> rows, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci, ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular)
            where T : struct
                => Emitter.TableEmit(rows, dst, encoding, rowpad, fk);

        public ExecToken TableEmit<T>(Index<T> rows, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci, ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular)
            where T : struct
                => Emitter.TableEmit(rows, dst, encoding, rowpad, fk);

        public ExecToken TableEmit<T>(T[] rows, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci, ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular)
            where T : struct
            => Emitter.TableEmit(rows, dst, encoding, rowpad, fk);

        public ExecToken TableEmit<T>(ReadOnlySeq<T> src, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci)
            where T : struct
            => Emitter.TableEmit(src, dst, encoding);

        public ExecToken TableEmit<T>(Seq<T> src, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci)
            where T : struct
                => Emitter.TableEmit(src, dst, encoding);
    }
}