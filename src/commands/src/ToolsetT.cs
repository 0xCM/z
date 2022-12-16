//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{    
    public abstract class Toolset<T>
        where T : Toolset<T>, new()
    {
        static AppDb AppDb => AppDb.Service;

        public IDbArchive Location {get;}

        public @string Name {get;}

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
            Location = AppDb.DevOps("toolsets");
        }

        protected Toolset()
        {
            Name = "toolbase";
            Location = AppDb.DevOps("toolsets");
        }

        public ToolWs Tool(Tool tool)
            => new ToolWs(tool, Location.Sources(tool.Name).Root);

        public ReadOnlySeq<ToolWs> Tools()
        {
            var src = Location.Folders(false).Where(f => !f.Name.StartsWith("."));
            var count = src.Count;
            var dst = sys.alloc<ToolWs>(count);
            for(var i=0; i<count; i++)
                dst[i] = new ToolWs(src[i].FolderName.Name.Format(), src[i]);
            return dst;
        }
    }
}