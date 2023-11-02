//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost, LiteralProvider]
    public readonly partial struct BitSeq
    {
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<num2> nbits(N2 n)
            => recover<byte,num2>(BitSeq.W2);

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<num3> nbits(N3 n)
            => recover<byte,num3>(BitSeq.W3);


        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<num2> bits(N2 n)
            => recover<byte,num2>(W2);

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<num3> bits(N3 n)
            => recover<byte,num3>(W3);

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