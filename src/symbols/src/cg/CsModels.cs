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
            => new SummaryComment(content);

         public static SwitchMap<S,T> @switch<S,T>(string name, S[] src, T[] dst)
            where S : unmanaged
            where T : unmanaged
                => new SwitchMap<S,T>(name,src,dst);

        [Op]
        public static CsFunc func(Identifier ret, Identifier name, CsOperand[] ops, params string[] body)
            => new CsFunc(ret, name, true, ops, body);

        [Op]
        public static CsOperand operand(Identifier type, Identifier name, params string[] mods)
            => new CsOperand(type, name, mods);
    }
}