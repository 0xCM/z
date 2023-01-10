//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct Hex
    {
        public static uint bitstring<N>(HexVector8<N> src, uint i, Span<char> dst, N count = default)
            where N : unmanaged, ITypeNat
                => BitRender.render8x8(bytes(src.View), i, dst, count);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<char> render<T>(UpperCased @case, T value)
            where T : unmanaged
                => chars_u(@case, value);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void render<T>(UpperCased @case, T value, uint offset, Span<char> dst)
            where T : unmanaged
                => chars_u(@case, value, offset, dst);

        [MethodImpl(Inline)]
        static ReadOnlySpan<char> chars_u<T>(UpperCased @case, T value)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return render(@case, uint8(value));
            else if(typeof(T) == typeof(ushort))
                return render(@case, int16(value));
            else if(typeof(T) == typeof(uint))
                return render(@case, uint32(value));
            else if(typeof(T) == typeof(ulong))
                return render(@case, uint64(value));
            else
                return chars_i(@case, value);
        }

        [MethodImpl(Inline)]
        static ReadOnlySpan<char> chars_i<T>(UpperCased @case, T value)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return render(@case, int8(value));
            else if(typeof(T) == typeof(short))
                return render(@case, int16(value));
            else if(typeof(T) == typeof(int))
                return render(@case, int32(value));
            else if(typeof(T) == typeof(long))
                return render(@case, int64(value));
            else
                throw no<T>();
        }

        [MethodImpl(Inline)]
        static void chars_u<T>(UpperCased @case, T value, uint offset, Span<char> dst)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                render(@case, uint8(value), offset, dst);
            else if(typeof(T) == typeof(ushort))
                render(@case, uint16(value), offset, dst);
            else if(typeof(T) == typeof(uint))
                render(@case, uint32(value), offset, dst);
            else if(typeof(T) == typeof(ulong))
                render(@case, uint64(value), offset, dst);
            else
                chars_i(@case, value, offset, dst);
        }

        [MethodImpl(Inline)]
        static void chars_i<T>(UpperCased @case, T value, uint offset, Span<char> dst)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                render(@case, int8(value), offset, dst);
            else if(typeof(T) == typeof(short))
                render(@case, int16(value), offset, dst);
            else if(typeof(T) == typeof(int))
                render(@case, int32(value), offset, dst);
            else if(typeof(T) == typeof(long))
                render(@case, int64(value), offset, dst);
            else
                throw no<T>();
        }
    }
}