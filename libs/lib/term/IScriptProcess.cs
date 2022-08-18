//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IScriptProcess
    {
        int ProcessId {get;}

        CmdProcessOptions Options {get;}

        /// <summary>
        /// Gets the time the process started.
        /// </summary>
        DateTime StartTime {get;}

        /// <summary>
        /// Gets a value indicating whether the process has exited.
        /// </summary>
        bool Finished {get;}

        /// <summary>
        /// Gets the time the processed Exited.  (HasExited should be <see langword="true"/> before calling)
        /// </summary>
        DateTime ExitTime {get;}

        /// <summary>
        /// Gets the duration of the command (HasExited should be <see langword="true"/> before calling)
        /// </summary>
        TimeSpan Duration {get;}

        /// <summary>
        /// Gets the process exit code for the subprocess.  (HasExited should be <see langword="true"/> before calling)
        /// Often this does not need to be checked because Command.Run will throw an exception
        /// if it is not zero.   However it is useful if the CommandOptions.NoThrow property
        /// was set.
        /// </summary>
        int ExitCode {get;}

        /// <summary>
        /// Gets the standard output and standard error output from the command.  This
        /// is accumulated in real time so it can vary if the process is still running.
        /// This property is NOT available if the CommandOptions.OutputFile or CommandOptions.OutputStream
        /// is specified since the output is being redirected there.   If a large amount of output is
        /// expected (> 1Meg), the Run.AddOutputStream(Stream) is recommended for retrieving it since
        /// the large string is never materialized at one time.
        /// </summary>
        string Output {get;}

        /// <summary>
        /// Throw a error if the command exited with a non-zero exit code
        /// printing useful diagnostic information along with the thrown message.
        /// This is useful when NoThrow is specified, and after post-processing
        /// you determine that the command really did fail, and an normal
        /// Command.Run failure was the appropriate action.
        /// </summary>
        /// <param name="message">An additional message to print in the throw.</param>
        void ThrowCommandFailure(string message);

        /// <summary>
        /// Kill the process (and any child processses (recursively) associated with the
        /// running command).   Note that it may not be able to kill everything it should
        /// if the child-parent' chain is broken by a child that creates a subprocess and
        /// then dies itself.   This is reasonably uncommon, however.
        /// </summary>
        void Kill();
    }

    [Free]
    public interface ICmdProcess<P> : IScriptProcess
        where P : ICmdProcess<P>
    {
        /// <summary>
        /// Wait for a started process to complete (HasExited will be <see langword="true"/> on return)
        /// </summary>
        /// <returns>Wait returns that 'this' pointer.</returns>
        P Wait();
    }
}