//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using S = CmpPredSymbols;

    [SymSource(api_kinds)]
    public enum CmpPredKind : byte
    {
        None = 0,

        [Symbol(S.EQ)]
        EQ,

        [Symbol(S.LT)]
        LT,

        [Symbol(S.LE)]
        LE,

        [Symbol(S.NEQ)]
        NEQ,

        [Symbol(S.NLT)]
        NLT,

        [Symbol(S.NGT)]
        NGT,

        [Symbol(S.GT)]
        GT,

        [Symbol(S.GE)]
        GE
    }
}