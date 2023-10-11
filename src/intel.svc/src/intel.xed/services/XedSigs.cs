//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static XedModels;
using static sys;

public class XedSigs
{
    [MethodImpl(Inline)]
    public static InstOperand op(num3 pos, OpName name, OpKind kind, ushort width)
        => new(pos, name, name.Indicator, kind, width);

    public static InstSig sig(InstPattern src)
    {
        ref readonly var ops = ref src.OpDetails;
        var count = (byte)ops.Count;
        var dst = InstSig.init(count);
        for(var i=z8; i<count; i++)
        {
            ref readonly var operand = ref ops[i];
            dst[i] = op(operand.Index, operand.Name, operand.Kind, operand.BitWidth);
        }
        return dst;
    }

    public static Pairings<InstPattern,InstSig> sigs(Index<InstPattern> src)
    {
        var dst = alloc<Paired<InstPattern,InstSig>>(src.Count);
        for(var i=0; i<src.Count; i++)
            seek(dst,i) = (src[i],sig(src[i]));
        return dst;
    }

    public static string format(in InstSig src)
    {
        var dst = text.buffer();
        if(src.N > 0)
        {
            for(var i=z8; i<src.N; i++)
            {
                if(i != 0)
                {
                    dst.Append(Chars.Comma);
                    dst.Append(Chars.Space);
                }

                ref readonly var c = ref src[i];
                dst.Append(c.Symbol.Format());
                if(c.Width != 0)
                    dst.AppendFormat(":w{0}", c.Width);
            }
        }

        return dst.Emit();
    }

    [MethodImpl(Inline), Op]
    static InstOpSymbol i(string src)
        => new (src);

    static readonly ReadOnlySeq<InstOpSymbol> _KindIndicators = new InstOpSymbol[26]{
        i(""),
        i("reg0"),
        i("reg1"),
        i("reg2"),
        i("reg3"),
        i("reg4"),
        i("reg5"),
        i("reg6"),
        i("reg7"),
        i("reg8"),
        i("reg9"),
        i("mem0"),
        i("mem1"),
        i("imm0"),
        i("imm1"),
        i("imm2"),
        i("relbr"),
        i("base0"),
        i("base1"),
        i("seg0"),
        i("seg1"),
        i("agen"),
        i("ptr"),
        i("index"),
        i("scale"),
        i("disp"),
    };

    [MethodImpl(Inline), Op]
    public static InstOpSymbol indicator(OpNameKind src)
        => _KindIndicators[(byte)src];
}
