//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

using C = AsciCode;

partial struct Asci
{
    [MethodImpl(Inline), Op]
    public static string decode(asci32 src)
    {
        var lo = vpack.vinflatelo256x16u(src.Storage);
        var hi = vpack.vinflatehi256x16u(src.Storage);
        return new(slice(recover<char>(sys.bytes(new V256x2(lo,hi))), 0, src.Length));
    }

    [MethodImpl(Inline), Op]
    public static void decode(asci32 src, ref char dst)
    {
        decode(src.Lo, ref dst);
        decode(src.Hi, ref seek(dst, 16));
    }

    [MethodImpl(Inline)]
    public static ref readonly asci32 cast<A>(N32 n, in A src)
        where A : unmanaged, IByteSeq
            => ref @as<A,asci32>(src);

    [MethodImpl(Inline), Op]
    public static unsafe void copy(in asci32 src, Span<byte> dst)
        => vcpu.vstore(src.Storage, dst);

    [MethodImpl(Inline), Op]
    public static unsafe void copy(in asci32 src, ref byte dst)
        => vcpu.vstore(src.Storage, ref dst);

    [MethodImpl(Inline), Op]
    public static C code(in asci32 src, Hex5Kind index)
        => (C)skip(bytes(src), (byte)index);

    [MethodImpl(Inline), Op]
    public static asci32 init(N32 n, AsciCode fill = AsciCode.Space)
        => new (vcpu.vbroadcast(w256, (byte)fill));

    [MethodImpl(Inline), Op]
    public static asci32 init(N32 n, ReadOnlySpan<AsciCode> src)
        => new (recover<AsciCode,byte>(src));

    /// <summary>
    /// Populates an asci target with a specified number of source characters
    /// </summary>
    /// <param name="src">The data source</param>
    /// <param name="count">The number of characters to encode</param>
    /// <param name="dst">The receiver</param>
    [MethodImpl(Inline), Op]
    public static asci32 encode(in char src, byte count, out asci32 dst)
    {
        dst = asci32.Null;
        ref var storage = ref @as<asci32,AsciCode>(dst);
        AsciSymbols.codes(src, (byte)count, ref storage);
        return dst;
    }

    /// <summary>
    /// Populates a 32-code asci block from the leading cells of a character span
    /// </summary>
    /// <param name="src">The data source</param>
    /// <param name="dst">The target block</param>
    [MethodImpl(Inline), Op]
    public static asci32 encode(ReadOnlySpan<char> src, out asci32 dst)
    {
        dst = asci32.Spaced;
        AsciSymbols.codes(src, span<asci32,AsciCode>(ref dst));
        return dst;
    }

    /// <summary>
    /// Populates a 32-code asci block from the leading cells of a character span
    /// </summary>
    /// <param name="src">The data source</param>
    [MethodImpl(Inline), Op]
    public static asci32 encode(N32 n, ReadOnlySpan<char> src)
        => encode(src, out asci32 dst);

    /// <summary>
    /// Presents the source content as a bytespan
    /// </summary>
    /// <param name="src">The data source</param>
    [MethodImpl(Inline), Op]
    public static Span<byte> bytes(in asci32 src)
        => src.Storage.ToSpan();

    /// <summary>
    /// Presents the leading source cell as a byte reference
    /// </summary>
    /// <param name="src">The data source</param>
    [MethodImpl(Inline), Op]
    public static ref byte @byte(in asci32 src)
        => ref @as<asci32,byte>(src);

    [MethodImpl(Inline), Op]
    public static bool contains(in asci32 src, char match)
        => AsciSymbols.contains(src, (AsciCharSym)match);

    /// <summary>
    /// Returns the index of the first source element that matches a specified value
    /// </summary>
    /// <param name="src">The source sequence</param>
    /// <param name="match">The value to match</param>
    [MethodImpl(Inline), Op]
    public static int index(in asci32 src, char match)
        => AsciSymbols.search(@byte(edit(src)), src.Capacity, (byte)match);

    /// <summary>
    /// Returns the index of the first source element that matches a specified value
    /// </summary>
    /// <param name="src">The source sequence</param>
    /// <param name="match">The value to match</param>
    [MethodImpl(Inline), Op]
    public static int index(in asci32 src, byte match)
        => AsciSymbols.search(@byte(edit(src)), src.Capacity, match);

    /// <summary>
    /// Returns the index of the first source element that matches a specified value
    /// </summary>
    /// <param name="src">The source sequence</param>
    /// <param name="match">The value to match</param>
    [MethodImpl(Inline), Op]
    public static int index(in asci32 src, AsciCode match)
        => AsciSymbols.search(@byte(edit(src)), src.Capacity, (byte)match);

    /// <summary>
    /// Counts the number of characters that precede a null terminator, if any
    /// </summary>
    /// <param name="src">The asci source</param>
    [MethodImpl(Inline), Op]
    public static int length(in asci32 src)
        => foundnot(index(src, z8), src.Capacity);
}
