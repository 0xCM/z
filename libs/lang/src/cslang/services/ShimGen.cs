//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;
    using System.IO;

    using static CsModels;

    public class ShimGen
    {
        public static ref ToolShimSpec bind(CmdArgs args, out ToolShimSpec dst)
        {
            dst.ShimName = Cmd.arg(args,0).Value;
            dst.ShimPath = FS.dir(Cmd.arg(args,1)) + FS.file(dst.ShimName,FileKind.Exe);
            dst.TargetPath = FS.path(Cmd.arg(args,2));
            return ref dst;
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
            var refs = CsCode.perefs(typeof(object), typeof(Enumerable), typeof(ProcessStartInfo));
            var code = new ShimCode(config.ShimPath);
            return CsCode.compilation(config.ShimName.Format(), refs, CsCode.parse(code.Generate()));
        }
    }
}