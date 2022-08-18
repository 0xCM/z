//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;
    using static Spans;
    using static HexFormatSpecs;

    public class FormatThisX
    {
        [Op]
        public static string format(ReadOnlySpan<byte> src, in HexFormatOptions config)
        {
            int? blockwidth = null;
            var dst = new StringBuilder();
            var count = src.Length;
            var pre = (config.Specifier && config.PreSpec) ? "0x" : EmptyString;
            var post = (config.Specifier && !config.PreSpec) ? "h" : EmptyString;
            var spec = CaseSpec(config.Uppercase).ToString();
            var width = config.BlockWidth == 0 ? ushort.MaxValue : config.BlockWidth;
            var counter = 0;

            for(var i=0; i<count; i++)
            {
                var value = skip(src,i).ToString(spec);
                var padded = config.ZeroPad ? value.PadLeft(2, Chars.D0) : value;
                dst.Append(string.Concat(pre, padded, post));
                if(config.DelimitSegs && i != count - 1)
                    dst.Append(config.SegDelimiter);

                if(++counter >= width && config.DelimitBlocks)
                {
                    if(config.BlockDelimiter == Chars.NL || config.BlockDelimiter == Chars.CR)
                        dst.AppendLine();
                    else
                        dst.Append(config.BlockDelimiter);
                    counter = 0;
                }
            }

            return dst.ToString();
        }
    }
}