//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

[ApiHost]
public readonly struct NatSpans
{
    /// <summary>
    /// Fills a target block with replicated cell data
    /// </summary>
    /// <param name="data">The data used to fill the block</param>
    /// <param name="dst">The target block</param>
    /// <typeparam name="T">The cell type</typeparam>
    [MethodImpl(Inline)]
    public static void broadcast<N,T>(T data, in NatSpan<N,T> dst)
        where N : unmanaged, ITypeNat
        where T : unmanaged
            => dst.Edit.Fill(data);

    /// <summary>
    /// Allocates span of natural length
    /// </summary>
    /// <param name="n">The cell count representative</param>
    /// <param name="t">A cell type representative</param>
    /// <typeparam name="N">The cell count type</typeparam>
    /// <typeparam name="T">The cell data type</typeparam>
    public static NatSpan<N,T> alloc<N,T>(N n = default, T t = default)
        where N : unmanaged, ITypeNat
        where T : unmanaged
            => new NatSpan<N,T>(alloc<T>(nat64u<N>()));

    [MethodImpl(Inline)]
    public static void fill<N,T>(in NatSpan<N,T> dst, T data)
        where N : unmanaged, ITypeNat
        where T : unmanaged
            => broadcast(data, dst);

    [MethodImpl(Inline)]
    public static NatSpan<N,T> parts<N,T>(N n, params T[] cells)
        where N : unmanaged, ITypeNat
        where T : unmanaged
            => load(cells,n);

    /// <summary>
    /// Loads a bytespan of natural length 16 from a generic source span
    /// </summary>
    /// <param name="src">The source span</param>
    /// <typeparam name="T">The source value type</typeparam>
    [MethodImpl(Inline), Op, Closures(AllNumeric)]
    public static NatSpan<N16,byte> bytes<T>(Span<T> src, N16 n)
        where T : unmanaged
            => NatSpans.load(sys.bytes(src), n);

    /// <summary>
    /// Loads a bytespan of natural length from a generic source span
    /// </summary>
    /// <param name="src">The source span</param>
    /// <typeparam name="T">The source value type</typeparam>
    [MethodImpl(Inline)]
    public static NatSpan<N,byte> bytes<N,T>(Span<T> src, N n = default)
        where T : unmanaged
        where N : unmanaged, ITypeNat
            => NatSpans.load(sys.bytes(src),n);

    [MethodImpl(Inline)]
    public static NatSpan<N,T> load<N,T>(T[] src, N n = default)
        where T : unmanaged
        where N : unmanaged, ITypeNat
    {
        Require.invariant(src.Length >= (int)nat64u<N>(), () => $"The source length {src.Length} >= N := {nat64u<N>()}");
        return new NatSpan<N,T>(src);
    }

    [MethodImpl(Inline)]
    public static NatSpan<N,T> load<N,T>(Span<T> src, N n = default)
        where T : unmanaged
        where N : unmanaged, ITypeNat
    {
        var len = src.Length;
        Require.invariant(len >= nat32i<N>(), () => $"The source length {len} >= N := {nat64u<N>()}");
        return new NatSpan<N,T>(src);
    }

    /// <summary>
    /// Loads a natural block from a reference
    /// </summary>
    /// <param name="src">The source reference</param>
    /// <param name="n">The length representative</param>
    /// <typeparam name="N">The length type</typeparam>
    /// <typeparam name="T">The cell type</typeparam>
    [MethodImpl(Inline)]
    public static NatSpan<N,T> load<N,T>(in T src, N n = default)
        where N : unmanaged, ITypeNat
        where T : unmanaged
            => new NatSpan<N,T>(cover(src, (int)nat64u<N>()));

    /// <summary>
    /// Clones a natural span
    /// </summary>
    /// <param name="src">The source span</param>
    /// <typeparam name="T">The element type</typeparam>
    public static NatSpan<N,T> replicate<N,T>(in NatSpan<N,T> src)
        where N : unmanaged, ITypeNat
        where T : unmanaged
    {
        Span<T> dst = new T[TypeNats.value<N>()];
        copy(src, dst);
        return new NatSpan<N,T>(dst);
    }

    [MethodImpl(Inline)]
    public static Span<T> slice<N,T>(in NatSpan<N,T> src, int offset)
        where N : unmanaged, ITypeNat
        where T : unmanaged
            => src.Edit.Slice(offset);

    [MethodImpl(Inline)]
    public static Span<T> slice<N,T>(in NatSpan<N,T> src, int offset, int length)
        where N : unmanaged, ITypeNat
        where T : unmanaged
            => src.Edit.Slice(offset, length);

    [MethodImpl(Inline)]
    public static void copy<N,T>(in NatSpan<N,T> src, Span<T> dst)
        where N : unmanaged, ITypeNat
        where T : unmanaged
            => src.Edit.CopyTo(dst);

    [MethodImpl(Inline), Op]
    public static uint hash(NatSpanSig src)
        => (((uint)(ushort)src.Length) | ((uint)src.CellWidth) << 16) | ((uint)src.Indicator << 28);

    [MethodImpl(Inline), Op]
    public static bool eq(NatSpanSig a, NatSpanSig b)
        => @as<NatSpanSig,ulong>(a) == @as<NatSpanSig,ulong>(b);

    [Op]
    public static string format(NatSpanSig src)
        => string.Concat(IDI.Nat, src.Length.ToString(), IDI.SegSep, src.CellWidth.ToString(), src.Indicator);

    [MethodImpl(Inline), Op]
    public static NatSpanSig sig(uint length, ushort cellwidth, AsciCharSym indicator)
        => new NatSpanSig(length, cellwidth, indicator);

    [Op]
    public static ParseResult<NatSpanSig> sig(string src)
    {
        var parts = src.Split(IDI.SegSep);
        var fail = ParseResult.unparsed<NatSpanSig>(src);
        if(parts.Length == 2)
        {
            var part1 = parts[0];
            var part2 = parts[1];
            var n = z32;
            var w = z16;
            var indicator = AsciCharSym.Null;
            if(part1[0] == IDI.Nat)
            {
                var number =  part1.TakeAfter(IDI.Nat);
                uint.TryParse(number, out n);

                var digits = string.Empty;
                foreach(var c in part2)
                {
                    if(Char.IsDigit(c))
                        digits += c;
                    else
                    {
                        indicator = (AsciCharSym)c;
                        break;
                    }
                }

                if(digits.IsNotBlank())
                    ushort.TryParse(digits, out w);
            }

            if(n != 0 && w != 0 && indicator != AsciCharSym.Null)
                return ParseResult.parsed(src, sig(n, w, indicator));
            else
                return fail;
        }
        else
            return fail;
    }
}
