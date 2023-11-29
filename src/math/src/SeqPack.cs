//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

[ApiHost,Free]
public class SeqPack
{
    [MethodImpl(Inline), Op, Closures(Integers)]
    public static T packseq<T>(ReadOnlySpan<byte> src, out T dst)
        where T : unmanaged
    {
        if(typeof(T) == typeof(byte) || typeof(T) == typeof(sbyte))
            dst = generic<T>(packseq(src, out byte _));
        else if(typeof(T) == typeof(ushort) || typeof(T) == typeof(short))
            dst = generic<T>(packseq(src, out ushort _));
        else if(typeof(T) == typeof(uint) || typeof(T) == typeof(int))
            dst = generic<T>(packseq(src, out uint _));
        else if(typeof(T) == typeof(ulong) || typeof(T) == typeof(long))
            dst = generic<T>(packseq(src, out ulong _));
        else
            throw no<T>();

        return dst;
    }

    [MethodImpl(Inline), Op, Closures(Integers)]
    public static T packseq2<T>(ReadOnlySpan<byte> src, out T dst)
        where T : unmanaged
    {
        if(size<T>() == 1)
            dst = generic<T>(packseq(src, out byte _));
        else if(size<T>() == 2)
            dst = generic<T>(packseq(src, out ushort _));
        else if(size<T>() == 4)
            dst = generic<T>(packseq(src, out uint _));
        else if(size<T>() == 8)
            dst = generic<T>(packseq(src, out ulong _));
        else
            throw no<T>();

        return dst;
    }

    /// <summary>
    /// Packs a bitsequence determined by the first 8 (or fewer) bytes from the source into a single byte
    /// </summary>
    /// <param name="src">The source sequence</param>
    [MethodImpl(Inline), Op]
    static byte packseq(ReadOnlySpan<byte> src, out byte dst)
    {
        dst = z8;
        var count = math.min(8, src.Length);
        for(byte i=0; i<count; i++)
            if(skip(src, i) == 1)
                dst |= (byte)(1 << i);
        return dst;
    }

    /// <summary>
    /// Packs a bitsequence determined by the first 16 (or fewer) bytes from the source into an unsigned short
    /// </summary>
    /// <param name="src">The source sequence</param>
    [MethodImpl(Inline), Op]
    static ushort packseq(ReadOnlySpan<byte> src, out ushort dst)
    {
        dst = z16;
        var count = math.min(16, src.Length);
        for(byte i=0; i<count; i++)
            if(skip(src, i) == 1)
                dst |= (ushort)(1 << i);
        return dst;
    }

    /// <summary>
    /// Packs a bitsequence determined by the first 32 (or fewer) bytes from the source into an unsigned int
    /// </summary>
    /// <param name="src">The source sequence</param>
    [MethodImpl(Inline), Op]
    static uint packseq(ReadOnlySpan<byte> src, out uint dst)
    {
        dst = z32;
        var count = math.min(32, src.Length);
        for(byte i=0; i<count; i++)
            if(skip(src, i) == 1)
                dst |= (1u << i);
        return dst;
    }

    /// <summary>
    /// Packs a bitsequence determined by the first 64 (or fewer) bytes from the source into an unsigned long
    /// </summary>
    /// <param name="src">The source sequence</param>
    [MethodImpl(Inline), Op]
    static ulong packseq(ReadOnlySpan<byte> src, out ulong dst)
    {
        dst = z64;
        var count = math.min(64, src.Length);
        for(byte i=0; i<count; i++)
            if(skip(src, i) == 1)
                dst |= (1ul << i);
        return dst;
    }        
}
