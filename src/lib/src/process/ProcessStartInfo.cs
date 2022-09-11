//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using S = System.Diagnostics.ProcessStartInfo;
    using A = ProcessStartSpec;

    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Versioning;

    using static sys;

    public sealed class ProcessStartSpec : Adapter<A,S>
    {
        public ProcessStartSpec()
        {

        }

        public ProcessStartSpec(S src)
            : base(src)
        {
            
        }

        public static A adapt(S src)
            => new (src);

        [MethodImpl(Inline)]
        public static implicit operator A(S subject)
            => new A(subject);

        [MethodImpl(Inline)]
        public static implicit operator S(A src)
            => src.Subject;

        public string Format()
            => $"{TargetPath.Format(PathSeparator.BS)} {Arguments}";

        public override string ToString()
            => Format();

        //
        // Summary:
        //     Gets a collection of command-line arguments to use when starting the application.
        //     Strings added to the list don't need to be previously escaped.
        //
        // Returns:
        //     A collection of command-line arguments.
        public ReadOnlySeq<string> ArgumentList
            => Subject.ArgumentList.Array();

        //
        // Summary:
        //     Gets or sets the set of command-line arguments to use when starting the application.
        //
        // Returns:
        //     A single string containing the arguments to pass to the target application specified
        //     in the System.Diagnostics.ProcessStartInfo.FileName property. The default is
        //     an empty string ("").
        public @string Arguments
        {
            get => Subject.Arguments ?? EmptyString;
            set => Subject.Arguments = value.IsEmpty ? null : value.Format();
        }

        //
        // Summary:
        //     Gets or sets a value indicating whether to start the process in a new window.
        //
        // Returns:
        //     true if the process should be started without creating a new window to contain
        //     it; otherwise, false. The default is false.
        public bool CreateNoWindow
        {
            get => Subject.CreateNoWindow;
            set => Subject.CreateNoWindow = value;
        }

        //
        // Summary:
        //     Gets or sets a value that identifies the domain to use when starting the process.
        //     If this value is null, the System.Diagnostics.ProcessStartInfo.UserName property
        //     must be specified in UPN format.
        //
        // Returns:
        //     The Active Directory domain to use when starting the process. If this value is
        //     null, the System.Diagnostics.ProcessStartInfo.UserName property must be specified
        //     in UPN format.
        [SupportedOSPlatform("windows")]
        public @string Domain
        {
            get => Subject.Domain ?? EmptyString;
            set => Subject.Domain = value.IsEmpty ? null : value.Format();
        }

        public ReadOnlySeq<EnvVar<string>> Environment()
            => Subject.Environment.Map(x => new EnvVar<string>(x.Key,x.Value));
        
        public void Environment(ReadOnlySeq<EnvVar<string>> src)
            => iter(src, var => Subject.Environment[var.Name] = var.Value);

        //
        // Summary:
        //     Gets the environment variables that apply to this process and its child processes.
        //
        // Returns:
        //     A generic dictionary containing the environment variables that apply to this
        //     process and its child processes. The default is null.
        // public IDictionary<string, string?> Environment
        // {
        //     get => Subject.Environment;        
        // }

        // public StringDictionary EnvironmentVariables
        // {
        //     get => Subject.EnvironmentVariables;
        // }

        //
        // Summary:
        //     Gets or sets the application or document to start.
        //
        // Returns:
        //     The name of the application to start, or the name of a document of a file type
        //     that is associated with an application and that has a default open action available
        //     to it. The default is an empty string ("").
        public FilePath TargetPath
        {
            get => text.empty(Subject.FileName) ? FileUri.Empty : new (Subject.FileName);
            set => Subject.FileName = value.IsEmpty ? null : value.Format(PathSeparator.BS);
        }

        //
        // Summary:
        //     Gets or sets a value that indicates whether the error output of an application
        //     is written to the System.Diagnostics.Process.StandardError stream.
        //
        // Returns:
        //     true if error output should be written to System.Diagnostics.Process.StandardError;
        //     otherwise, false. The default is false.
        public bool RedirectStandardError
        {
            get => Subject.RedirectStandardError;
            set => Subject.RedirectStandardError = value;
        }

        //
        // Summary:
        //     Gets or sets a value indicating whether the input for an application is read
        //     from the System.Diagnostics.Process.StandardInput stream.
        //
        // Returns:
        //     true if input should be read from System.Diagnostics.Process.StandardInput; otherwise,
        //     false. The default is false.
        public bool RedirectStandardInput
        {
            get => Subject.RedirectStandardInput;
            set => Subject.RedirectStandardInput = value;
        }

        //
        // Summary:
        //     Gets or sets a value that indicates whether the textual output of an application
        //     is written to the System.Diagnostics.Process.StandardOutput stream.
        //
        // Returns:
        //     true if output should be written to System.Diagnostics.Process.StandardOutput;
        //     otherwise, false. The default is false.
        public bool RedirectStandardOutput
        {
            get => Subject.RedirectStandardOutput;
            set => Subject.RedirectStandardOutput = value;
        }

        //
        // Summary:
        //     Gets or sets the preferred encoding for error output.
        //
        // Returns:
        //     An object that represents the preferred encoding for error output. The default
        //     is null.
        public TextEncoding StandardErrorEncoding
        {
            get => Subject.StandardErrorEncoding ?? TextEncoding.Default;
            set => Subject.StandardErrorEncoding = value;
        }

        //
        // Summary:
        //     Gets or sets the preferred encoding for standard input.
        //
        // Returns:
        //     An object that represents the preferred encoding for standard input. The default
        //     is null.
        public TextEncoding StandardInputEncoding
        {
            get => Subject.StandardInputEncoding ?? TextEncoding.Default;
            set => Subject.StandardInputEncoding = value;
        }

        //
        // Summary:
        //     Gets or sets the preferred encoding for standard output.
        //
        // Returns:
        //     An object that represents the preferred encoding for standard output. The default
        //     is null.
        public TextEncoding StandardOutputEncoding
        {
            get => Subject.StandardOutputEncoding ?? TextEncoding.Default;
            set => Subject.StandardOutputEncoding = value;
        }

        //
        // Summary:
        //     Gets or sets a value that indicates whether the Windows user profile is to be
        //     loaded from the registry.
        //
        // Returns:
        //     true if the Windows user profile should be loaded; otherwise, false. The default
        //     is false.
        [SupportedOSPlatform("windows")]
        public bool LoadUserProfile
        {
            get => Subject.LoadUserProfile;
            set => Subject.LoadUserProfile = value;
        }

        //
        // Summary:
        //     When the System.Diagnostics.ProcessStartInfo.UseShellExecute property is false,
        //     gets or sets the working directory for the process to be started. When System.Diagnostics.ProcessStartInfo.UseShellExecute
        //     is true, gets or sets the directory that contains the process to be started.
        //
        // Returns:
        //     When System.Diagnostics.ProcessStartInfo.UseShellExecute is true, the fully qualified
        //     name of the directory that contains the process to be started. When the System.Diagnostics.ProcessStartInfo.UseShellExecute
        //     property is false, the working directory for the process to be started. The default
        //     is an empty string ("").
        public FolderPath WorkingDirectory
        {
            get => new(Subject.WorkingDirectory);
            [param: AllowNull]
            set => Subject.WorkingDirectory = value.Format();
        }

        //
        // Summary:
        //     Gets or sets the verb to use when opening the application or document specified
        //     by the System.Diagnostics.ProcessStartInfo.FileName property.
        //
        // Returns:
        //     The action to take with the file that the process opens. The default is an empty
        //     string (""), which signifies no action.
        public @string Verb
        {
            get => Subject.Verb ?? EmptyString;
            [param: AllowNull]
            set => Subject.Verb = value.IsEmpty ? null : value.Format();
        }

        //
        // Summary:
        //     Gets the set of verbs associated with the type of file specified by the System.Diagnostics.ProcessStartInfo.FileName
        //     property.
        //
        // Returns:
        //     The actions that the system can apply to the file indicated by the System.Diagnostics.ProcessStartInfo.FileName
        //     property.
        public ReadOnlySeq<string> Verbs
            => Subject.Verbs;

        /*

        //
        // Summary:
        //     Gets search paths for files, directories for temporary files, application-specific
        //     options, and other similar information.
        //
        // Returns:
        //     A string dictionary that provides environment variables that apply to this process
        //     and child processes. The default is null.
        [Editor("System.Diagnostics.Design.StringDictionaryEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]

        //
        // Summary:
        //     Gets or sets a value indicating whether an error dialog box is displayed to the
        //     user if the process cannot be started.
        //
        // Returns:
        //     true if an error dialog box should be displayed on the screen if the process
        //     cannot be started; otherwise, false. The default is false.
        public bool ErrorDialog
        {
            get
            {
                throw null;
            }
            set
            {
            }
        }

        //
        // Summary:
        //     Gets or sets the window handle to use when an error dialog box is shown for a
        //     process that cannot be started.
        //
        // Returns:
        //     A pointer to the handle of the error dialog box that results from a process start
        //     failure.
        public IntPtr ErrorDialogParentHandle
        {
            get
            {
                throw null;
            }
            set
            {
            }
        }



        //
        // Summary:
        //     Gets or sets a secure string that contains the user password to use when starting
        //     the process.
        //
        // Returns:
        //     The user password to use when starting the process.
        [CLSCompliant(false)]
        [SupportedOSPlatform("windows")]
        public SecureString? Password
        {
            get
            {
                throw null;
            }
            set
            {
            }
        }

        //
        // Summary:
        //     Gets or sets the user password in clear text to use when starting the process.
        //
        // Returns:
        //     The user password in clear text.
        [SupportedOSPlatform("windows")]
        public string? PasswordInClearText
        {
            get
            {
                throw null;
            }
            set
            {
            }
        }

        //
        // Summary:
        //     Gets or sets the user name to use when starting the process. If you use the UPN
        //     format, user@DNS_domain_name, the System.Diagnostics.ProcessStartInfo.Domain
        //     property must be null.
        //
        // Returns:
        //     The user name to use when starting the process. If you use the UPN format, user@DNS_domain_name,
        //     the System.Diagnostics.ProcessStartInfo.Domain property must be null.
        public string UserName
        {
            get
            {
                throw null;
            }
            [param: AllowNull]
            set
            {
            }
        }

        //
        // Summary:
        //     Gets or sets a value indicating whether to use the operating system shell to
        //     start the process.
        //
        // Returns:
        //     true if the shell should be used when starting the process; false if the process
        //     should be created directly from the executable file. The default is true on .NET
        //     Framework apps and false on .NET Core apps.
        //
        // Exceptions:
        //   T:System.PlatformNotSupportedException:
        //     An attempt to set the value to true on Universal Windows Platform (UWP) apps
        //     occurs.
        public bool UseShellExecute
        {
            get
            {
                throw null;
            }
            set
            {
            }
        }


        //
        // Summary:
        //     Gets or sets the window state to use when the process is started.
        //
        // Returns:
        //     One of the enumeration values that indicates whether the process is started in
        //     a window that is maximized, minimized, normal (neither maximized nor minimized),
        //     or not visible. The default is Normal.
        //
        // Exceptions:
        //   T:System.ComponentModel.InvalidEnumArgumentException:
        //     The window style is not one of the System.Diagnostics.ProcessWindowStyle enumeration
        //     members.
        [DefaultValue(ProcessWindowStyle.Normal)]
        public ProcessWindowStyle WindowStyle
        {
            get
            {
                throw null;
            }
            set
            {
            }
        }

        */
    }
}