//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ICmdHandler : ICmdEffector
    {
        /// <summary>
        /// Invokes the command
        /// </summary>
        /// <param name="args">The command arguments</param>
        /// <returns></returns>
        Task<ExecToken> Start(CmdArgs args);

        void Run(CmdArgs args);
        
        /// <summary>
        /// The subcommands, if any
        /// </summary>
        ReadOnlySeq<@string> SubCommands {get;}

        /// <summary>
        /// Prepares a handler for command execution
        /// </summary>
        /// <param name="wf">The context in which execution will occur</param>
        void Initialize(IWfRuntime wf);        
    }
}