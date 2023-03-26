//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static ProjectModels;

    public partial class ProjectServices : WfSvc<ProjectServices>
    {
        public IProject LoadProject(FilePath src)
        {
            var doc = Json.document(src);
            var env = Env.process();
            var root = doc.RootElement;
            AsciFence fence = (AsciSymbols.LBrace, AsciSymbols.RBrace);
            var prefix = AsciSymbols.Dollar;
            var folders = list<FolderPath>();
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
                                folders.Add(eval);
                            }
                            else
                            {
                                Channel.Error($"Not found: {eval}");
                            }                            
                        });
                    break;
                }
            });
            
            return new AggregateProject(src, folders.Array());
        }

        public void EmitApiDeps(IDbArchive dst)
        {
            var src = ExecutingPart.Assembly;
            var path = dst.Path($"{src.GetSimpleName()}", FileKind.DepsList);
            if(path.Exists)
                EmitApiDeps(src, path);
        }

        public void EmitApiDeps(Assembly src, FilePath dst)
        {
            var deps = JsonDeps.load(src);
            var buffer = list<string>();
            iteri(deps.RuntimeLibs(), (i,lib) => buffer.Add(string.Format("{0:D4}:{1}",i,lib)));
            var emitter = text.emitter();
            iter(buffer, line => emitter.AppendLine(line));
            Channel.FileEmit(emitter.Emit(), buffer.Count, dst);
        }

        public FileSource CreateFileSource(FilePath src)
            => new FileSource(src);

        public FolderSource CreateFolderSource(FolderPath src)
            => new FolderSource(src);
    }
}