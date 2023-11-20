//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

[ApiHost]
public readonly partial struct BitPatterns
{
    [MethodImpl(Inline), Op]
    public static BpDef def(in BpExpr expr)
        => new (EmptyString, expr);

    [MethodImpl(Inline), Op]
    public static BpDef def(string name, in BpExpr expr)
        => new (name, expr);

    public static BpDef pattern<P>()
        where P : unmanaged, IBitPattern<P>
            => def(typeof(P).Name, typeof(P).GetCustomAttribute<BitPatternAttribute>().Symbols ?? EmptyString);

    [MethodImpl(Inline), Op]
    public static BpSpec spec(string name, BpExpr pattern)
        => spec(describe(pattern));

    [MethodImpl(Inline), Op]
    public static BpSpec spec(in BpInfo src)
    {
        var dst = BpSpec.Empty;
        dst.Content = src.Expr;
        dst.DataType = src.DataType.DisplayName();
        dst.Descriptor = src.Descriptor;
        dst.MinSize = src.PackedSize;
        dst.Name = src.Name;
        dst.DataWidth = src.DataWidth;
        return dst;
    }

    public static string descriptor(BpExpr src)
        => text.intersperse(segdefs(src).Select(x => x.Format()).Storage, Chars.Space);

    public static BpInfo describe(string name, params string[] segs)
        => describe(new BpExpr(text.join(Chars.Space,segs)));

    public static BpInfo describe(BpExpr expr)
        => new BpInfo(
            def(expr),
            bitwidth(expr),
            datatype(expr),
            nativesize(expr),
            segdefs(expr),
            descriptor(expr)
        );

    public static ReadOnlySeq<string> symbols(BpExpr src)
        => text.split(src.Data, Chars.Space);

    public static string symbolic<P>(P src)
        where P : IBitPattern
    {
        var dst = text.emitter();
        symbolic(src,dst);
        return dst.Emit();
    }

    public static void symbolic<P>(P src, ITextEmitter dst)
        where P : IBitPattern
    {
        var segs = src.Segments();
        var count = (int)segs.Count;
        for(var i=0; i<count; i++)
        {
            if(i!=0)
                dst.Append(Chars.Space);            
            dst.Append(segs[i].SegName);            
        }
    }

    public static Seq<BfSegDef> segdefs(BpExpr src)
    {
        var names = symbols(src);
        var count = names.Length;
        var dst = alloc<BfSegDef>(count);
        var offset = z8;
        var size = nativesize(src);
        for(var i=0; i<count; i++)
        {
            ref readonly var name = ref names[i];
            var width = (byte)name.Length;
            var min = offset;
            var max = (byte)(width + offset - 1);
            seek(dst,i) = Bitfields.segdef(name, size, min, max);
            offset += width;
        }

        return dst;
    }

    public static BfDef bitfield(string name, BpExpr src)
        => Bitfields.define(segdefs(src));

    public static Seq<byte> segwidths(BpExpr src)
    {
        var fields = symbols(src);
        var count = fields.Length;
        var buffer = alloc<byte>(count);
        for(var i=0; i<count; i++)
            seek(buffer,i) = (byte)fields[i].Length;
        return buffer;
    }

    public static string bitstring(BpExpr expr, ReadOnlySpan<byte> src)
    {
        var pattern = BitPatterns.def(expr);
        var bits = span(src.FormatBits());
        var segs = pattern.Segments();
        var offset = 0u;
        var dst = text.emitter();
        for(var i=0; i<segs.Count; i++)
        {
            ref readonly var seg = ref segs[i];
            if(offset + seg.Width > bits.Length)
                break;

            var content = slice(bits, offset, seg.Width);
            offset += seg.Width;
            if(i!= 0)
                dst.Append(Chars.Space);
            dst.Append(content);
        }

        return dst.Emit();
    }

    public static string bitstring<T>(BpExpr pattern, T value)
        where T : unmanaged
            => bitstring(pattern, bytes(value));

    public static void render(BpInfo src, uint seq, ITextEmitter dst)
    {
        const string RenderPattern = "{0,-12} | {1}";
        dst.WriteLine();
        dst.AppendLineFormat(RenderPattern, "BitPattern", seq.ToString("D2"));
        dst.WriteLine(RP.PageBreak120);
        dst.AppendLineFormat(RenderPattern,  nameof(BpInfo.Name), src.Name);
        dst.AppendLineFormat(RenderPattern,  nameof(BpInfo.Expr), src.Expr);
        dst.AppendLineFormat(RenderPattern,  nameof(BpInfo.DataWidth), src.DataWidth);
        dst.AppendLineFormat(RenderPattern,  nameof(BpInfo.PackedSize), src.PackedSize);
        dst.AppendLineFormat(RenderPattern,  nameof(BpInfo.DataType), src.DataType.DisplayName());
        dst.AppendLineFormat(RenderPattern,  nameof(BpInfo.Descriptor), src.Descriptor);
        dst.AppendLineFormat(RenderPattern, "Segments", EmptyString);
        dst.AppendLine(RP.PageBreak120);
        render(src.Segs, dst);
    }

    static void render(ReadOnlySpan<BfSegDef> src, ITextEmitter dst, bool header = true)
    {
        var formatter = CsvTables.formatter<BfSegDef>();
        if(header)
            dst.AppendLine(formatter.FormatHeader());
        for(var i=0; i<src.Length; i++)
            dst.AppendLine(formatter.Format(skip(src,i)));
    }

    public static ReadOnlySeq<BpInfo> reflected(Type src)
    {
        var target = typeof(BpInfo);
        var props = src.Properties().Ignore().Static().WithPropertyType(target).Index();
        var fields = src.Fields().Ignore().Static().Where(x => x.FieldType == target).Index();
        var methods = src.Methods().Ignore().Public().WithArity(0).Returns(target).Index();
        var count = props.Count + fields.Count + methods.Count;
        Index<BpInfo> dst = alloc<BpInfo>(count);
        var k=0u;
        for(var i=0; i<props.Count; i++, k++)
            dst[k] = (BpInfo)props[i].GetValue(null);

        for(var i=0; i<fields.Count; i++, k++)
            dst[k] = (BpInfo)fields[i].GetValue(null);

        for(var i=0; i<methods.Count; i++, k++)
            dst[k] = (BpInfo)methods[i].Invoke(null, new object[]{});
        return dst;
    }

    [Op]
    public static uint bitwidth(BpExpr src)
        => (uint)text.remove(src.Data, Chars.Space).Length;

    [MethodImpl(Inline), Op]
    public static DataSize size(BpExpr src)
        => Sizes.datasize(bitwidth(src));

    [MethodImpl(Inline), Op]
    public static NativeSize nativesize(BpExpr src)
    {
        var width = bitwidth(src);
        if(width <= 8)
            return NativeSizeCode.W8;
        else if(width <= 16)
            return NativeSizeCode.W16;
        else if(width <= 32)
            return NativeSizeCode.W32;
        else if(width <= 64)
            return NativeSizeCode.W64;
        else if(width <= 128)
            return NativeSizeCode.W128;
        else if(width <= 256)
            return NativeSizeCode.W256;
        else
            Throw.message("Width unsupported");

        return default;
    }    

    public static string format(in BfSegExpr src)
        => src.SegWidth == 1 ? string.Format("{0}[{1}]", src.SegName, src.MaxPos) : string.Format("{0}[{1}:{2}]", src.SegName, src.MaxPos, src.MinPos);
        
    public static string format(in BpDef src)
        => string.Format("{0}[{1}]", src.Name, src.Expr);

    public static string format<P>(in BpDef<P> src)
        where P : unmanaged, IBitPattern<P>
            => string.Format("{0}[{1}]", src.Name, src.Pattern);    

    [Op]
    public static Type datatype(in BpExpr src)
    {
        var w = bitwidth(src);
        var dst = typeof(void);
        if(w <= 8)
            dst = typeof(byte);
        else if(w <= 16)
            dst = typeof(ushort);
        else if(w <= 32)
            dst = typeof(uint);
        else if(w <= 64)
            dst = typeof(ulong);
        else if(w <= 128)
            dst = typeof(BitVector128<ulong>);
        else if(w <= 256)
            dst = typeof(BitVector256<ulong>);
        else
            Throw.message("Width unsupported");
        return dst;
    }            
}
