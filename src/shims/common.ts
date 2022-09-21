export type Args = '{Args}'
export type ShimPath = '{ShimPath}'

export type Template =`
using System;
using System.Diagnostics;

class Program
{{
    static T[] map<T>(T[] src, Func<T,T> f)
    {{
        var dst = new T[src.Length];
        for(var i=0; i<src.Length; i++)
            dst[i] = f(src[i]);
        return dst;
    }}

    public static int Main(string[] args)
    {{
        var arguments = string.Join("" "", map(args, a => $""\""{{a}}\"""")));
        var psi = new ProcessStartInfo
        {{
	        FileName = {compileReadyShimPath},
	        UseShellExecute = false,
	        Arguments = arguments,
			CreateNoWindow = false,
        }};
        var process = Process.Start(psi);
		Console.CancelKeyPress += (s, e) => {{ e.Cancel = true; }};
        process.WaitForExit();
        return process.ExitCode;
    }}
}}
`