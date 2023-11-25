//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

partial struct Hex
{
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static void render<T>(UpperCased @case, T value, uint offset, Span<char> dst)
        where T : unmanaged
            => chars_u(@case, value, offset, dst);

    [MethodImpl(Inline), Op, Closures(Closure)]
    public static void render<T>(LowerCased @case, T value, uint offset, Span<char> dst)
        where T : unmanaged
            => chars_u(@case, value, offset, dst);

    [MethodImpl(Inline)]
    static void chars_u<T>(LowerCased @case, T value, uint offset, Span<char> dst)
        where T : unmanaged
    {
        if(typeof(T) == typeof(byte))
            HexRender.render(@case, uint8(value), offset, dst);
        else if(typeof(T) == typeof(ushort))
            HexRender.render(@case, uint16(value), offset, dst);
        else if(typeof(T) == typeof(uint))
            HexRender.render(@case, uint32(value), offset, dst);
        else if(typeof(T) == typeof(ulong))
            HexRender.render(@case, uint64(value), offset, dst);
        else
            chars_i(@case, value, offset, dst);
    }

    [MethodImpl(Inline)]
    static void chars_i<T>(LowerCased @case, T value, uint offset, Span<char> dst)
        where T : unmanaged
    {
        if(typeof(T) == typeof(sbyte))
            HexRender.render(@case, int8(value), offset, dst);
        else if(typeof(T) == typeof(short))
            HexRender.render(@case, int16(value), offset, dst);
        else if(typeof(T) == typeof(int))
            HexRender.render(@case, int32(value), offset, dst);
        else if(typeof(T) == typeof(long))
            HexRender.render(@case, int64(value), offset, dst);
        else
            throw no<T>();
    }

    [MethodImpl(Inline)]
    static void chars_u<T>(UpperCased @case, T value, uint offset, Span<char> dst)
        where T : unmanaged
    {
        if(typeof(T) == typeof(byte))
            HexRender.render(@case, uint8(value), offset, dst);
        else if(typeof(T) == typeof(ushort))
            HexRender.render(@case, uint16(value), offset, dst);
        else if(typeof(T) == typeof(uint))
            HexRender.render(@case, uint32(value), offset, dst);
        else if(typeof(T) == typeof(ulong))
            HexRender.render(@case, uint64(value), offset, dst);
        else
            chars_i(@case, value, offset, dst);
    }

    [MethodImpl(Inline)]
    static void chars_i<T>(UpperCased @case, T value, uint offset, Span<char> dst)
        where T : unmanaged
    {
        if(typeof(T) == typeof(sbyte))
            HexRender.render(@case, int8(value), offset, dst);
        else if(typeof(T) == typeof(short))
            HexRender.render(@case, int16(value), offset, dst);
        else if(typeof(T) == typeof(int))
            HexRender.render(@case, int32(value), offset, dst);
        else if(typeof(T) == typeof(long))
            HexRender.render(@case, int64(value), offset, dst);
        else
            throw no<T>();
    }
}
