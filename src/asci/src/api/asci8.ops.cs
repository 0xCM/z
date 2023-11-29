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
    public static asci8 asci(N8 n, char src)
        => new asci8((ulong)src);

    [MethodImpl(Inline), Op]
    public static asci8 asci(N8 n, ReadOnlySpan<byte> src)
    {
        var length = (byte)min(available(src), asci8.Size);
        var storage = 0ul;
        var dst = bytes(storage);
        for(var i=0; i<length; i++)
            seek(dst,i) = skip(src,i);
        return new (storage);
    }

    [MethodImpl(Inline), Op]
    public static unsafe void copy(in asci8 src, ref byte dst)
        => @as<byte,ulong>(dst) = src.Storage;

    [MethodImpl(Inline)]
    public static ref readonly asci8 cast<A>(N8 n, in A src)
        where A : unmanaged, IByteSeq
            => ref @as<A,asci8>(src);

    /// <summary>
    /// Returns the index of the first source element that matches a specified value
    /// </summary>
    /// <param name="src">The source sequence</param>
    /// <param name="match">The value to match</param>
    [MethodImpl(Inline), Op]
    public static int index(in asci8 src, char match)
        => AsciSymbols.search(@byte(edit(src)), src.Capacity, (byte)match);

    /// <summary>
    /// Populates an asci target with a specified number of source characters
    /// </summary>
    /// <param name="src">The data source</param>
    /// <param name="count">The number of characters to encode</param>
    /// <param name="dst">The receiver</param>
    [MethodImpl(Inline), Op]
    public static asci8 encode(in char src, byte count, out asci8 dst)
    {
        dst = asci8.Null;
        ref var storage = ref @as<asci8,AsciCode>(dst);
        AsciSymbols.codes(src, (byte)count, ref storage);
        return dst;
    }

    /// <summary>
    /// Populates an 8-code asci block from the leading cells of a character span
    /// </summary>
    /// <param name="src">The data source</param>
    [MethodImpl(Inline), Op]
    public static asci8 encode(N8 n, ReadOnlySpan<char> src)
        => encode(src, out asci8 dst);

    /// <summary>
    /// Populates an 8-code asci block from the leading cells of a character span
    /// </summary>
    /// <param name="src">The data source</param>
    /// <param name="dst">The target block</param>
    [MethodImpl(Inline), Op]
    public static asci8 encode(ReadOnlySpan<char> src, out asci8 dst)
    {
        dst = default;
        AsciSymbols.codes(src, span<asci8,AsciCode>(ref dst));
        return dst;
    }

    [Op]
    public static asci8 trim(in asci8 src)
    {
        var data = sys.bytes(src);
        var l0 = (int)src.Length;
        var i0 = 0;
        var i1 = l0 - 1;
        for(var i=0; i<l0; i++)
        {
            ref readonly var b = ref skip(data,i);
            if(SQ.whitespace((AsciCode)b))
                i0++;
            else
                break;
        }
        for(var i=l0-1; i>=0; i--)
        {
            ref readonly var b = ref skip(data,i);
            if(SQ.whitespace((AsciCode)b))
                i1--;
            else
                break;
        }

        var l1 = i1 - i0;
        if(l0 != l1)
            return asci(n8, segment(data, i0, i1));
        else
            return src;
    }

    [MethodImpl(Inline), Op]
    public static C code(in asci8 src, Hex3Kind index)
        => (C)(src.Storage >> (byte)index);


    [MethodImpl(Inline), Op]
    public static void decode(in asci8 src, ref char dst)
    {
        var decoded = vcpu.vpmovzxbw(vcpu.vbytes(w128, src.Storage));
        vcpu.vstore(decoded.GetLower(), ref @as<char,ushort>(dst));
    }

    [MethodImpl(Inline), Op]
    public static asci8 render2(byte src, out asci8 dst)
    {
        dst = new asci8(
            BitRender.bitchar(src, 1),
            BitRender.bitchar(src, 0)
        );
        return dst;
    }

    /// <summary>
    /// Counts the number of characters that precede a null terminator, if any
    /// </summary>
    /// <param name="src">The asci source</param>
    [MethodImpl(Inline), Op]
    public static int length(in asci8 src)
        => foundnot(index(src, z8), src.Capacity);

    [MethodImpl(Inline), Op]
    public static string decode(in asci8 src)
        => sys.@string(slice(recover<char>(sys.bytes(vcpu.vlo(vcpu.vpmovzxbw(vcpu.vbytes(w128, src.Storage))))), 0, src.Length));

    [MethodImpl(Inline), Op]
    public static void decode(N8 n, ReadOnlySpan<byte> src, Span<char> dst)
        => vcpu.vstore(vcpu.vpmovzxbw(vcpu.v8u(vcpu.vscalar(w128, @as<ulong>(sys.first(src))))), ref @as<ushort>(sys.first(dst)));

    /// <summary>
    /// Presents the source content as a bytespan
    /// </summary>
    /// <param name="src">The data source</param>
    [MethodImpl(Inline), Op]
    public static Span<byte> bytes(in asci8 src)
        => sys.cover(@as<byte>(src.Storage), src.Length);

    [MethodImpl(Inline), Op]
    public static ref readonly asci8 view(N8 n, in ulong src)
        => ref @as<ulong,asci8>(src);

    [MethodImpl(Inline), Op]
    public static void store(in asci8 src, Span<char> dst)
        => decode(src, ref first(dst));

    [MethodImpl(Inline), Op]
    public static ReadOnlySpan<AsciSymbol> symbols(in asci8 src)
        => recover<AsciSymbol>(sys.bytes(src));

    [MethodImpl(Inline), Op]
    public static asci8 init(N8 n, C fill = C.Space)
        => new asci8(vgcpu.vlo64(vcpu.vbroadcast(w128, (byte)fill)));

    [MethodImpl(Inline), Op]
    public static asci8 init(N8 n, ReadOnlySpan<C> src)
        => new asci8(first(recover<C,asci8>(src)));

    [MethodImpl(Inline), Op]
    public static asci8 init(N8 n, ReadOnlySpan<byte> src)
        => view(n, first(recover<byte,uint>(src)));

    /// <summary>
    /// Returns the index of the first source element that matches a specified value
    /// </summary>
    /// <param name="src">The source sequence</param>
    /// <param name="match">The value to match</param>
    [MethodImpl(Inline), Op]
    public static int index(asci8 src, byte match)
        => AsciSymbols.search(@byte(edit(src)), src.Capacity, match);

    /// <summary>
    /// Returns the index of the first source element that matches a specified value
    /// </summary>
    /// <param name="src">The source sequence</param>
    /// <param name="match">The value to match</param>
    [MethodImpl(Inline), Op]
    public static int index(asci8 src, C match)
        => AsciSymbols.search(@byte(edit(src)), src.Capacity, (byte)match);

    [MethodImpl(Inline), Op]
    public static bool contains(asci8 src, char match)
        => AsciSymbols.contains(src, (AsciCharSym)match);

    [MethodImpl(Inline), Op]
    public static char @char(asci8 src, Hex3Kind index)
        => (char)code(src, index);

    /// <summary>
    /// Presents the leading source cell as a byte reference
    /// </summary>
    /// <param name="src">The data source</param>
    [MethodImpl(Inline), Op]
    public static ref byte @byte(in asci8 src)
        => ref @as<asci8,byte>(src);
}
