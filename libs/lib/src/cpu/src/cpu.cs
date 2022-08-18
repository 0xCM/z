//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Root;

    [ApiHost]
    public readonly partial struct cpu
    {
        const NumericKind Closure = UnsignedInts;
    }

    [ApiHost]
    public readonly partial struct gcpu
    {
        const NumericKind Closure = UnsignedInts;
    }
}