//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static TypeNats;

    partial class NatCalc
    {
        [MethodImpl(Inline)]
        public static T rotr<T,K1,K2>(K1 k1 = default, K2 k2 = default, T zero = default)
            where T : unmanaged
            where K1 : unmanaged, ITypeNat
            where K2 : unmanaged, ITypeNat
        {
            if(typeof(T) == typeof(byte))
            {
                var result = (byte)rotrN<N8,K1,K2>();
                return Unsafe.As<byte,T>(ref result);
            }
            else if(typeof(T) == typeof(ushort))
            {
                var result = (ushort)rotrN<N16,K1,K2>();
                return Unsafe.As<ushort,T>(ref result);
            }
            else if(typeof(T) == typeof(uint))
            {
                var result = (uint)rotrN<N32,K1,K2>();
                return Unsafe.As<uint,T>(ref result);
            }
            else if(typeof(T) == typeof(ulong))
            {
                var result = (ulong)rotrN<N64,K1,K2>();
                return Unsafe.As<ulong,T>(ref result);
            }
            else
                return default(T);
        }

        [MethodImpl(Inline)]
        static ulong rotrN<K3,K1,K2>(K1 k1 = default, K2 k2 = default, K3 k3 = default)
            where K3 : unmanaged, ITypeNat
            where K1 : unmanaged, ITypeNat
            where K2 : unmanaged, ITypeNat
                => (ulong)srl(k1,k2) |  (value(k1) << (int)sub(k3,k2));

    }
}