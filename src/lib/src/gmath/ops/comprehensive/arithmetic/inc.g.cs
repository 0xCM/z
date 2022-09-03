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
        [MethodImpl(Inline), Inc, Closures(AllNumeric)]
        public static T inc<T>(T a)
            where T : unmanaged
                => inc_u(a);

        [MethodImpl(Inline), Inc, Closures(AllNumeric)]
        public static ref T inc<T>(ref T src)
            where T : unmanaged
        {
            src = inc(src);
            return ref src;
        }

        [MethodImpl(Inline)]
        static T inc_u<T>(T a)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return force<T>(math.inc(force<T,uint>(a)));
            else if(typeof(T) == typeof(ushort))
                return force<T>(math.inc(force<T,uint>(a)));
            else if(typeof(T) == typeof(uint))
                return force<T>(math.inc(uint32(a)));
            else if(typeof(T) == typeof(ulong))
                return force<T>(math.inc(uint64(a)));
            else
                return inc_i(a);
        }

        [MethodImpl(Inline)]
        static T inc_i<T>(T a)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return force<T>(math.inc(force<T,int>(a)));
            else if(typeof(T) == typeof(short))
                return force<T>(math.inc(force<T,int>(a)));
            else if(typeof(T) == typeof(int))
                 return generic<T>(math.inc(int32(a)));
            else if(typeof(T) == typeof(long))
                 return generic<T>(math.inc(int64(a)));
            else
                return gfp.inc(a);
        }
    }
}