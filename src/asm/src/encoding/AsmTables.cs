//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2023
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using static sys;

public class AsmTables
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

    [MethodImpl(Inline), Op]
    static ModRm entry(byte mod, byte reg, byte rm)
        => new (AsmBytes.join((rm, 0), (reg, 3), (mod, 6)));

    static uint render(ModRm src, ref uint i, Span<char> dst)
    {
        const string FieldSep = " | ";
        var i0 = i;
        BitRender.render2(src.mm(), ref i, dst);
        seek(dst,i++) = Chars.Space;
        text.copy(FieldSep, ref i, dst);

        BitRender.render3(src.rrr(), ref i, dst);
        text.copy(FieldSep, ref i, dst);

        BitRender.render3(src.nnn(), ref i, dst);
        text.copy(FieldSep, ref i, dst);

        text.copy(src.Format(), ref i, dst);
        seek(dst,i++) = Chars.Space;
        text.copy(FieldSep, ref i, dst);

        text.copy(src.Bitstring(), ref i, dst);

        return i - i0;
    }

    [Op]
    public static uint render(Span<char> dst)
    {
        const string ModRmHeader = "mod | reg | r/m | hex   | bits";
        var f0 = BitSeq.bits(n3);
        var f1 = BitSeq.bits(n3);
        var f2 = BitSeq.bits(n2);
        var k=0u;
        text.copy(ModRmHeader, ref k, dst);
        seek(dst,k++) = AsciSymbols.NL;

        for(var c=0u; c<f2.Length; c++)
        for(var b=0u; b<f1.Length; b++)
        for(var a=0u; a<f0.Length; a++)
        {
            render(entry(skip(f2, c), skip(f1, b), skip(f0, a)), ref k, dst);
            seek(dst,k++) = AsciSymbols.NL;
        }
        return k;
    }

}
