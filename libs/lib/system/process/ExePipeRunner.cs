//-----------------------------------------------------------------------------
// Copyright   :  (c) Microsoft
// License     :  MIT
// Source      : Adapted from miengine/src/WindowsDebugLauncher/DebugLauncher.cs
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Text;

    using static core;

    public class ExePipeRunner
    {
        public static int run(string[] argv)
        {
            var options = ExePipeOptions.init();
            term.utf8encoding();

            foreach (var a in argv)
            {
                if (empty(a))
                {
                    continue;
                }

                switch (a)
                {
                    case "-h":
                    case "-?":
                    case "/?":
                    case "--help":
                        ShowHelp();
                        return 1;
                    case "--pauseForDebugger":
                        {
                            while (!Debugger.IsAttached)
                            {
                                Thread.Sleep(500);
                            }
                        }
                        break;
                    default:
                        if (a.StartsWith("--stdin=", StringComparison.OrdinalIgnoreCase))
                        {
                            string stdin = a.Substring("--stdin=".Length);
                            if (string.IsNullOrWhiteSpace(stdin))
                            {
                                GenerateError("--stdin");
                                return -1;
                            }
                            options.StdInPipeName = stdin;
                        }
                        else if (a.StartsWith("--stdout=", StringComparison.OrdinalIgnoreCase))
                        {
                            string stdout = a.Substring("--stdout=".Length);
                            if (string.IsNullOrWhiteSpace(stdout))
                            {
                                GenerateError("--stdout");
                                return -1;
                            }
                            options.StdOutPipeName = stdout;
                        }
                        else if (a.StartsWith("--stderr=", StringComparison.OrdinalIgnoreCase))
                        {
                            string stderr = a.Substring("--stderr=".Length);
                            if (string.IsNullOrWhiteSpace(stderr))
                            {
                                GenerateError("--stderr");
                                return -1;
                            }
                            options.StdErrPipeName = stderr;
                        }
                        else if (a.StartsWith("--pid=", StringComparison.OrdinalIgnoreCase))
                        {
                            string pid = a.Substring("--pid=".Length);
                            if (string.IsNullOrWhiteSpace(pid))
                            {
                                GenerateError("--pid");
                                return -1;
                            }
                            options.PidPipeName = pid;
                        }
                        else if (a.StartsWith("--dbgExe=", StringComparison.OrdinalIgnoreCase))
                        {
                            string dbgExe = a.Substring("--dbgExe=".Length);
                            if (String.IsNullOrEmpty(dbgExe) || !File.Exists(dbgExe))
                            {
                                GenerateError("--dbgExe");
                                return -1;
                            }
                            options.ExePath = FS.path(dbgExe);
                        }
                        else
                        {
                            options.ExeArgs.AddRange(ParseExeArgs(a));
                        }
                        break;
                }
            }

            if (!options.ValidateParameters())
            {
                term.error("One or more required values are missing.");
                ShowHelp();
                return -1;
            }

            using var launcher = new ExePipe();
            launcher.Run(options);
            return 0;
        }

        static void GenerateError(string flag)
        {
            term.error(FormattableString.Invariant($"Value for flag:'{flag}' is missing or incorrect."));
            ShowHelp();
        }

        /// <summary>
        /// Parse dbgargs for spaces and quoted strings
        /// </summary>
        static List<string> ParseExeArgs(string line)
        {
            var args = new List<string>();
            bool inQuotedString = false;
            bool isEscape = false;

            StringBuilder builder = new StringBuilder();
            foreach (char c in line)
            {
                if (isEscape)
                {
                    switch (c)
                    {
                        case 'n':
                            builder.Append('\n');
                            break;
                        case 'r':
                            builder.Append('\r');
                            break;
                        case '\\':
                            builder.Append('\\');
                            break;
                        case '"':
                            builder.Append('\"');
                            break;
                        case ' ':
                            builder.Append(' ');
                            break;
                        default:
                            throw new ArgumentException(FormattableString.Invariant($"Invalid escape sequence: \\{c}"));
                    }

                    isEscape = false;
                    continue;
                }

                if (c == '\\')
                {
                    isEscape = true;
                    continue;
                }

                if (!inQuotedString && c == '"')
                {
                    inQuotedString = true;
                    continue;
                }

                if (inQuotedString && c == '"')
                {
                    inQuotedString = false;
                    continue;
                }

                if (!inQuotedString && c == ' ')
                {
                    if (builder.Length > 0)
                    {
                        args.Add(builder.ToString());
                        builder.Clear();
                    }

                    continue;
                }

                builder.Append(c);
            }

            if (builder.Length > 0)
            {
                args.Add(builder.ToString());
            }

            return args;
        }

        public static void ShowHelp()
        {
            term.inform("WindowsDebugLauncher: Launching debuggers for use with MIEngine in a separate process.");
            term.inform("--stdin=<value>        '<value>' is NamedPipeName for debugger stdin");
            term.inform("--stdout=<value>       '<value>' is NamedPipeName for debugger stdout");
            term.inform("--stderr=<value>       '<value>' is NamedPipeName for debugger stderr");
            term.inform("--pid=<value>          '<value>' is NamedPipeName for debugger pid");
            term.inform("--dbgExe=<value>       '<value>' is the path to the debugger");
        }
    }
}