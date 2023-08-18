//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2023
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

using Asm;

public class RexPrefixTable
{
    const string RexFieldPattern = "[W:{0} | R:{1} | X:{2} | B:{3}]";

    static string describe(RexPrefix src)
        => $"{src.Encoded.FormatAsmHex()} | [{text.format(BitRender.render8x4(src.Encoded))}] => {string.Format(RexFieldPattern, src.W, src.R, src.X, src.B)}";

    public static uint render(ITextBuffer dst)
    {
        var bits = RexPrefix.Range();
        var count = bits.Length;
        for(var i=0; i<count; i++)
            dst.AppendLine(describe(skip(bits,i)));
        return (uint)count;
    }
}
