//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ApiAtomic;
    using static sys;

    public sealed class ToolWs : Workspace<ToolWs>, IToolWs
    {
        public FolderPath ToolHome(Tool tool)
            => Root + FS.folder(tool.Format());

        public FilePath ConfigScript(Tool tool)
            => ToolHome(tool) + FS.file(ApiAtomic.config, FS.Cmd);

        Dictionary<Actor,ToolConfig> ConfigLookup;

        Index<ToolConfig> Configs;

        // public ToolWs(Tool tool, FolderPath home)
        //     : base(home)
        // {
        //     Tool = tool;
        //     ConfigLookup = dict<Actor,ToolConfig>();
        //     Configs = array<ToolConfig>();
        // }

        public ToolWs(Tool tool, FolderPath home)
            : base(home)
        {
            Tool = tool;
            ConfigLookup = dict<Actor,ToolConfig>();
            Configs = array<ToolConfig>();
        }

        // public ToolWs(Tool tool, IDbArchive home)
        //     : base(home)
        // {
        //     Tool = tool;
        //     ConfigLookup = dict<Actor,ToolConfig>();
        //     Configs = array<ToolConfig>();
        // }

        public DbArchive Location
            => new DbArchive(Root);

        public FolderPath ToolDocs(Tool tool)
            => ToolHome(tool) + FS.folder(docs);

        public FolderPath Logs(Tool tool)
            => ToolHome(tool) + FS.folder(logs);

        public FilePath ConfigPath(Tool tool)
            => ToolHome(tool) + FS.file(tool.Format(), FileKind.Config);

        public FolderPath Scripts(Tool tool)
            => ToolHome(tool) + FS.folder(scripts);

        public FilePath Script(Tool tool, string name)
            => Scripts(tool) + FS.file(name, FS.Cmd);

        public FilePath Inventory()
            => Root + FS.folder(admin) + FS.file(inventory, FS.Txt);

        public ReadOnlySpan<ToolConfig> Configured
        {
            [MethodImpl(Inline)]
            get => Configs;
        }

        public Tool Tool {get;}

        public bool Settings(Actor tool, out ToolConfig dst)
            => ConfigLookup.TryGetValue(tool, out dst);

        public void Configure(Actor tool, in ToolConfig src)
            => ConfigLookup[tool] = src;

        public ToolWs Configure(ToolConfig[] src)
        {
            Configs = src;
            ConfigLookup = src.Select(x => (x.Tool, x)).ToDictionary();
            return this;
        }
    }
}