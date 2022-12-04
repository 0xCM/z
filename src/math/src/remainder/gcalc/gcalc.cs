//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public readonly partial struct gcalc
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline)]
        static IEnumerable<T> range_1<T>(T x0, T x1, T? step = null)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return range8i(x0,x1,step);
            else if(typeof(T) == typeof(byte))
                return range8u(x0,x1,step);
            else if(typeof(T) == typeof(short))
                return range16i(x0,x1,step);
            else if(typeof(T) == typeof(ushort))
                return range16u(x0,x1,step);
            else
                return range_2(x0,x1,step);
        }

        [MethodImpl(Inline)]
        static IEnumerable<T> range_2<T>(T x0, T x1, T? step = null)
            where T : unmanaged
        {
            if(typeof(T) == typeof(int))
                return range32i(x0,x1,step);
            else if(typeof(T) == typeof(uint))
                return range32u(x0,x1,step);
            else if(typeof(T) == typeof(long))
                return range64i(x0,x1,step);
            else if(typeof(T) == typeof(ulong))
                return range64u(x0,x1,step);
            else
                return range_3(x0,x1,step);
        }

        [MethodImpl(Inline)]
        static IEnumerable<T> range_3<T>(T x0, T x1, T? step = null)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return range32f(x0,x1,step);
            else if(typeof(T) == typeof(double))
                return range64f(x0,x1,step);
            else
                throw no<T>();
        }

        static IEnumerable<T> range8i<T>(T x0, T x1, T? step = null)
            where T : unmanaged
        {
            var min = Unsafe.As<T,sbyte>(ref x0);
            var max = Unsafe.As<T,sbyte>(ref x1);
            var _step = Unsafe.As<T?,sbyte?>(ref step) ??(sbyte)1;
            for(var i = min; i <= max; i += _step)
                yield return Unsafe.As<sbyte,T>(ref i);
        }

        static IEnumerable<T> range8u<T>(T x0, T x1, T? step = null)
            where T : unmanaged
        {
            var min = Unsafe.As<T,byte>(ref x0);
            var max = Unsafe.As<T,byte>(ref x1);
            var _step = Unsafe.As<T?, byte?>(ref step) ??(byte)1;
            for(var i = min; i <= max; i += _step)
                yield return Unsafe.As<byte,T>(ref i);
        }

        static IEnumerable<T> range16i<T>(T x0, T x1, T? step = null)
            where T : unmanaged
        {
            var min = Unsafe.As<T,short>(ref x0);
            var max = Unsafe.As<T,short>(ref x1);
            var _step = Unsafe.As<T?, short?>(ref step) ?? (short)1;
            for(var i = min; i <= max; i += _step)
                yield return Unsafe.As<short,T>(ref i);
        }

        static IEnumerable<T> range16u<T>(T x0, T x1, T? step = null)
            where T : unmanaged
        {
            var min = Unsafe.As<T,ushort>(ref x0);
            var max = Unsafe.As<T,ushort>(ref x1);
            var _step = Unsafe.As<T?, ushort?>(ref step) ?? (ushort)1;
            for(var i = min; i <= max; i += _step)
                yield return Unsafe.As<ushort,T>(ref i);
        }

        static IEnumerable<T> range32i<T>(T x0, T x1, T? step = null)
            where T : unmanaged
        {
            var min = Unsafe.As<T,int>(ref x0);
            var max = Unsafe.As<T,int>(ref x1);
            var _step = Unsafe.As<T?, int?>(ref step) ?? 1;
            for(var i = min; i <= max; i += _step)
                yield return Unsafe.As<int,T>(ref i);
        }

        static IEnumerable<T> range32u<T>(T x0, T x1, T? step = null)
            where T : unmanaged
        {
            var min = Unsafe.As<T,uint>(ref x0);
            var max = Unsafe.As<T,uint>(ref x1);
            var _step = Unsafe.As<T?, uint?>(ref step) ?? 1u;
            for(var i = min; i <= max; i += _step)
                yield return Unsafe.As<uint,T>(ref i);
        }

        static IEnumerable<T> range64i<T>(T x0, T x1, T? step = null)
            where T : unmanaged
        {
            var min = Unsafe.As<T,long>(ref x0);
            var max = Unsafe.As<T,long>(ref x1);
            var _step = Unsafe.As<T?, long?>(ref step) ?? 1L;
            for(var i = min; i <= max; i += _step)
                yield return Unsafe.As<long,T>(ref i);
        }

        static IEnumerable<T> range64u<T>(T x0, T x1, T? step = null)
            where T : unmanaged
        {
            var min = Unsafe.As<T,ulong>(ref x0);
            var max = Unsafe.As<T,ulong>(ref x1);
            var _step = Unsafe.As<T?, ulong?>(ref step) ?? 1ul;
            for(var i = min; i <= max; i += _step)
                yield return Unsafe.As<ulong,T>(ref i);
        }

        static IEnumerable<T> range32f<T>(T x0, T x1, T? step = null)
            where T : unmanaged
        {
            var min = Unsafe.As<T,float>(ref x0);
            var max = Unsafe.As<T,float>(ref x1);
            var _step = Unsafe.As<T?, float?>(ref step) ?? 1f;
            for(var i = min; i <= max; i += _step)
                yield return Unsafe.As<float,T>(ref i);
        }

        static IEnumerable<T> range64f<T>(T x0, T x1, T? step = null)
            where T : unmanaged
        {
            var min = Unsafe.As<T,double>(ref x0);
            var max = Unsafe.As<T,double>(ref x1);
            var _step = Unsafe.As<T?, double?>(ref step) ?? 1d;
            for(var i = min; i <= max; i += _step)
                yield return Unsafe.As<double,T>(ref i);
        }
    }
}