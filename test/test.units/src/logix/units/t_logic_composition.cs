//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Logix
{
    using static BitLogicSpec;
    using static LogixEngine;

    public class t_logic_composition : t_logix<t_logic_composition>
    {
        public void test1()
        {

            var a = literal<uint>(true);
            var b = literal<uint>(false);
            var c = and(a,b);
            var result = eval(c);
            Claim.nea(result);
        }
    }
}