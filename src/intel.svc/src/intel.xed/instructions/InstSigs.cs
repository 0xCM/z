//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static XedModels;
using static XedRules;
using static sys;

public class XedSigs
{
    static Index<InstSigToken> _SigTokens => new InstSigToken[]{
        "agen",

        "base0",
        "base1",

        "seg0",
        "seg1",

        "imm0",
        "imm1",
        "imm2",

        "imm8",
        "imm16",
        "imm32",
        "imm64",

        "index",
        "index8",
        "index80",

        "scale",

        "disp",

        "agen",

        "mem0",
        "mem1",

        "m8",
        "m16",
        "m32",
        "m64",
        "m80",
        "m128",
        "m256",
        "m512",
        "m4068",

        "ptr",
        "ptr48",

        "reg0",
        "reg1",
        "reg2",
        "reg3",
        "reg4",
        "reg5",
        "reg6",
        "reg7",
        "reg8",
        "reg9",

        "r8",
        "r16",
        "r32",
        "r64",
        "r80",
        "xmm",
        "ymm",
        "zmm",

        "relbr",
        "relbr32",
        "relbr8",
    };

    [MethodImpl(Inline)]
    public static InstOperand op(num3 pos, OpName name, InstOpSymbol ind, OpKind kind, ushort width)
        => new(pos, name, ind,kind, width);

    public static InstSig sig(InstPattern src)
    {
        ref readonly var ops = ref src.OpDetails;
        var count = (byte)ops.Count;
        var dst = InstSig.init(count);
        for(var i=z8; i<count; i++)
        {
            ref readonly var operand = ref ops[i];
            dst[i] = op(operand.Index, operand.Name, XedSigs.indicator(operand.Name), operand.Kind, operand.BitWidth);
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

    public static void render(Pairings<InstPattern,InstSig> src, ITextEmitter dst)
    {
        const string RenderPattern = "{0,-18} | {1,-6} | {2,-26} | {3,-12} | {4}({5})";
        const string HeaderPattern = "{0,-18} | {1,-6} | {2,-26} | {3,-12} | {4}";
        dst.AppendLineFormat(HeaderPattern, "Instruction", "Lock", "OpCode", "PackedWidth", "Sig");
        for(var i=0; i<src.Count; i++)
        {
            ref readonly var pattern = ref src[i].Left;
            ref readonly var sig = ref src[i].Right;
            var @class = Xed.classifier(pattern.InstClass);
            dst.AppendLineFormat(RenderPattern,
                @class,
                pattern.Lock,
                pattern.OpCode,
                sig.PackedWidth,
                @class.Format().ToLower(),
                sig
                );
        }
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
                if(c.Bits != 0)
                    dst.AppendFormat(":w{0}", c.Bits);
            }
        }

        return dst.Emit();
    }

    [MethodImpl(Inline), Op]
    static InstOpSymbol i(string src)
        => new (src);

    static readonly Index<OpNameKind,InstOpSymbol> _KindIndicators = new InstOpSymbol[]{
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
        => _KindIndicators[src];
}
