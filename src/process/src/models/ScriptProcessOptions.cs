//-----------------------------------------------------------------------------
// Derivative Work
// Copyright  : Microsoft/.Net foundation
// Copyright  : (c) Chris Moore, 2020
// License    :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;

    /// <summary>
    /// CommandOptions is a helper class for the Command class.  It stores options
    /// that affect the behavior of the execution of ETWCommands and is passes as a
    /// parapeter to the constructor of a Command.
    /// It is useful for these options be be on a separate class (rather than
    /// on Command itself), because it is reasonably common to want to have a set
    /// of options passed to several commands, which is not easily possible otherwise.
    /// </summary>
    public sealed class CmdProcessOptions
    {
        /// <summary>
        /// Can be assigned to the Timeout Property to indicate infinite timeout.
        /// </summary>
        public const int Infinite = System.Threading.Timeout.Infinite;

        public bool _NoThrow;

        public bool _UseShellExecute;

        public bool _NoWindow;

        public bool _Elevate;

        public int _TimeoutMS;

        public string _Input;

        public string _OutputFile;

        public TextWriter _OutputStream;

        public string _CurrentDirectory;

        public Dictionary<string, string> _EnvVars;

        Receiver<string> _StatusReceiver;

        Receiver<string> _ErrorReceiver;

        static void OnStaus(in string src)
        {
            if(sys.nonempty(src))
                term.babble(src);
        }

        static void OnError(in string src)
        {
             if(sys.nonempty(src))
                term.error(src);
        }

        /// <summary>
        /// CommanOptions holds a set of options that can be passed to the constructor
        /// to the Command Class as well as Command.Run*.
        /// </summary>
        public CmdProcessOptions()
        {
            _TimeoutMS = Int32.MaxValue;
            _NoThrow = true;
            _StatusReceiver = OnStaus;
            _ErrorReceiver = OnError;
        }

        public CmdProcessOptions(TextWriter output)
            : this()
        {
            OutputStream = output;
        }

        public CmdProcessOptions WithReceivers(Receiver<string> status, Receiver<string> error)
        {
            _ErrorReceiver = error;
            _StatusReceiver = status;
            return this;
        }

        public Receiver<string> StatusReceiver
        {
            [MethodImpl(Inline)]
            get => _StatusReceiver;
        }

        public Receiver<string> ErrorReceiver
        {
            [MethodImpl(Inline)]
            get => _ErrorReceiver;
        }

        /// <summary>
        /// Return a copy an existing set of command options.
        /// </summary>
        /// <returns>The copy of the command options.</returns>
        public CmdProcessOptions Clone()
            => (CmdProcessOptions)MemberwiseClone();

        /// <summary>
        /// Normally commands will throw if the subprocess returns a non-zero
        /// exit code.  NoThrow suppresses this.
        /// </summary>
        public bool NoThrow
        {
            get => _NoThrow;
            set => _NoThrow = value;
        }

        /// <summary>
        /// Updates the NoThrow property and returns the updated commandOptions.
        /// <returns>Updated command options</returns>
        /// </summary>
        public CmdProcessOptions AddNoThrow()
        {
            _NoThrow = true;
            return this;
        }

        /// <summary>
        /// ShortHand for UseShellExecute and NoWait.
        /// </summary>
        public bool Start
        {
            get => _UseShellExecute;
            set
            {
                _UseShellExecute = value;
            }
        }

        /// <summary>
        /// Updates the Start property and returns the updated commandOptions.
        /// </summary>
        public CmdProcessOptions AddStart()
        {
            Start = true;
            return this;
        }

        /// <summary>
        /// Normally commands are launched with CreateProcess.  However it is
        /// also possible use the Shell Start API.  This causes Command to look
        /// up the executable differently.
        /// </summary>
        public bool UseShellExecute
        {
            get => _UseShellExecute;
            set => _UseShellExecute = value;
        }

        /// <summary>
        /// Updates the Start property and returns the updated commandOptions.
        /// </summary>
        public CmdProcessOptions AddUseShellExecute()
        {
            _UseShellExecute = true;
            return this;
        }

        /// <summary>
        /// Indicates that you want to hide any new window created.
        /// </summary>
        public bool NoWindow
        {
            get => _NoWindow;
            set => _NoWindow = value;
        }

        /// <summary>
        /// Updates the NoWindow property and returns the updated commandOptions.
        /// </summary>
        public CmdProcessOptions AddNoWindow()
        {
            _NoWindow = true;
            return this;
        }


        /// <summary>
        /// Gets or sets a value indicating whether the command must run at elevated Windows privledges (causes a new command window).
        /// </summary>
        public bool Elevate
        {
            get => _Elevate;
            set => _Elevate = value;
        }

        /// <summary>
        /// Updates the Elevate property and returns the updated commandOptions.
        /// </summary>
        public CmdProcessOptions AddElevate()
        {
            _Elevate = true;
            return this;
        }

        /// <summary>
        /// By default commands have a 10 minute timeout (600,000 msec), If this
        /// is inappropriate, the Timeout property can change this.  Like all
        /// timouts in .NET, it is in units of milliseconds, and you can use
        /// CommandOptions.Infinite to indicate no timeout.
        /// </summary>
        public int Timeout
        {
            get => _TimeoutMS;
            set => _TimeoutMS = value;
        }

        /// <summary>
        /// Updates the Timeout property and returns the updated commandOptions.
        /// CommandOptions.Infinite can be used for infinite.
        /// </summary>
        public CmdProcessOptions AddTimeout(int milliseconds)
        {
            _TimeoutMS = milliseconds;
            return this;
        }

        /// <summary>
        /// Indicates the string will be sent to Console.In for the subprocess.
        /// </summary>
        public string Input
        {
            get => _Input;
            set => _Input = value;
        }

        /// <summary>
        /// Updates the Input property and returns the updated commandOptions.
        /// </summary>
        public CmdProcessOptions AddInput(string input)
        {
            this._Input = input;
            return this;
        }

        /// <summary>
        /// Indicates the current directory the subProcess will have.
        /// </summary>
        public string CurrentDirectory
        {
            get => _CurrentDirectory;
            set => _CurrentDirectory = value;
        }

        /// <summary>
        /// Updates the CurrentDirectory property and returns the updated commandOptions.
        /// </summary>
        public CmdProcessOptions AddCurrentDirectory(string directoryPath)
        {
            _CurrentDirectory = directoryPath;
            return this;
        }

        // TODO add a capability to return a enumerator of output lines. (and/or maybe a delegate callback)

        /// <summary>
        /// Indicates the standard output and error of the command should be redirected
        /// to a archiveFile rather than being stored in Memory in the 'Output' property of the
        /// command.
        /// </summary>
        public string OutputFile
        {
            get => _OutputFile;
            set
            {
                if (_OutputStream != null)
                    throw new Exception("OutputFile and OutputStream can not both be set");

                _OutputFile = value;
            }
        }

        /// <summary>
        /// Updates the OutputFile property and returns the updated commandOptions.
        /// </summary>
        public CmdProcessOptions AddOutputFile(string outputFile)
        {
            OutputFile = outputFile;
            return this;
        }

        /// <summary>
        /// Indicates the standard output and error of the command should be redirected
        /// to a a TextWriter rather than being stored in Memory in the 'Output' property
        /// of the command.
        /// </summary>
        public TextWriter OutputStream
        {
            get => _OutputStream;
            set
            {
                if (_OutputFile != null)
                    throw new Exception("OutputFile and OutputStream can not both be set");

                _OutputStream = value;
            }
        }

        /// <summary>
        /// Updates the OutputStream property and returns the updated commandOptions.
        /// </summary>
        public CmdProcessOptions AddOutputStream(TextWriter outputStream)
        {
            OutputStream = outputStream;
            return this;
        }

        /// <summary>
        /// Gets the Environment variables that will be set in the subprocess that
        /// differ from current process's environment variables.  Any time a string
        /// of the form %VAR% is found in a value of a environment variable it is
        /// replaced with the value of the environment variable at the time the
        /// command is launched.  This is useful for example to update the PATH
        /// environment variable eg. "%PATH%;someNewPath".
        /// </summary>
        public Dictionary<string, string> EnvironmentVariables
        {
            get
            {
                _EnvVars ??= new Dictionary<string, string>();
                return _EnvVars;
            }
        }

        /// <summary>
        /// Adds the environment variable with the give value to the set of
        /// environment variables to be passed to the sub-process and returns the
        /// updated commandOptions.   Any time a string
        /// of the form %VAR% is found in a value of a environment variable it is
        /// replaced with the value of the environment variable at the time the
        /// command is launched.  This is useful for example to update the PATH
        /// environment variable eg. "%PATH%;someNewPath".
        /// </summary>
        public CmdProcessOptions AddEnvironmentVariable(string variable, string value)
        {
            EnvironmentVariables[variable] = value;
            return this;
        }
    }
}