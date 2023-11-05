//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

partial struct BitPatterns
{
    [MethodImpl(Inline), Op]
    public static BpDef pattern(string name, in BpExpr expr)
        => new (name, expr);

    public static BpDef pattern<P>()
        where P : unmanaged, IBitPattern<P>
            => pattern(typeof(P).Name, typeof(P).GetCustomAttribute<BitPatternAttribute>().Symbols ?? EmptyString);
}