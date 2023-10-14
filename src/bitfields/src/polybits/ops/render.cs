//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

partial class PolyBits
{
    public static void render(BpInfo src, uint seq, ITextEmitter dst)
    {
        const string RenderPattern = "{0,-12} | {1}";
        dst.WriteLine();
        dst.AppendLineFormat(RenderPattern, "BitPattern", seq.ToString("D2"));
        dst.WriteLine(RP.PageBreak120);
        dst.AppendLineFormat(RenderPattern,  nameof(BpInfo.Origin), src.Origin);
        dst.AppendLineFormat(RenderPattern,  nameof(BpInfo.Name), src.Name);
        dst.AppendLineFormat(RenderPattern,  nameof(BpInfo.Pattern), src.Pattern);
        dst.AppendLineFormat(RenderPattern,  nameof(BpInfo.DataWidth), src.DataWidth);
        dst.AppendLineFormat(RenderPattern,  nameof(BpInfo.PackedSize), src.PackedSize);
        dst.AppendLineFormat(RenderPattern,  nameof(BpInfo.DataType), src.DataType.DisplayName());
        dst.AppendLineFormat(RenderPattern,  nameof(BpInfo.Descriptor), src.Descriptor);
        dst.AppendLineFormat(RenderPattern, "Segments", EmptyString);
        dst.AppendLine(RP.PageBreak120);
        render(src.Segs, dst);
    }

    public static void render(ReadOnlySpan<BfSegModel> src, ITextEmitter dst, bool header = true)
    {
        var formatter = CsvTables.formatter<BfSegModel>();
        if(header)
            dst.AppendLine(formatter.FormatHeader());
        for(var i=0; i<src.Length; i++)
            dst.AppendLine(formatter.Format(skip(src,i)));
    }

    public static string format(in BfSegExpr src)
        => src.SegWidth == 1 ? string.Format("{0}[{1}]", src.SegName, src.MaxPos) : string.Format("{0}[{1}:{2}]", src.SegName, src.MaxPos, src.MinPos);
}
