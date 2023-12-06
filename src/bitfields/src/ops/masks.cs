//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static TaggedLiterals;

partial struct Bitfields
{
    public static Index<BitMask> masks<W>()
        where W : unmanaged, Enum
    {
        var widths = Bitfields.widths<W>();
        var count = widths.Count;
        var offset = 0u;
        var dst = alloc<BitMask>(count);
        masks(widths, dst);
        return dst;
    }

    /// <summary>
    /// Computes a sequence of segment masks given a paired offset/width seqence
    /// </summary>
    /// <param name="widths">The 0-based offset of each segment in the field</param>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static Index<T> masks<T>(ReadOnlySpan<byte> widths, ReadOnlySpan<uint> offsets)
        where T : unmanaged
    {
        var count = Require.equal(offsets.Length, widths.Length);
        var dst = alloc<T>(count);
        masks<T>(widths, offsets, dst);
        return dst;
    }

    /// <summary>
    /// Computes a sequence of segment masks given a paired offset/width seqence
    /// </summary>
    /// <param name="widths">The 0-based offset of each segment in the field</param>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static void masks(BfDataset src, Span<BitMask> dst)
    {
        var count = dst.Length;
        for(var i=z8; i<count; i++)
            seek(dst,i) = mask(src.Width(i), src.Offset(i));
    }

    /// <summary>
    /// Computes a sequence of segment masks given a paired offset/width seqence
    /// </summary>
    /// <param name="widths">The 0-based offset of each segment in the field</param>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static void masks<T>(BfDataset src, Span<T> dst)
        where T : unmanaged
    {
        var count = dst.Length;
        for(var i=0; i<count; i++)
            seek(dst,i) = mask<T>(src.Width(i), src.Offset(i));
    }


    [MethodImpl(Inline), Op]
    public static void masks(ReadOnlySpan<byte> widths, Span<BitMask> dst)
    {
        var count = min(widths.Length, dst.Length);
        var offset = 0u;
        for(var i=0; i<count; i++)
        {
            ref readonly var width = ref skip(widths,i);
            seek(dst,i) = mask(width, offset);
            offset += width;
        }
    }

    /// <summary>
    /// Computes a sequence of segment masks given a paired offset/width seqence
    /// </summary>
    /// <param name="widths">The 0-based offset of each segment in the field</param>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static void masks<T>(ReadOnlySpan<byte> widths, ReadOnlySpan<uint> offsets, Span<T> dst)
        where T : unmanaged
    {
        var count = dst.Length;
        for(var i=0; i<count; i++)
            seek(dst,i) = mask<T>(skip(widths,i), skip(offsets,i));
    }

    /// <summary>
    /// Computes a sequence of segment masks given a paired offset/width seqence
    /// </summary>
    /// <param name="widths">The 0-based offset of each segment in the field</param>
    public static Index<BitMask> masks(BfDataset src)
    {
        var dst = alloc<BitMask>(src.FieldCount);
        for(var i=z8; i<src.FieldCount; i++)
            seek(dst,i) = Bitfields.mask(src.Width(i), src.Offset(i));
        return dst;
    }

    /// <summary>
    /// Computes a sequence of segment masks given a paired offset/width seqence
    /// </summary>
    /// <param name="widths">The 0-based offset of each segment in the field</param>
    public static Index<BitMask> masks<F>(BfDataset<F> src)
        where F : unmanaged, Enum
    {
        var dst = alloc<BitMask>(src.FieldCount);
        var fields = src.Fields;
        for(var i=0; i<src.FieldCount; i++)
        {
            ref readonly var field = ref fields[i];
            ref readonly var width = ref src.Width(field);
            var m = (ulong)Pow2.m1(width);
            seek(dst,i) = m << (int)src.Offset(field);
        }
        return dst;
    }

    public static Index<BitMask> masks<F,T>(BfDataset<F,T> src)
        where F : unmanaged, Enum
        where T : unmanaged
    {
        var fields = src.Fields;
        var dst = alloc<BitMask>(src.FieldCount);
        for(var i=0; i<src.FieldCount; i++)
        {
            ref readonly var field = ref fields[i];
            ref readonly var width = ref src.Width(field);
            var m = (ulong)Pow2.m1(width);
            seek(dst,i) = m << (int)src.Offset(field);
        }
        return dst;
    }

    public static ReadOnlySeq<BitMaskInfo> ApiBitMasks()
        => masks(typeof(BitMaskLiterals));
        
    public static Index<BitMaskInfo> masks(Type src)
    {
        var fields = span(src.LiteralFields());
        var dst = list<BitMaskInfo>();
        for(var i=0u; i<fields.Length; i++)
        {
            ref readonly var field = ref skip(fields,i);
            var tc = Type.GetTypeCode(field.FieldType);
            var vRaw = field.GetRawConstantValue();
            if(IsMultiLiteral(field))
                dst.AddRange(masks(polymorphic(field), vRaw));
            else if(IsBinaryLiteral(field))
                dst.Add(BitMaskData.describe(binaryliteral(field,vRaw)));
            else
                dst.Add(BitMaskData.describe(NumericLiterals.numeric(base2, field.Name, vRaw, BoxedNumber.format(vRaw, tc))));
        }
        return dst.ToArray();
    }

    public static Index<BitMaskInfo> masks(LiteralInfo src, object value)
    {
        var input = src.Text;
        var fence = CharFence.define(Chars.LBracket, Chars.RBracket);
        var content = input;
        var fenced = Fenced.test(input, fence);
        if(fenced)
        {
            if(!Fenced.unfence(input, fence, out content))
                return sys.empty<BitMaskInfo>();
        }

        var components = @readonly(content.SplitClean(FieldDelimiter));
        var count = components.Length;
        var dst = alloc<BitMaskInfo>(count);
        for(var i=0; i<count; i++)
        {
            ref readonly var component = ref skip(components,i);
            var length = component.Length;
            if(length > 0)
            {
                var nbi = NumericBases.indicator(first(component));
                var nbk = NumericBases.kind(nbi);

                if(nbi != 0)
                    seek(dst, i) = BitMaskData.describe(NumericLiterals.numeric(nbk, src.Name, value, component.Substring(1)));
                else
                {
                    nbi = NumericBases.indicator(component[length - 1]);
                    nbi = nbi != 0 ? nbi : NumericBaseIndicator.Base2;
                    seek(dst, i) = BitMaskData.describe(NumericLiterals.numeric(nbk, src.Name, value, component.Substring(0, length - 1)));
                }
            }
            else
                seek(dst, i) = BitMaskData.describe(NumericLiteral.Empty);
        }

        return dst;
    }


}
