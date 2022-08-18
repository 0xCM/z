//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [ApiHost, LiteralProvider]
    public readonly partial struct BitSeq
    {
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<uint1> bits(N1 n)
            => recover<byte,uint1>(W1);

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<uint2> bits(N2 n)
            => recover<byte,uint2>(W2);

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<uint3> bits(N3 n)
            => recover<byte,uint3>(W3);

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<uint4> bits(N4 n)
             => recover<byte,uint4>(W4);

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<uint5> bits(N5 n)
             => recover<byte,uint5>(W5);

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<uint6> bits(N6 n)
            => recover<byte,uint6>(W6);

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<uint7> bits(N7 n)
            => recover<byte,uint7>(W7);

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<uint8b> bits(N8 n)
             => recover<byte,uint8b>(W8);
    }
}