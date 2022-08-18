//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public readonly partial struct ClrLiterals
    {
        const BindingFlags BF = ReflectionFlags.BF_All;

        const NumericKind Closure = Integers;
    }
}