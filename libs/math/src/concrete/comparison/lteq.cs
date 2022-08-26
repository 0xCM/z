//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    partial class math
    {
        [MethodImpl(Inline), LtEq]
        public static bit lteq(sbyte a, sbyte b)
            => a <= b;

        [MethodImpl(Inline), LtEq]
        public static bit lteq(byte a, byte b)
            => a <= b;

        [MethodImpl(Inline), LtEq]
        public static bit lteq(short a, short b)
            => a <= b;

        [MethodImpl(Inline), LtEq]
        public static bit lteq(ushort a, ushort b)
            => a <= b;

        [MethodImpl(Inline), LtEq]
        public static bit lteq(int a, int b)
            => a <= b;

        [MethodImpl(Inline), LtEq]
        public static bit lteq(uint a, uint b)
            => a <= b;

        [MethodImpl(Inline), LtEq]
        public static bit lteq(long a, long b)
            => a <= b;

        [MethodImpl(Inline), LtEq]
        public static bit lteq(ulong a, ulong b)
            => a <= b;
    }
}