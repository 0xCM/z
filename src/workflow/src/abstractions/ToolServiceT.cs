//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class ToolService<T> : WfAppCmd<T>
        where T : ToolService<T>, new()
    {
        public virtual Actor Id {get;}

        protected ToolService(Actor id)
        {
            Id = id;
        }

        protected virtual IDbArchive Deployments
            => AppDb.Toolbase();

        protected FolderPath Deployment
            => Deployments.Folder(Id.Format());

        public FilePath Script(FolderPath dir, FileName name)
            => dir + name;

        public virtual FilePath ToolPath()
            => Deployment +  FS.file(string.Format("{0}.{1}", Id, FS.Exe));

        protected static string format(FilePath src)
            => src.Format(PathSeparator.BS);

        protected static FilePath input(FolderPath dir, FileName name)
            => dir + name;

        protected static FilePath output(FolderPath dir, FileName name)
            => dir + name;

        protected static FileName file(string src, FileExt ext)
            => FS.file(src, ext);

        protected static FileName binfile(string name)
            => FS.file(name, FS.Bin);

        protected FileName ToolFile(string name, string type, FileExt ext)
            => FS.file(string.Format("{0}.{1}.{2}", name, Id, type), ext);

        protected FileName ToolFile(string name, string type, FileKind kind)
            => FS.file(string.Format("{0}.{1}.{2}", name, Id, type), kind.Ext());
    }
}