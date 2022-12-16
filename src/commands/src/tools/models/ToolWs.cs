//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ApiAtomic;
    using static sys;

    /// <summary>
    /// Defines a container for tool representation and control
    /// </summary>
    public sealed class ToolProject : Project
    {
        public readonly ToolConfig Config;

        public ToolProject()
        {

        }

        public ToolProject(ToolConfig config)
            : base(config.Tool.Name, new DbArchive(config.ToolHome))
        {
            Config = config;
        }

    }

    /// <summary>
    /// Defines a collection of tool controllers
    /// </summary>
    public sealed class ToolWs : Project, IToolWs
    {
        public static ToolProject project(ToolConfig config)
            => new ToolProject(config);

        public static ReadOnlySeq<ToolProject> projects(ReadOnlySpan<ToolConfig> src)
            => src.Map(project);

        // public FolderPath ToolHome(Tool tool)
        //     => Root + FS.folder(tool.Format());

        // public FilePath ConfigScript(Tool tool)
        //     => ToolHome(tool) + FS.file(ApiAtomic.config, FS.Cmd);

        Dictionary<Actor,ToolConfig> ConfigLookup;

        Index<ToolConfig> Configs;

        public ToolWs()
        {

        }

        public ToolWs(Tool tool, FolderPath home)
            : base(tool.Name, new DbArchive(home))
        {
            Tool = tool;
            ConfigLookup = dict<Actor,ToolConfig>();
            Configs = array<ToolConfig>();
        }

        public string Format()
            => Name.Format();

        // public FolderPath ToolDocs(Tool tool)
        //     => ToolHome(tool) + FS.folder(docs);

        // public FolderPath Logs(Tool tool)
        //     => ToolHome(tool) + FS.folder(logs);

        // public FilePath ConfigPath(Tool tool)
        //     => ToolHome(tool) + FS.file(tool.Format(), FileKind.Config);

        public IDbArchive Scripts(Tool tool)
            => Root.Scoped(tool.Name).Scoped(scripts);

        // public FilePath Script(Tool tool, string name)
        //     => Scripts(tool) + FS.file(name, FS.Cmd);

        // public FilePath Inventory()
        //     => Root + FS.folder(admin) + FS.file(inventory, FS.Txt);

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