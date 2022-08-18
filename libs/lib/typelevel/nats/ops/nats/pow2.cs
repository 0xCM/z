//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class NatCalc
    {
        /// <summary>
        /// Computes k := 2^n - 1
        /// </summary>
        /// <param name="n">The power of 2 exponent, between 0 and 64</param>
        /// <typeparam name="K">The exponent type</typeparam>
        [MethodImpl(Inline)]
        public static ulong pow2m1<K>(K n = default)
            where K : unmanaged, ITypeNat
        {
            if(typeof(K) == typeof(N64))
                return ulong.MaxValue;
            else
                return pow2(n) - 1ul;
        }

        /// <summary>
        /// Computes k := 2^n
        /// </summary>
        /// <param name="n">The power of 2 exponent, between 0 and 63</param>
        /// <typeparam name="K">The exponent type</typeparam>
        [MethodImpl(Inline)]
        public static ulong pow2<K>(K n = default)
            where K : unmanaged, ITypeNat
        {
            if(typeof(K) == typeof(N0))
                return 1ul;
            else if(typeof(K) == typeof(N1))
                return 1ul << 1;
            else if(typeof(K) == typeof(N2))
                return 1ul << 2;
            else if(typeof(K) == typeof(N3))
                return 1ul << 3;
            else if(typeof(K) == typeof(N4))
                return 1ul << 4;
            else if(typeof(K) == typeof(N5))
                return 1ul << 5;
            else if(typeof(K) == typeof(N6))
                return 1ul << 6;
            else if(typeof(K) == typeof(N7))
                return 1ul << 7;
            else
                return pow2_8(n);
        }

        [MethodImpl(Inline)]
        static ulong pow2_8<K>(K n = default)
            where K : unmanaged, ITypeNat
        {
            if(typeof(K) == typeof(N8))
                return 1ul << 8;
            else if(typeof(K) == typeof(N9))
                return 1ul << 9;
            else if(typeof(K) == typeof(N10))
                return 1ul << 10;
            else if(typeof(K) == typeof(N11))
                return 1ul << 11;
            else if(typeof(K) == typeof(N12))
                return 1ul << 12;
            else if(typeof(K) == typeof(N13))
                return 1ul << 13;
            else if(typeof(K) == typeof(N14))
                return 1ul << 14;
            else if(typeof(K) == typeof(N15))
                return 1ul << 15;
            else
                return pow2_16(n);
        }

        [MethodImpl(Inline)]
        static ulong pow2_16<K>(K n = default)
            where K : unmanaged, ITypeNat
        {
            if(typeof(K) == typeof(N16))
                return 1ul << 16;
            else if(typeof(K) == typeof(N17))
                return 1ul << 17;
            else if(typeof(K) == typeof(N18))
                return 1ul << 18;
            else if(typeof(K) == typeof(N19))
                return 1ul << 19;
            else if(typeof(K) == typeof(N20))
                return 1ul << 20;
            else if(typeof(K) == typeof(N21))
                return 1ul << 21;
            else if(typeof(K) == typeof(N22))
                return 1ul << 22;
            else if(typeof(K) == typeof(N23))
                return 1ul << 23;
            else
                return pow2_24(n);
        }

        [MethodImpl(Inline)]
        static ulong pow2_24<K>(K n = default)
            where K : unmanaged, ITypeNat
        {
            if(typeof(K) == typeof(N24))
                return 1ul << 24;
            else if(typeof(K) == typeof(N25))
                return 1ul << 25;
            else if(typeof(K) == typeof(N26))
                return 1ul << 26;
            else if(typeof(K) == typeof(N27))
                return 1ul << 27;
            else if(typeof(K) == typeof(N28))
                return 1ul << 28;
            else if(typeof(K) == typeof(N29))
                return 1ul << 29;
            else if(typeof(K) == typeof(N30))
                return 1ul << 30;
            else if(typeof(K) == typeof(N31))
                return 1ul << 31;
            else
                return pow2_32(n);
        }

        [MethodImpl(Inline)]
        static ulong pow2_32<K>(K n = default)
            where K : unmanaged, ITypeNat
        {
            if(typeof(K) == typeof(N32))
                return 1ul << 32;
            else if(typeof(K) == typeof(N33))
                return 1ul << 33;
            else if(typeof(K) == typeof(N34))
                return 1ul << 34;
            else if(typeof(K) == typeof(N35))
                return 1ul << 35;
            else if(typeof(K) == typeof(N36))
                return 1ul << 36;
            else if(typeof(K) == typeof(N37))
                return 1ul << 37;
            else if(typeof(K) == typeof(N38))
                return 1ul << 38;
            else if(typeof(K) == typeof(N39))
                return 1ul << 39;
            else
                return pow2_40(n);
        }

        [MethodImpl(Inline)]
        static ulong pow2_40<K>(K n = default)
            where K : unmanaged, ITypeNat
        {
            if(typeof(K) == typeof(N40))
                return 1ul << 40;
            else if(typeof(K) == typeof(N41))
                return 1ul << 41;
            else if(typeof(K) == typeof(N42))
                return 1ul << 42;
            else if(typeof(K) == typeof(N43))
                return 1ul << 43;
            else if(typeof(K) == typeof(N44))
                return 1ul << 44;
            else if(typeof(K) == typeof(N45))
                return 1ul << 45;
            else if(typeof(K) == typeof(N46))
                return 1ul << 46;
            else if(typeof(K) == typeof(N47))
                return 1ul << 47;
            else
                return pow2_48(n);
        }

        [MethodImpl(Inline)]
        static ulong pow2_48<K>(K n = default)
            where K : unmanaged, ITypeNat
        {
            if(typeof(K) == typeof(N48))
                return 1ul << 48;
            else if(typeof(K) == typeof(N49))
                return 1ul << 49;
            else if(typeof(K) == typeof(N50))
                return 1ul << 50;
            else if(typeof(K) == typeof(N51))
                return 1ul << 51;
            else if(typeof(K) == typeof(N52))
                return 1ul << 52;
            else if(typeof(K) == typeof(N53))
                return 1ul << 53;
            else if(typeof(K) == typeof(N54))
                return 1ul << 54;
            else if(typeof(K) == typeof(N55))
                return 1ul << 55;
            else
                return pow2_56(n);
        }

        [MethodImpl(Inline)]
        static ulong pow2_56<K>(K n = default)
            where K : unmanaged, ITypeNat
        {
            if(typeof(K) == typeof(N56))
                return 1ul << 56;
            else if(typeof(K) == typeof(N57))
                return 1ul << 57;
            else if(typeof(K) == typeof(N58))
                return 1ul << 58;
            else if(typeof(K) == typeof(N59))
                return 1ul << 59;
            else if(typeof(K) == typeof(N60))
                return 1ul << 60;
            else if(typeof(K) == typeof(N61))
                return 1ul << 61;
            else if(typeof(K) == typeof(N62))
                return 1ul << 62;
            else if(typeof(K) == typeof(N63))
                return 1ul << 63;
            else
                return 0;
        }
    }
}