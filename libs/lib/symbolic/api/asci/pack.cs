//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;
    using static Spans;

    using static AsciSymbols;
    using static AsciChars;

    using C = AsciCode;
    using S = AsciSymbol;

    partial struct Asci
    {
        [MethodImpl(Inline), Op]
        public static ref uint pack(C c0, C c1, C c2, out uint dst)
        {
            dst = (uint)c0 | ((uint)c1 << 8) | (uint)c2 << 16;
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref uint pack(C c0, C c1, C c2, C c3, out uint dst)
        {
            dst = (uint)c0 | ((uint)c1 << 8) | (uint)c2 << 16 | (uint)c3 << 24;
            return ref dst;
        }
    }
}