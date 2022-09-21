//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static TmpTables;

    using C = AsciLetterUpCode;

    [ApiHost]
    public class ExprChecks : Checker<ExprChecks>
    {
        static ICheckNumeric Claim = NumericClaims.Checker;

        [Op]
        public void CheckTextExpr()
        {
            var dst = new TextTemplateVar("dst");
            var src1 = new TextTemplateVar("src1");
            var src2 = new TextTemplateVar("src2");
            var body = string.Format("{0}, {1}, {2}", dst, src1, src2);
            var x = TextTemplateExpr.init(body);
            var vars = x.Vars;
            Claim.eq(vars.Length,3);
            x["dst"] = new TextTemplateVar("dst", (Identifier)"abc");
            x["src1"] = new TextTemplateVar("src1", (Identifier)"def");
            x["src2"] = new TextTemplateVar("src2", (Identifier)"hij");

            var result = x.Eval();
            Claim.eq("abc, def, hij", result);
        }

        [Op]
        public void CheckPointMappers()
        {
            var result = Outcome.Success;
            var symbols = Symbols.index<DecimalDigitValue>();
            var symview = symbols.View;
            var map = PointMappers.mapper<DecimalDigitValue,Pow2x16>(symbols, (i,k) => (Pow2x16)Pow2.pow((byte)i));
            var data = PointMappers.serialize(map).View;
            var count = map.PointCount;
            var indices = slice(data,0, count);
            var bits = recover<ushort>(slice(data,count,count*size<Pow2x16>()));
            for(var i=0; i<count; i++)
            {
                ref readonly var symbol = ref skip(symview,i);
                ref readonly var entry = ref map[symbol.Kind];
                ref readonly var index = ref skip(data,i);
                Write(string.Format("{0} => {1}", entry, BitRender.format16(skip(bits,i))));
            }
        }

        [CmdOp("check/points/fx")]
        unsafe Outcome FT(CmdArgs args)
        {
            var src = recover<C,byte>(Source);
            ref var f = ref PointFunctions.fx<AsciCode>(n8, src, Target, out _);

            byte x = 0;
            x = skip(src,0);
            Write(f.Map(x));

            x = skip(src,1);
            Write(f.Map(x));

            x = skip(src,2);
            Write(f.Map(x));

            x = skip(src,3);
            Write(f.Map(x));

            x = skip(src,4);
            Write(f.Map(x));

            return true;
        }

        public Outcome CheckTypeSyntax()
        {
            var result = Outcome.Success;
            Write(typeof(Span<int>).Spec());
            return result;
        }
    }

    readonly struct TmpTables
    {
        const byte PointCount = 5;

        public static ReadOnlySpan<C> Source
            => new C[PointCount]{C.Y, C.B, C.X, C.R, C.W};

        public static ReadOnlySpan<AsciCode> Target
            => new AsciCode[PointCount]{AsciCode.Y, AsciCode.B, AsciCode.X, AsciCode.R, AsciCode.W};
    }
}