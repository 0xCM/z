//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static BitMaskLiterals;

    partial class BitMasks
    {
        [MethodImpl(Inline)]
        public static T index<N,T>(N n = default, T t = default)
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => index_lo<N,T>();

        [MethodImpl(Inline)]
        static T index_lo<N,T>()
            where N : unmanaged, ITypeNat
            where T : unmanaged
        {
            if(typeof(N) == typeof(N0))
                return index<T>(n0);
            else if(typeof(N) == typeof(N1))
                return index<T>(n1);
            else if(typeof(N) == typeof(N2))
                return index<T>(n2);
            else if(typeof(N) == typeof(N3))
                return index<T>(n3);
            else
                return index_hi<N,T>();
        }

        [MethodImpl(Inline)]
        static T index_hi<N,T>()
            where N : unmanaged, ITypeNat
            where T : unmanaged
        {
            if(typeof(N) == typeof(N4))
                return index<T>(n4);
            else if(typeof(N) == typeof(N5))
                return index<T>(n5);
            else if(typeof(N) == typeof(N6))
                return index<T>(n6);
            else if(typeof(N) == typeof(N7))
                return index<T>(n7);
            else
                throw no<N>();
        }

        [MethodImpl(Inline)]
        static T index<T>(N0 n)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(Index8x8x0);
            else if(typeof(T) == typeof(ushort))
                return generic<T>(Index16x8x0);
            else if(typeof(T) == typeof(uint))
                return generic<T>(Index32x8x0);
            else if(typeof(T) == typeof(ulong))
                return generic<T>(Index64x8x0);
            else
                throw no<T>();
        }

        [MethodImpl(Inline)]
        static T index<T>(N1 n)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(Index8x8x1);
            else if(typeof(T) == typeof(ushort))
                return generic<T>(Index16x8x1);
            else if(typeof(T) == typeof(uint))
                return generic<T>(Index32x8x1);
            else if(typeof(T) == typeof(ulong))
                return generic<T>(Index64x8x1);
            else
                throw no<T>();
        }

        [MethodImpl(Inline)]
        static T index<T>(N2 n)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(Index8x8x2);
            else if(typeof(T) == typeof(ushort))
                return generic<T>(Index16x8x2);
            else if(typeof(T) == typeof(uint))
                return generic<T>(Index32x8x2);
            else if(typeof(T) == typeof(ulong))
                return generic<T>(Index64x8x2);
            else
                throw no<T>();
        }

        [MethodImpl(Inline)]
        static T index<T>(N3 n)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(Index8x8x3);
            else if(typeof(T) == typeof(ushort))
                return generic<T>(Index16x8x3);
            else if(typeof(T) == typeof(uint))
                return generic<T>(Index32x8x3);
            else if(typeof(T) == typeof(ulong))
                return generic<T>(Index64x8x3);
            else
                throw no<T>();
        }

        [MethodImpl(Inline)]
        static T index<T>(N4 n)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(Index8x8x4);
            else if(typeof(T) == typeof(ushort))
                return generic<T>(Index16x8x4);
            else if(typeof(T) == typeof(uint))
                return generic<T>(Index32x8x4);
            else if(typeof(T) == typeof(ulong))
                return generic<T>(Index64x8x4);
            else
                throw no<T>();
        }

        [MethodImpl(Inline)]
        static T index<T>(N5 n)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(Index8x8x5);
            else if(typeof(T) == typeof(ushort))
                return generic<T>(Index16x8x5);
            else if(typeof(T) == typeof(uint))
                return generic<T>(Index32x8x5);
            else if(typeof(T) == typeof(ulong))
                return generic<T>(Index64x8x5);
            else
                throw no<T>();
        }

        [MethodImpl(Inline)]
        static T index<T>(N6 n)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(Index8x8x6);
            else if(typeof(T) == typeof(ushort))
                return generic<T>(Index16x8x6);
            else if(typeof(T) == typeof(uint))
                return generic<T>(Index32x8x6);
            else if(typeof(T) == typeof(ulong))
                return generic<T>(Index64x8x6);
            else
                throw no<T>();
        }

        [MethodImpl(Inline)]
        static T index<T>(N7 n)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(Index8x8x7);
            else if(typeof(T) == typeof(ushort))
                return generic<T>(Index16x8x7);
            else if(typeof(T) == typeof(uint))
                return generic<T>(Index32x8x7);
            else if(typeof(T) == typeof(ulong))
                return generic<T>(Index64x8x7);
            else
                throw no<T>();
        }
    }
}