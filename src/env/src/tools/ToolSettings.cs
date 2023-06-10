//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using S = ToolSettings;

    [Settings(Id)]
    public record struct ToolSettings : ISettings<ToolSettings>
    {
        const string Id = "settings.env";

        public static Outcome parse(TextRow src, out ToolProfile dst)
        {
            var result = Outcome.Success;
            dst = default;
            var i=0;
            dst.ToolName = src[i++].Text;
            dst.Modifier = src[i++].Text;
            dst.HelpCmd = src[i++].Text;
            dst.Membership = src[i++].Text;
            dst.Executable = FS.path(src[i++]);
            return result;
        } 

        public static void profiles(FilePath src, Lookup<Actor,ToolProfile> dst, IWfChannel channel)
        {
            var content = src.ReadUnicode();
            var result = TextGrids.parse(content, out var grid);
            if(result)
            {
                var count = grid.RowCount;
                for(var i=0; i<count; i++)
                {
                    result = parse(grid[i], out ToolProfile profile);
                    if(result)
                        dst.Include(profile.ToolName, profile);
                    else
                        break;
                }
            }
        }

        public static ToolSettings load(FilePath src)
        {
            var data = EnvReports.vars(src);
            var dst = new ToolSettings();
            var setting = @string.Empty;
            if(data.Find(nameof(S.Tool), out setting))
                dst.Tool = new Tool(setting);
            if(data.Find(nameof(S.Group), out setting))
                dst.Group = setting;
            if(data.Find(nameof(S.ToolEnv), out setting))
                dst.ToolEnv = FS.path(setting);
            if(data.Find(nameof(S.InstallBase), out setting))
                dst.InstallBase = FS.dir(setting);
            if(data.Find(nameof(S.ToolHome), out setting))
                dst.ToolHome = FS.dir(setting);
            if(data.Find(nameof(S.ToolLogs), out setting))
                dst.ToolLogs = FS.dir(setting);
            if(data.Find(nameof(S.ToolDocs), out setting))
                dst.ToolDocs = FS.dir(setting);
            if(data.Find(nameof(S.ToolScripts), out setting))
                dst.ToolScripts = FS.dir(setting);
            return dst;
        }

        public Tool Tool;

        public @string Group;

        public FilePath ToolEnv;

        public FolderPath InstallBase;

        public FolderPath ToolHome;

        public FolderPath ToolLogs;

        public FolderPath ToolDocs;

        public FolderPath ToolScripts;

        public string Format(uint indent = 0)
        {
            var dst = text.emitter();
            dst.IndentLine(indent, $"{nameof(Tool)}={Tool},");
            dst.IndentLine(indent, $"{nameof(Group)}={Group},");
            dst.IndentLine(indent, $"{nameof(ToolEnv)}={ToolEnv},");
            dst.IndentLine(indent, $"{nameof(InstallBase)}={InstallBase},");
            dst.IndentLine(indent, $"{nameof(ToolHome)}={ToolHome},");
            dst.IndentLine(indent, $"{nameof(ToolLogs)}={ToolLogs},");
            dst.IndentLine(indent, $"{nameof(ToolDocs)}={ToolDocs},");
            dst.IndentLine(indent, $"{nameof(ToolScripts)}={ToolScripts},");
            return dst.Emit();
        }

        public override string ToString()
            => Format();
    }
}