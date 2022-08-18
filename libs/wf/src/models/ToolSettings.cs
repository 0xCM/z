//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static FS;

    [Settings(Id)]
    public record struct ToolSettings : ISettings<ToolSettings>
    {
        const string Id = "settings.env";

        public Name ToolId;

        public Name Group;

        public FileUri ToolEnv;

        public FolderPath InstallBase;

        public FolderPath ToolHome;

        public FolderPath ToolLogs;

        public FolderPath ToolDocs;

        public FolderPath ToolScripts;

        public string Format(uint indent = 0)
        {
            var dst = text.emitter();
            dst.IndentLine(indent, $"{nameof(ToolId)}={ToolId},");
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