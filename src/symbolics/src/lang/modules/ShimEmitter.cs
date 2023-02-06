//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;
    using System.IO;

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
    public class ShimEmitter
    {

        public static ToolShimSpec bind(CmdArgs args, out ToolShimSpec dst)
        {
            dst.ShimName = CmdArgs.arg(args,0).Value;
            dst.ShimPath = FS.dir(CmdArgs.arg(args,1)) + FS.file(dst.ShimName,FileKind.Exe);
            dst.TargetPath = FS.path(CmdArgs.arg(args,2));
            return dst;
        }

        public static EmitResult gen(ToolShimSpec spec)
        {
            var compile = compilation(spec);
            var dst = spec.ShimPath.EnsureParentExists();
            using (var exe = new FileStream(dst.Name, FileMode.Create))
            using (var resources = compile.CreateDefaultWin32Resources(true, true, null, null))
                return compile.Emit(exe, win32Resources: resources);
        }

        static CSharpCompilation compilation(ToolShimSpec config)
        {
            Require.invariant(config.TargetPath.Exists, () => $"The file {config.TargetPath}, it must exist");
            var refs = CsLang.perefs(typeof(object), typeof(Enumerable), typeof(ProcessStartInfo));
            var code = new ShimCode(config.ShimPath);
            return CsLang.compilation(config.ShimName.Format(), refs, CsLang.parse(code.Generate()));
        }
    }
}