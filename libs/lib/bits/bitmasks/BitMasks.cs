//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public partial class BitMasks
    {
        const NumericKind Closure = UnsignedInts;

        public static string[] names()
            => typeof(BitMaskLiterals).LiteralFields().Select(x => x.Name);
    }
}