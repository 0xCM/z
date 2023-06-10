//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a configuration for an identified tool
    /// </summary>
    [StructLayout(LayoutKind.Sequential), Record(TableId)]
    public record struct ToolConfig
    {
        const string TableId = "tool.config";

        public const byte FieldCount = 15;

        /// <summary>
        /// The tool control base directory
        /// </summary>
        public FolderPath Toolbase;

        /// <summary>
        /// The group to which the tool belongs, if any
        /// </summary>
        public string ToolGroup;

        /// <summary>
        /// The tool identifier
        /// </summary>
        public Actor Tool;

        /// <summary>
        /// The executable filename without the directory path
        /// </summary>
        public FileName ToolExe;

        /// <summary>
        /// The tool installation directory where the <see cref='ToolExe'/> is found
        /// </summary>
        public FolderPath InstallBase;

        /// <summary>
        /// The full path to the tool, computed from the <see cref='ToolExe'/> and <see cref='InstallBase'/>
        /// </summary>
        public FilePath ToolPath;

        /// <summary>
        /// The toolspace directory
        /// </summary>
        public FolderPath ToolHome;

        /// <summary>
        /// The tool log directory with default location {ToolHome}/logs
        /// </summary>
        public FolderPath ToolLogs;

        /// <summary>
        /// The tool documentation directory with default location {ToolHome}/docs
        /// </summary>
        public FolderPath ToolDocs;

        /// <summary>
        /// The tool script directory with default location {ToolHome}/scripts
        /// </summary>
        public FolderPath ToolScripts;

        /// <summary>
        /// The path to the tool configuration log, typically {ToolLogs}/config.log
        /// </summary>
        public FilePath ToolConfigLog;

        /// <summary>
        /// The path to the tool execution log, typically {ToolLogs}/{ToolId}-run.log
        /// </summary>
        public FilePath ToolRunLog;

        /// <summary>
        /// The path to the tool command log, typically {ToolLogs}/{ToolId}-cmd.log
        /// </summary>
        public FilePath ToolCmdLog;

        /// <summary>
        /// The path to the primary tool help file, typically {ToolHome}/docs/{ToolId}.help
        /// </summary>
        public FilePath ToolHelpPath;

        /// <summary>
        /// The path to the defalt tool output directory
        /// </summary>
        public FilePath ToolOut;

        public static ToolConfig Empty => default;
    }
}