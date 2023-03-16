//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Algs
    {
        [Op, Closures(Integers)]
        public static T[] points<T>(T x0, T x1, T step)
            where T : unmanaged
        {
            var min = @as<T,ulong>(x0);
            var max = @as<T,ulong>(x1);
            var inc = @as<T,ulong>(step);
            var count = (max - min)/inc;
            var buffer = sys.alloc<T>(count);
            fill_1(x0,x1,step,buffer);
            return buffer;
        }

       [MethodImpl(Inline), Op, Closures(Integers)]
       public static void i8<T>(T x0, T x1, T? step, Span<T> dst)
            where T : unmanaged
        {
            var min = Unsafe.As<T,sbyte>(ref x0);
            var max = Unsafe.As<T,sbyte>(ref x1);
            var _step = Unsafe.As<T?, sbyte?>(ref step) ??(sbyte)1;
            for(var i = min; i <= max; i += _step)
                Spans.seek(dst, i) = Unsafe.As<sbyte,T>(ref i);
        }

        [MethodImpl(Inline), Op, Closures(Integers)]
        public static void u8<T>(T x0, T x1, T? step, Span<T> dst)
            where T : unmanaged
        {
            var min = Unsafe.As<T,byte>(ref x0);
            var max = Unsafe.As<T,byte>(ref x1);
            var _step = Unsafe.As<T?,byte?>(ref step) ??(byte)1;
            for(var i = min; i <= max; i += _step)
                Spans.seek(dst, i) = Unsafe.As<byte,T>(ref i);
        }

        [MethodImpl(Inline), Op, Closures(Integers)]
        public static void i16<T>(T x0, T x1, T? step, Span<T> dst)
            where T : unmanaged
        {
            var min = Unsafe.As<T,short>(ref x0);
            var max = Unsafe.As<T,short>(ref x1);
            var _step = Unsafe.As<T?, short?>(ref step) ?? (short)1;
            for(var i = min; i <= max; i += _step)
                Spans.seek(dst, i) = Unsafe.As<short,T>(ref i);
        }

        [MethodImpl(Inline), Op, Closures(Integers)]
        public static void u16<T>(T x0, T x1, T? step, Span<T> dst)
            where T : unmanaged
        {
            var min = Unsafe.As<T,ushort>(ref x0);
            var max = Unsafe.As<T,ushort>(ref x1);
            var _step = Unsafe.As<T?, ushort?>(ref step) ?? (ushort)1;
            for(var i = min; i <= max; i += _step)
                Spans.seek(dst, i) = Unsafe.As<ushort,T>(ref i);
        }

        [MethodImpl(Inline), Op, Closures(Integers)]
        public static void i32<T>(T x0, T x1, T? step, Span<T> dst)
            where T : unmanaged
        {
            var min = Unsafe.As<T,int>(ref x0);
            var max = Unsafe.As<T,int>(ref x1);
            var _step = Unsafe.As<T?, int?>(ref step) ?? 1;
            for(var i = min; i <= max; i += _step)
                Spans.seek(dst, i) = Unsafe.As<int,T>(ref i);
        }

        [MethodImpl(Inline), Op, Closures(Integers)]
        public static void u32<T>(T x0, T x1, T? step, Span<T> dst)
            where T : unmanaged
        {
            var min = Unsafe.As<T,uint>(ref x0);
            var max = Unsafe.As<T,uint>(ref x1);
            var _step = Unsafe.As<T?, uint?>(ref step) ?? 1u;
            for(var i = min; i <= max; i += _step)
                Spans.seek(dst, i) = Unsafe.As<uint,T>(ref i);
        }

        [MethodImpl(Inline), Op, Closures(Integers)]
        public static void i64<T>(T x0, T x1, T? step, Span<T> dst)
            where T : unmanaged
        {
            var min = Unsafe.As<T,long>(ref x0);
            var max = Unsafe.As<T,long>(ref x1);
            var _step = Unsafe.As<T?, long?>(ref step) ?? 1L;
            for(var i = min; i <= max; i += _step)
                Spans.seek(dst,i) = Unsafe.As<long,T>(ref i);
        }

        [MethodImpl(Inline), Op, Closures(Integers)]
        public static void u64<T>(T x0, T x1, T? step, Span<T> dst)
            where T : unmanaged
        {
            var min = Unsafe.As<T,ulong>(ref x0);
            var max = Unsafe.As<T,ulong>(ref x1);
            var _step = Unsafe.As<T?,ulong?>(ref step) ?? 1ul;
            for(var i = min; i <= max; i += _step)
                Spans.seek(dst, i) = Unsafe.As<ulong,T>(ref i);
        }

        [MethodImpl(Inline), Op, Closures(Integers)]
        public static void u64<T>(T x0, T x1, T step, Span<T> dst)
            where T : unmanaged
        {
            var min = @as<T,ulong>(x0);
            var max = @as<T,ulong>(x1);
            var _step = @as<T,ulong>(step);
            for(var i=min; i<=max; i+=_step)
                Spans.seek(dst, i) = @as<ulong,T>(i);
        }

        [MethodImpl(Inline)]
        static void fill_1<T>(T x0, T x1, T step, Span<T> dst)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                i8(x0,x1,step,dst);
            else if(typeof(T) == typeof(byte))
                u8(x0,x1,step,dst);
            else if(typeof(T) == typeof(short))
                i16(x0,x1,step,dst);
            else if(typeof(T) == typeof(ushort))
                u16(x0,x1,step,dst);
            else
                fill_2(x0,x1,step,dst);
        }

        [MethodImpl(Inline)]
        static void fill_2<T>(T x0, T x1, T step, Span<T> dst)
            where T : unmanaged
        {
            if(typeof(T) == typeof(int))
                i32(x0,x1,step,dst);
            else if(typeof(T) == typeof(uint))
                u32(x0,x1,step,dst);
            else if(typeof(T) == typeof(long))
                i64(x0,x1,step,dst);
            else if(typeof(T) == typeof(ulong))
                u64(x0,x1,step,dst);
            else
                throw no<T>();
        }
    }
}