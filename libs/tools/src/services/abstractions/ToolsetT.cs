//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{    
    public abstract class Toolset<T> : IToolset<T>
        where T : Toolset<T>, new()
    {
        static AppDb AppDb => AppDb.Service;

        public IDbArchive Location {get;}

        public Name Name {get;}

        public Hash32 Hash
        {
            get => Name.Hash;
        }

        public bool IsEmpty 
        {
            get => Name.IsEmpty;
        }

        protected Toolset(string name)
        {
            Name = name;
            Location = Datasets.archive(AppDb.DevOps("toolsets"));
        }

        protected Toolset()
        {
            Name = "toolbase";
            Location = Datasets.archive(AppDb.DevOps("toolsets"));
        }

        public IToolWs Tool(Tool tool)
            => new ToolWs(tool, Location.Sources(tool.Name).Root);

        public ReadOnlySeq<IToolWs> Tools()
        {
            var src = Location.Folders(false).Where(f => !f.Name.StartsWith("."));
            var count = src.Count;
            Seq<IToolWs> dst = sys.alloc<IToolWs>(count);
            for(var i=0; i<count; i++)
                dst[i] = new ToolWs(src[i].FolderName.Name.Format(), src[i]);
            return dst;
        }
    }
}