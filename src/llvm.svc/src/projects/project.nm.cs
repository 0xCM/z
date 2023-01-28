//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class ProjectCmd
    {
        Tooling Tooling => Wf.Tooling();

        OmniScript OmniScript => Wf.OmniScript();

        [CmdOp("project/nm")]
        Outcome RunLlvmNm(CmdArgs args)
        {
            var result = Outcome.Success;
            var files = Project().Files().Where(f => f.Is(FS.Obj) || f.Is(FS.Dll) || f.Is(FS.Lib) || f.Is(FS.Exe)).View;
            var count = files.Length;
            var outdir = Project().BuildOut();
            var tool = Tooling.Home("llvm-nm");
            var script = tool.Script("run", FileKind.Cmd);
            for(var i=0; i<count; i++)
            {
                var src = skip(files,i);
                var dst = outdir + src.FileName.WithExtension(FS.Sym);
                var vars = CmdVars.load(
                    ("SrcPath", src.Format(PathSeparator.BS)),
                    ("DstPath", dst.Format(PathSeparator.BS))
                    );
                result = OmniScript.Run(script,vars, false, out _);
                if(result.Fail)
                    return result;
            }
            return result;
        }
    }
}