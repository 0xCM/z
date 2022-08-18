//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;
    using static Numeric;

    partial class gmath
    {
        [MethodImpl(Inline), Dec, Closures(Integers)]
        public static T dec<T>(T a)
            where T : unmanaged
                => dec_u(a);

        [MethodImpl(Inline), Inc, Closures(AllNumeric)]
        public static ref T dec<T>(ref T src)
            where T : unmanaged
        {
            src = dec(src);
            return ref src;
        }

        [MethodImpl(Inline)]
        static T dec_u<T>(T a)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return force<T>(math.dec(force<T,uint>(a)));
            else if(typeof(T) == typeof(ushort))
                return force<T>(math.dec(force<T,uint>(a)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(math.dec(uint32(a)));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(math.dec(uint64(a)));
            else
                return dec_i(a);
        }

        [MethodImpl(Inline)]
        static T dec_i<T>(T a)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return force<T>(math.dec(force<T,int>(a)));
            else if(typeof(T) == typeof(short))
                return force<T>(math.dec(force<T,int>(a)));
            else if(typeof(T) == typeof(int))
                 return generic<T>(math.dec(int32(a)));
            else if(typeof(T) == typeof(long))
                 return generic<T>(math.dec(int64(a)));
            else
                return gfp.dec(a);
        }
    }
}