//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2023
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a tool execution specification
    /// </summary>
    public record class ToolCmd : IToolCmd
    {
        /// <summary>
        /// The tool path
        /// </summary>
        public readonly FilePath ToolPath;

        /// <summary>
        /// The command arguments
        /// </summary>
        public readonly ToolCmdArgs Args;

        /// <summary>
        /// The working folder, if any
        /// </summary>
        public readonly FolderPath WorkingDir;

        /// <summary>
        /// Environment variables to use, if any
        /// </summary>
        public readonly EnvVars Vars;

        [MethodImpl(Inline)]
        public ToolCmd(FilePath tool, ToolCmdArgs args, FolderPath work, EnvVars vars)
        {            
            ToolPath = tool;
            Args = args;
            WorkingDir = work;
            Vars = vars;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => ToolPath.Hash | Args.Hash;
        }

        public override int GetHashCode()
            => Hash;

        public string Format()
            => Tooling.format(this);

        public override string ToString()
            => Format();

        public static ToolCmd Empty
        {
            [MethodImpl(Inline)]
            get => new ToolCmd(FilePath.Empty, ToolCmdArgs.Empty, FolderPath.Empty, EnvVars.Empty);
        }

        ToolCmdArgs IToolCmd.Args
            => Args;

        FilePath IToolCmd.ToolPath
             => ToolPath;

        CmdId ICmd.CmdId 
            => EmptyString;
    }
}