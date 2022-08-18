//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class TypeNats
    {
        /// <summary>
        /// Reveals the natural number in bijection with a parametric type natural
        /// </summary>
        /// <param name="n">The representative, used only for method invocation type inference</param>
        /// <typeparam name="K">The natural type</typeparam>
        [MethodImpl(Inline)]
        public static ulong value<K>(K n = default)
            where K : unmanaged, ITypeNat
        {
            if(typeof(K) == typeof(N0))
                return 0;
            else if(typeof(K) == typeof(N1))
                return 1;
            else if(typeof(K) == typeof(N2))
                return 2;
            else if(typeof(K) == typeof(N3))
                return 3;
            else if(typeof(K) == typeof(N4))
                return 4;
            else if(typeof(K) == typeof(N5))
                return 5;
            else if(typeof(K) == typeof(N6))
                return 6;
            else if(typeof(K) == typeof(N7))
                return 7;
            else
                return value_8(n);
        }

        [MethodImpl(Inline)]
        static ulong value_8<K>(K n = default)
            where K : unmanaged, ITypeNat
        {
            if(typeof(K) == typeof(N8))
                return 8;
            else if(typeof(K) == typeof(N9))
                return 9;
            else if(typeof(K) == typeof(N10))
                return 10;
            else if(typeof(K) == typeof(N11))
                return 11;
            else if(typeof(K) == typeof(N12))
                return 12;
            else if(typeof(K) == typeof(N13))
                return 13;
            else if(typeof(K) == typeof(N14))
                return 14;
            else if(typeof(K) == typeof(N15))
                return 15;
            else
                return value_16(n);
        }

        [MethodImpl(Inline)]
        static ulong value_16<K>(K n = default)
            where K : unmanaged, ITypeNat
        {
            if(typeof(K) == typeof(N16))
                return 16;
            else if(typeof(K) == typeof(N17))
                return 17;
            else if(typeof(K) == typeof(N18))
                return 18;
            else if(typeof(K) == typeof(N19))
                return 19;
            else if(typeof(K) == typeof(N20))
                return 20;
            else if(typeof(K) == typeof(N21))
                return 21;
            else if(typeof(K) == typeof(N22))
                return 22;
            else if(typeof(K) == typeof(N23))
                return 23;
            else
                return value_24(n);
        }

        [MethodImpl(Inline)]
        static ulong value_24<K>(K n = default)
            where K : unmanaged, ITypeNat
        {
            if(typeof(K) == typeof(N24))
                return 24;
            else if(typeof(K) == typeof(N25))
                return 25;
            else if(typeof(K) == typeof(N26))
                return 26;
            else if(typeof(K) == typeof(N27))
                return 27;
            else if(typeof(K) == typeof(N28))
                return 28;
            else if(typeof(K) == typeof(N29))
                return 29;
            else if(typeof(K) == typeof(N30))
                return 30;
            else if(typeof(K) == typeof(N31))
                return 31;
            else
                return value_32(n);
        }

        [MethodImpl(Inline)]
        static ulong value_32<K>(K n = default)
            where K : unmanaged, ITypeNat
        {
            if(typeof(K) == typeof(N32))
                return 32;
            else if(typeof(K) == typeof(N33))
                return 33;
            else if(typeof(K) == typeof(N34))
                return 34;
            else if(typeof(K) == typeof(N35))
                return 35;
            else if(typeof(K) == typeof(N36))
                return 36;
            else if(typeof(K) == typeof(N37))
                return 37;
            else if(typeof(K) == typeof(N38))
                return 38;
            else if(typeof(K) == typeof(N39))
                return 39;
            else
                return value_40(n);
        }

        [MethodImpl(Inline)]
        static ulong value_40<K>(K n = default)
            where K : unmanaged, ITypeNat
        {
            if(typeof(K) == typeof(N40))
                return 40;
            else if(typeof(K) == typeof(N41))
                return 41;
            else if(typeof(K) == typeof(N42))
                return 42;
            else if(typeof(K) == typeof(N43))
                return 43;
            else if(typeof(K) == typeof(N44))
                return 44;
            else if(typeof(K) == typeof(N45))
                return 45;
            else if(typeof(K) == typeof(N46))
                return 46;
            else if(typeof(K) == typeof(N47))
                return 47;
            else
                return value_48(n);
        }

        [MethodImpl(Inline)]
        static ulong value_48<K>(K n = default)
            where K : unmanaged, ITypeNat
        {
            if(typeof(K) == typeof(N48))
                return 48;
            else if(typeof(K) == typeof(N49))
                return 49;
            else if(typeof(K) == typeof(N50))
                return 50;
            else if(typeof(K) == typeof(N51))
                return 51;
            else if(typeof(K) == typeof(N52))
                return 52;
            else if(typeof(K) == typeof(N53))
                return 53;
            else if(typeof(K) == typeof(N54))
                return 54;
            else if(typeof(K) == typeof(N55))
                return 55;
            else
                return value_56(n);
        }

        [MethodImpl(Inline)]
        static ulong value_56<K>(K n = default)
            where K : unmanaged, ITypeNat
        {
            if(typeof(K) == typeof(N56))
                return 56;
            else if(typeof(K) == typeof(N57))
                return 57;
            else if(typeof(K) == typeof(N58))
                return 58;
            else if(typeof(K) == typeof(N59))
                return 59;
            else if(typeof(K) == typeof(N60))
                return 60;
            else if(typeof(K) == typeof(N61))
                return 61;
            else if(typeof(K) == typeof(N62))
                return 62;
            else if(typeof(K) == typeof(N63))
                return 63;
            else
                return value_64(n);
        }

        [MethodImpl(Inline)]
        static ulong value_64<K>(K n = default)
            where K : unmanaged, ITypeNat
        {
            if(typeof(K) == typeof(N64))
                return 64;
            else if(typeof(K) == typeof(N128))
                return 128;
            else if(typeof(K) == typeof(N256))
                return 256;
            else if(typeof(K) == typeof(N512))
                return 512;
            else if(typeof(K) == typeof(N1024))
                return 1024;
            else if(typeof(K) == typeof(N2048))
                return 2048;
            else if(typeof(K) == typeof(N4096))
                return 4096;
            else if(typeof(K) == typeof(N8192))
                return 8192;
            else
                return default(K).NatValue;
        }
    }
}