//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public readonly partial struct CsModels
    {
        [Op]
        public static SummaryComment comment(string content)
            => new (content);


        [Op]
        public static CsFunc func(Identifier ret, Identifier name, CsOperand[] ops, params string[] body)
            => new (ret, name, true, ops, body);

        [Op]
        public static CsOperand operand(Identifier type, Identifier name, params string[] mods)
            => new (type, name, mods);
    }
}