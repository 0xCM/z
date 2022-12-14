//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmd
    {
        [CmdOp("llvm/check/types")]
        Outcome Test(CmdArgs args)
        {
            var result = Outcome.Success;

            @string a = "a";
            @string b = "b";
            @string c = "c";
            @string d = "d";

            var dag0 = dag.define(a,b);
            var dag1 = dag.define(dag0,c);
            var dag2 = dag.define(dag1,d);
            var expr1 = dag2.Format();
            dag.parse(expr1, out var dag3);
            var expr2 = dag3.Format();
            if(expr1 != expr2)
                result= (false,string.Format("{0} != {1}", expr1, expr2));
            else
                Write(expr2);
            return result;
        }
    }
}