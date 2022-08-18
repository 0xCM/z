//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ProjectCmd
    {
        [CmdOp("project/mc/syntax")]
        Outcome McSyntax(CmdArgs args)
        {
            var src = AsmObjects.CalcSyntaxOps(Project().ProjectId);
            var count = src.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var syntax = ref src[i];
                Write(string.Format("{0,-8} | {1,-64} | {2}", syntax.Row.Seq, syntax.Row.Asm, syntax.Ops.Delimit(Chars.Space)));
            }

            return true;
        }
    }
}