//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2023
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
        public struct ShimCode
        {
            public FilePath TargetPath;

            [MethodImpl(Inline)]
            public ShimCode(FilePath dst)
            {
                TargetPath = dst;
            }

            [MethodImpl(Inline)]
            public string Generate()
                => CodePattern;

            string Arg0
            {
                [MethodImpl(Inline)]
                get => TargetPath.Format(PathSeparator.BS);
            }

            string CodePattern => $@"
using System;
using System.Diagnostics;
using System.Linq;

class Program
{{
    public static int Main(string[] args)
    {{
        var arguments = string.Join("" "", args.Select(a => $""\""{{a}}\""""));
        var psi = new ProcessStartInfo
        {{
	        FileName = {Arg0},
	        UseShellExecute = false,
	        Arguments = arguments,
			CreateNoWindow = false,
        }};
        var process = Process.Start(psi);
		Console.CancelKeyPress += (s, e) => {{ e.Cancel = true; }};
        process.WaitForExit();
        return process.ExitCode;
    }}
}};
";
        }
}