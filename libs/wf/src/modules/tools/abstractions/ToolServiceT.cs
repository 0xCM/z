//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class ToolService<T> : AppCmdService<T>
        where T : ToolService<T>, new()
    {
        public virtual Actor Id {get;}

        protected ToolService(Actor id)
        {
            Id = id;
        }

        protected virtual IDbSources Deployments
            => AppDb.Toolbase();

        protected FS.FolderPath Deployment
            => Deployments.Folder(Id.Format());

        public FS.FilePath Script(FS.FolderPath dir, FS.FileName name)
            => dir + name;

        public virtual FS.FilePath ToolPath()
            => Deployment +  FS.file(string.Format("{0}.{1}", Id, FS.Exe));

        protected static string format(FS.FilePath src)
            => src.Format(PathSeparator.BS);

        protected static FS.FilePath input(FS.FolderPath dir, FS.FileName name)
            => dir + name;

        protected static FS.FilePath output(FS.FolderPath dir, FS.FileName name)
            => dir + name;

        protected static FS.FileName file(string src, FileExt ext)
            => FS.file(src, ext);

        protected static FS.FileName binfile(string name)
            => FS.file(name, FS.Bin);

        protected FS.FileName ToolFile(string name, string type, FileExt ext)
            => FS.file(string.Format("{0}.{1}.{2}", name, Id, type), ext);

        protected FS.FileName ToolFile(string name, string type, FileKind kind)
            => FS.file(string.Format("{0}.{1}.{2}", name, Id, type), kind.Ext());
    }
}