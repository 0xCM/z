//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{    
    using System.Linq;
    
    public abstract class Toolset<T>
        where T : Toolset<T>, new()
    {
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

        protected Toolset(FolderPath root, string name)
        {
            Location = root.DbArchive();
            Name = name;
        }

        public ToolWs Tool(Tool tool)
            => new ToolWs(tool, Location.Sources(tool.Name).Root);

        public ReadOnlySeq<ToolWs> Tools()
        {
            var src = Location.Folders(false).Where(f => !f.Name.StartsWith(".")).ToSeq();
            var count = src.Count;
            var dst = sys.alloc<ToolWs>(count);
            for(var i=0; i<count; i++)
                dst[i] = new ToolWs(src[i].FolderName.Name.Format(), src[i]);
            return dst;
        }
    }
}