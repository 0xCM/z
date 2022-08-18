//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public partial class sys : sys<sys>
    {
        const NumericKind Closure = Integers;

        const string EmptyString = "";

        internal const MethodImplOptions Options = MethodImplOptions.AggressiveInlining;
    }
}