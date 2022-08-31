//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct gcalc
    {
        [MethodImpl(Inline), Avg, Closures(AllNumeric)]
        public static T avg<T>(ReadOnlySpan<T> src, bool @checked)
            where T : unmanaged
                => avg_u(src,@checked);

        [MethodImpl(Inline), Avg, Closures(AllNumeric)]
        public static T avg<T>(ReadOnlySpan<T> src)
            where T : unmanaged
                => avg_u(src,true);

        [MethodImpl(Inline), Avg, Closures(AllNumeric)]
        public static T avg<T>(Span<T> src, bool @checked)
            where T : unmanaged
                => avg(src.ReadOnly(), @checked);

        [MethodImpl(Inline), Avg, Closures(AllNumeric)]
        public static T avg<T>(Span<T> src)
            where T : unmanaged
                => avg(src.ReadOnly(), true);

        [MethodImpl(Inline)]
        static T avg_u<T>(ReadOnlySpan<T> src, bool @checked)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(math.avg(uint8(src), @checked));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(math.avg(uint16(src)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(math.avg(uint32(src)));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(math.avg(uint64(src)));
            else
                return avg_i(src, @checked);
        }

        [MethodImpl(Inline)]
        static T avg_i<T>(ReadOnlySpan<T> src, bool @checked)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return generic<T>(math.avg(int8(src), @checked));
            else if(typeof(T) == typeof(short))
                return generic<T>(math.avg(int16(src), @checked));
            else if(typeof(T) == typeof(int))
                return generic<T>(math.avg(int32(src), @checked));
            else if(typeof(T) == typeof(long))
                return generic<T>(math.avg(int64(src), @checked));
            else
                return gcalc.favg(src, @checked);
        }
    }
}