//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public abstract class WfSvc<S> : AppService<S>, IWfSvc<S>
        where S : WfSvc<S>, new()
    {
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
                Error(e, caller, file, line);
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
        public Outcome LoadProject(CmdArgs args)
            => LoadProjectSources(EtlDb.EtlSource(arg(args, 0).Value));

        protected Outcome LoadProjectSources(IProjectWorkspace ws)
        {
            var result = Outcome.Success;
            if (ws == null)
                result = Outcome.fail("Project unspecified");
            else
            {
                Status($"Loading project from {ws.Home()}");
                Projects.project(ws);
                ProjectFiles = FileCatalog.load(Projects.project().ProjectFiles().Storage.ToSortedSpan());
                var dir = ws.Home();
                if (dir.Exists)
                    Files(ws.SourceFiles());
                Status($"Project={Projects.project()}");
            }
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

        public void Write<T>(string name, T value, FlairKind flair)
            => Emitter.Write(name, value, flair);

        public void Write<T>(string name, T value)
            => Emitter.Write(name, value);

        public WfExecFlow<T> Running<T>(T msg)
            => Emitter.Running(msg);

        public new WfExecFlow<string> Running([CallerName] string msg = null)
            => Emitter.Running(msg);

        public new ExecToken Ran<T>(WfExecFlow<T> flow, [CallerName] string msg = null)
            => Emitter.Ran(flow, msg);

        public ExecToken Ran<T, D>(WfExecFlow<T> src, D data)
            => Emitter.Ran(src, data);

        public new FileWritten EmittingFile(FilePath dst)
            => Emitter.EmittingFile(dst);

        public ExecToken EmittedFile(FileWritten flow, int count)
            => Emitter.EmittedFile(flow, count);

        public ExecToken EmittedFile(FileWritten flow, uint count)
            => Emitter.EmittedFile(flow, count);

        public ExecToken EmittedBytes(FileWritten flow, ByteSize size)
            => Emitter.EmittedBytes(flow, size);

        public new WfTableFlow<T> EmittingTable<T>(FilePath dst)
            where T : struct
                => Emitter.EmittingTable<T>(dst);

        public new ExecToken EmittedTable<T>(WfTableFlow<T> flow, Count count, FilePath? dst = null)
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