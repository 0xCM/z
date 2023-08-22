//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public class ToolCmdSpec
{
    /// <summary>
    /// The path to the tool
    /// </summary>
    public readonly FilePath ToolPath;

    /// <summary>
    /// The arguments supplied to the tool
    /// </summary>
    public readonly CmdArgs Args;

    /// <summary>
    /// The working folder, if any
    /// </summary>
    public readonly FolderPath WorkingDir;

    /// <summary>
    /// Environment variables to use, if any
    /// </summary>
    public readonly EnvVars Vars;
    
    /// <summary>
    /// Invoked upon process creation
    /// </summary>
    public readonly Action<Process> ProcessStart;

    /// <summary>
    /// Invoked upon process exit
    /// </summary>
    public readonly Action<int> ProcessExit;
    
    [MethodImpl(Inline)]
    public ToolCmdSpec(FilePath tool, CmdArgs args, FolderPath wd, EnvVars src, Action<Process> create, Action<int> exit)
    {
        ToolPath = tool;
        Args = args;
        WorkingDir = wd;
        Vars = src;
        ProcessStart = create ?? (p => {});
        ProcessExit = exit ?? (e => {});
    }

    public static ToolCmdSpec Default 
        => new ToolCmdSpec(FilePath.Empty, CmdArgs.Empty, FS.dir(Environment.CurrentDirectory), EnvVars.Empty, null, null);
}
