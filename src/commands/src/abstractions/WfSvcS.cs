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

        protected static IEnvDb EnvDb => AppSettings.EnvDb();

        ConcurrentDictionary<ProjectId, ProjectContext> _Context = new();

        protected static AppDb AppDb => AppDb.Service;

        [MethodImpl(Inline)]
        public IProjectWorkspace Project()
            => Projects.project();

        protected ProjectContext ProjectContext()
        {
            var project = Project();
            return _Context.GetOrAdd(project.ProjectId, _ => Projects.context(project));
        }

        [CmdOp("project/home")]
        protected void ProjectHome()
            => Channel.Write(ProjectContext().Project.Root);

        [CmdOp("project/files")]
        protected void ListProjectFiles()
        {
            iter(ProjectContext().FileIndex.Members(), member => Channel.Row(member.Location));                
        }

        [CmdOp("project/load")]
        public void LoadProject(CmdArgs args)
        {
            var doc = Json.document(FS.path(args[0]));
            var env = Env.process();
            var root = doc.RootElement;
            AsciFence fence = (AsciSymbols.LBrace, AsciSymbols.RBrace);
            var prefix = AsciSymbols.Dollar;
            var found = list<ScriptVar>();
            iter(root.EnumerateObject(), o => {
                switch(o.Name)
                {
                    case "folders":
                        iter(o.Value.EnumerateArray(), folder => {
                            var expr = folder.ToString();
                            var vars = Vars.extract(expr, prefix, fence);
                            iter(vars.Keys, key => {
                                if(env.Find(key, out var value))
                                {
                                    found.Add(Vars.var(key, prefix, fence, value));
                                }
                            });

                            var eval = FS.dir(Vars.eval(expr, found.Array()));
                            if(eval.Exists)
                            {
                                
                            }
                            else
                            {
                                Channel.Error($"Not found: {eval}");
                            }
                            
                        }
                            );
                    break;
                }
            });
            
            //LoadProjectSources(Projects.load(FS.dir(args[0]).DbArchive()));
        }

        void LoadProjectSources(IProjectWorkspace src)
        {
            var loading = Channel.Running($"Loading project from {src.Root}");
            Projects.project(src);
            Files(src.Files().Array().Sort());
            Channel.Ran(loading, $"Project={Projects.project().Root.Name}");
        }

        public new void Babble(string pattern, params object[] args)
            => Channel.Babble(pattern, args);

        public new void Status<T>(T content, FlairKind flair = FlairKind.Status)
            => Channel.Status(content, flair);

        public void Warn<T>(T content, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => Channel.Warn(content, caller, file, line);

        public new void Error<T>(T content, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => Channel.Error(content, caller, file, line);

        public new void Write<T>(T content)
            => Channel.Write(content);

        public void Write<T>(T content, FlairKind flair)
            => Channel.Write(content, flair);

        public void Row<T>(T content)
            => Channel.Row(content);

        public void Row<T>(T content, FlairKind flair)
            => Channel.Row(content, flair);

        public void Write(string content, FlairKind flair)
            => Channel.Write(content, flair);

        public void Write<T>(string name, T value)
            => Channel.Write(name, value);

        public ExecFlow<T> Running<T>(T msg)
            => Channel.Running(msg);

        public new ExecFlow<string> Running([CallerName] string msg = null)
            => Channel.Running(msg);

        public new ExecToken Ran<T>(ExecFlow<T> flow, [CallerName] string msg = null)
            => Channel.Ran(flow, msg);

        public ExecToken Ran<T,D>(ExecFlow<T> src, D data)
            => Channel.Ran(src, data);

        public new FileEmission EmittingFile(FilePath dst)
            => Channel.EmittingFile(dst);

        public ExecToken EmittedFile(FileEmission flow, int count)
            => Channel.EmittedFile(flow, count);

        public ExecToken EmittedFile(FileEmission flow, uint count)
            => Channel.EmittedFile(flow, count);

        public ExecToken EmittedBytes(FileEmission flow, ByteSize size)
            => Channel.EmittedBytes(flow, size);

        public new TableFlow<T> EmittingTable<T>(FilePath dst)
            where T : struct
                => Channel.EmittingTable<T>(dst);

        public new ExecToken EmittedTable<T>(TableFlow<T> flow, Count count, FilePath? dst = null)
            where T : struct
                => Channel.EmittedTable(flow, count, dst);

        public ExecToken FileEmit<T>(T src, Count count, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci)
            => Channel.FileEmit(src, count, dst, encoding);

        public ExecToken FileEmit<T>(T src, FilePath dst, ByteSize size, TextEncodingKind encoding = TextEncodingKind.Asci)
            => Channel.FileEmit(src, dst, size, encoding);

        public ExecToken FileEmit<T>(T src, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci)
            => Channel.FileEmit(src, dst, encoding);

        public ExecToken FileEmit<T>(T src, string msg, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci)
            => Channel.FileEmit(src, msg, dst, encoding);

        public ExecToken FileEmit<T>(ReadOnlySpan<T> src, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci)
            => Channel.FileEmit(src, dst, encoding);

        public ExecToken TableEmit<T>(ReadOnlySpan<T> src, ReadOnlySpan<byte> widths, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci)
            where T : struct
                => Channel.TableEmit(src, widths, encoding, dst);

        public ExecToken TableEmit<T>(ReadOnlySpan<T> rows, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci, ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular)
            where T : struct
                => Channel.TableEmit(rows, dst, encoding, rowpad, fk);

        public ExecToken TableEmit<T>(Index<T> rows, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci, ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular)
            where T : struct
                => Channel.TableEmit(rows, dst, encoding, rowpad, fk);

        public ExecToken TableEmit<T>(T[] rows, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci, ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular)
            where T : struct
            => Channel.TableEmit(rows, dst, encoding, rowpad, fk);

        public ExecToken TableEmit<T>(ReadOnlySeq<T> src, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci)
            where T : struct
            => Channel.TableEmit(src, dst, encoding);

        public ExecToken TableEmit<T>(Seq<T> src, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci)
            where T : struct
                => Channel.TableEmit(src, dst, encoding);
    }
}