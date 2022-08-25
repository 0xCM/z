//-----------------------------------------------------------------------------
// Copyright   :  (c) Microsoft
// License     :  MIT
// Source      : Adapted from miengine/src/WindowsDebugLauncher/DebugLauncher.cs
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    public struct ExePipeOptions
    {
        public static ExePipeOptions init()
        {
            var dst = new ExePipeOptions();
            dst.PipeServer = ".";
            dst.StdInPipeName = EmptyString;
            dst.StdOutPipeName = EmptyString;
            dst.StdErrPipeName = EmptyString;
            dst.PidPipeName = EmptyString;
            dst.ExePath = FilePath.Empty;
            dst.ControllerName = "control";
            dst.ExeArgs = new();
            return dst;
        }

        public string PipeServer;

        public string StdInPipeName;

        public string StdOutPipeName;

        public string StdErrPipeName;

        public string PidPipeName;

        public FilePath ExePath;

        public string ControllerName;

        public List<string> ExeArgs;

        /// <summary>
        /// Ensures all parameters have been set
        /// </summary>
        public bool ValidateParameters()
        {
            return !(string.IsNullOrEmpty(PipeServer)
                || string.IsNullOrEmpty(StdInPipeName)
                || string.IsNullOrEmpty(StdOutPipeName)
                || string.IsNullOrEmpty(StdErrPipeName)
                || string.IsNullOrEmpty(PidPipeName)
                || ExePath.IsEmpty
                || string.IsNullOrEmpty(ControllerName)
                );
        }

        public string Format()
        {
            var dst = text.buffer();
            foreach (var arg in ExeArgs.ToList())
            {
                if(arg.Contains(' '))
                    dst.Append("\"" + arg + "\"");
                else
                    dst.Append(arg);

                dst.Append(' ');
            }

            return dst.Emit();
        }
    }
}