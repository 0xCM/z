//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using System.Globalization;

using static sys;

partial struct Hex
{
    public static Outcome<uint> parse(string src, out HexArray16 dst)
    {
        dst = HexArray16.Empty;
        return hexbytes(src, bytes(dst));
    }

    public static bool parse64u(string src, out ulong dst)
        => ulong.TryParse(HexParser.clear(src), NumberStyles.HexNumber, null,  out dst);

    public static bool parse32u(string src, out uint dst)
        => uint.TryParse(HexParser.clear(src), NumberStyles.HexNumber, null,  out dst);

    public static bool parse16u(string src, out ushort dst)
        => ushort.TryParse(HexParser.clear(src), NumberStyles.HexNumber, null, out dst);

    public static bool parse8u(string src, out byte dst)
        => byte.TryParse(HexParser.clear(src), NumberStyles.HexNumber, null, out dst);

    public static bool parse8i(string src, out sbyte dst)
        => sbyte.TryParse(HexParser.clear(src), NumberStyles.HexNumber, null, out dst);

    public static bool parse16i(string src, out short dst)
        => short.TryParse(HexParser.clear(src), NumberStyles.HexNumber, null, out dst);

    public static bool parse32i(string src, out int dst)
        => int.TryParse(HexParser.clear(src), NumberStyles.HexNumber, null, out dst);

    public static bool parse64i(string src, out long dst)
        => long.TryParse(HexParser.clear(src), NumberStyles.HexNumber, null, out dst);

    public static bool parse8u(ReadOnlySpan<char> src, out byte dst)
        => byte.TryParse(HexParser.clear(src), NumberStyles.HexNumber, null,  out dst);

    public static bool parse16u(ReadOnlySpan<char> src, out ushort dst)
        => ushort.TryParse(HexParser.clear(src), NumberStyles.HexNumber, null,  out dst);

    public static bool parse32u(ReadOnlySpan<char> src, out uint dst)
        => uint.TryParse(HexParser.clear(src), NumberStyles.HexNumber, null,  out dst);

    public static bool parse64u(ReadOnlySpan<char> src, out ulong dst)
        => ulong.TryParse(HexParser.clear(src), NumberStyles.HexNumber, null,  out dst);

    /// <summary>
    /// Parses a nibble
    /// </summary>
    /// <param name="src">The source character</param>
    [MethodImpl(Inline), Op]
    public static bool parse(char src, out byte dst)
        => parse((AsciCode)src, out dst);

    [MethodImpl(Inline), Op]
    public static bool parse(char c0, char c1, out byte dst)
    {
        if(parse(c0, out byte d0) && parse(c1, out byte d1))
        {
            dst = (byte)((d0 << 4) | d1);
            return true;
        }
        dst = 0;
        return false;
    }

    [Op]
    public static Outcome<uint> parse(ReadOnlySpan<char> src, Span<byte> dst)
    {
        var counter = 0u;
        var input = src;

        var j = text.index(src, Chars.x);
        var k = text.index(src, Chars.h);

        if(j > 0)
            input = right(input,j);
        if(k > 0)
            input = left(input, k);

        var hi = byte.MaxValue;
        for(var i=0; i<input.Length; i++)
        {
            ref readonly var c = ref skip(input,i);
            if(HexTest.fence(c) || HexTest.separator(c) || HexTest.postfix(c))
                continue;

            if(i < input.Length - 2)
            {
                if(HexTest.prefix(c, skip(input, i+1)))
                {
                    i++;
                    continue;
                }
            }

            if(parse(c, out HexDigitValue d))
            {
                if(hi == byte.MaxValue)
                    hi = (byte)d;
                else
                {
                    var lo = (byte)d;
                    seek(dst, counter++) = or(sll(hi,4), lo);
                    hi = byte.MaxValue;
                }
            }
            else
                return false;
        }
        return (true,counter);
    }

    [MethodImpl(Inline), Op]
    public static bool parse(char src, out HexDigitValue dst)
        => parse((AsciCode)src, out dst);

    [MethodImpl(Inline), Op]
    public static bool parse(LowerCased @case, char c, out HexDigitValue dst)
        => parse(@case, (AsciCode)c, out dst);

    [MethodImpl(Inline), Op]
    public static bool parse(UpperCased @case, char c, out HexDigitValue dst)
        => parse(@case, (AsciCode)c, out dst);

    /// <summary>
    /// Parses a nibble
    /// </summary>
    /// <param name="c">The source character</param>
    [MethodImpl(Inline), Op]
    public static bool parse(UpperCased @case, char c, out byte dst)
        => parse(@case, (AsciCode)c, out dst);

    /// <summary>
    /// Parses a nibble
    /// </summary>
    /// <param name="c">The source character</param>
    [MethodImpl(Inline), Op]
    public static bool parse(LowerCased @case, char c, out byte dst)
        => parse(@case, (AsciCode)c, out dst);

    [MethodImpl(Inline), Op]
    public static bool parse(UpperCased @case, char c0, char c1, out byte dst)
    {
        var result = parse(@case, c0, out byte d0);
        result &= parse(@case, c1, out byte d1);
        if(result)
            dst = (byte)((d0 << 4) | d1);
        else
            dst = 0;
        return result;
    }

    [MethodImpl(Inline), Op]
    public static bool parse(LowerCased @case, char c0, char c1, out byte dst)
    {
        var result = parse(@case, c0, out byte d0);
        result &= parse(@case, c1, out byte d1);
        if(result)
            dst = (byte)((d0 << 4) | d1);
        else
            dst = 0;
        return result;
    }

    // [Op]
    // public static bool parse(UpperCased @case, ReadOnlySpan<char> src, out BinaryCode dst)
    // {
    //     var result = true;
    //     var count = src.Length;
    //     dst = BinaryCode.Empty;
    //     var size = count/2;
    //     if(count % 2 != 0)
    //         return false;
    //     var buffer = alloc<byte>(size);
    //     for(int i=0, j=0; i<count; i+=2, j++)
    //     {
    //         result = parse(@case, skip(src,i), skip(src, i+1), out seek(buffer, j));
    //         if(!result)
    //             break;
    //     }

    //     dst = buffer;
    //     return result;
    // }

    // [Op]
    // public static bool parse(LowerCased @case, ReadOnlySpan<char> src, out BinaryCode dst)
    // {
    //     var result = true;
    //     var count = src.Length;
    //     dst = BinaryCode.Empty;
    //     var size = count/2;
    //     if(count % 2 != 0)
    //         return false;
    //     var buffer = alloc<byte>(size);
    //     for(int i=0, j=0; i<count; i+=2, j++)
    //     {
    //         result = parse(@case, skip(src,i), skip(src, i+1), out seek(buffer, j));
    //         if(!result)
    //             break;
    //     }

    //     dst = buffer;
    //     return result;
    // }

    // [Op]
    // public static uint data(ReadOnlySpan<char> src, uint offset, Span<byte> dst)
    // {
    //     var counter = offset;
    //     var count = (uint)src.Length;
    //     ref var target = ref first(dst);
    //     var hi = byte.MaxValue;
    //     for(var i=0; i<count; i++)
    //     {
    //         ref readonly var c = ref skip(src,i);
    //         if(HexTest.fence(c) || HexTest.separator(c))
    //             continue;

    //         if(parse(c, out HexDigitValue d))
    //         {
    //             if(hi == byte.MaxValue)
    //                 hi = (byte)d;
    //             else
    //             {
    //                 var lo = (byte)d;
    //                 seek(target, counter++) = or(sll(hi,4), lo);
    //                 hi = byte.MaxValue;
    //             }
    //         }
    //         else
    //         {
    //             count = 0;
    //             break;
    //         }
    //     }
    //     return offset - counter;
    // }

}
