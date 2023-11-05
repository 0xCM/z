//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

[ApiHost]
public readonly partial struct BitPatterns
{
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
}
