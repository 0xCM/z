//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static sys;

    [ApiHost,Free]
    public class AsmDirectives
    {
        [MethodImpl(Inline), Op]
        public static AsmSectionDirective section(asci16 name, CoffSectionFlags flags, CoffComDatKind comdat, AsmDirectiveOp data)
            => new AsmSectionDirective(name, flags, comdat, data);

        [MethodImpl(Inline), Op]
        public static AsmSectionDirective section(asci16 name, CoffSectionFlags flags, CoffComDatKind comdat, string data)
            => new AsmSectionDirective(name,flags,comdat, operand(data));

        [MethodImpl(Inline), Op]
        public static AsmSectionDirective section(asci16 name, CoffSectionFlags flags, CoffComDatKind comdat, AsmLabel label)
            => new AsmSectionDirective(name, flags,comdat, label.Name.Format());

        [Op]
        public static AsmSectionDirective section(CoffSectionKind kind, CoffSectionFlags flags, CoffComDatKind comdat, AsmDirectiveOp data)
            => section(format(kind), flags, comdat, data);

        [Op]
        public static AsmSectionDirective section(CoffSectionKind kind, CoffSectionFlags flags, CoffComDatKind comdat, string data)
            => section(format(kind), flags, comdat, data);

        [Op]
        public static AsmSectionDirective section(CoffSectionKind kind, CoffSectionFlags flags, CoffComDatKind comdat, AsmLabel data)
            => section(format(kind), flags, comdat, data);


        [MethodImpl(Inline), Op]
        public static AsmDirectiveOp operand(string src)
            => text.dquote(src);

        [MethodImpl(Inline), Op]
        public static AsmDirectiveOp operand(Hex8 src)
            => $"0x{src}";

        [MethodImpl(Inline), Op]
        public static AsmDirectiveOp operand(Hex16 src)
            => $"0x{src}";

        [MethodImpl(Inline), Op]
        public static AsmDirectiveOp operand(Hex32 src)
            => $"0x{src}";

        [MethodImpl(Inline), Op]
        public static AsmDirectiveOp operand(Hex64 src)
            => $"0x{src}";

        [MethodImpl(Inline), Op]
        public static AsmDirective @byte(Hex8 src)
            => define(".byte", src);

        [MethodImpl(Inline), Op]
        public static AsmDirective word(Hex16 src)
            => define(".2byte", src);

        [MethodImpl(Inline), Op]
        public static AsmDirective dword(Hex32 src)
            => define(".4byte", src);

        [MethodImpl(Inline), Op]
        public static AsmDirective qword(Hex64 src)
            => define(".8byte", src);

        [MethodImpl(Inline), Op]
        public static AsmDirective define(asci16 name)
            => new AsmDirective(name);

        public static AsmDirective define(AsmDirectiveKind kind, AsmDirectiveOp op0 = default, AsmDirectiveOp op1 = default, AsmDirectiveOp op2 = default)
            => new AsmDirective(Symbols.index<AsmDirectiveKind>()[kind].Expr.Format(),op0,op1,op2);

        [MethodImpl(Inline), Op]
        public static AsmDirective define(asci16 name, AsmDirectiveOp op0, AsmDirectiveOp op1, AsmDirectiveOp op2 = default)
            => new AsmDirective(name, op0, op1, op2);

        [Op]
        public static AsmDirective define(asci16 name, ReadOnlySpan<AsmDirectiveOp> args)
        {
            var dst = define(name);
            switch(args.Length)
            {
                case 1:
                    dst = define(name, skip(args,0));
                break;
                case 2:
                    dst = define(name, skip(args,0), skip(args,1));
                break;
                case 3:
                    dst = define(name, skip(args,0), skip(args,1), skip(args,2));
                break;
                default:
                    break;
            }
            return dst;
        }

        [MethodImpl(Inline)]
        public static AsmDirective define<T>(asci16 name, T arg)
            => new AsmDirective(name, new AsmDirectiveOp<T>(arg));

        [Parser]
        public static Outcome parse(string src, out AsmDirective dst)
        {
            var input = src.Trim();
            var name = input;
            var i = text.index(src, Chars.Dot);
            var j = text.index(src, Chars.Colon);
            var result = Outcome.Failure;
            if(i >= 0 && j < 0)
            {
                var k = text.index(src, Chars.Comma);
                if(k > 0)
                {
                    name = text.left(src,k).Trim();
                    var args = text.right(src,i).SplitClean(Chars.Comma);
                    var count =  args.Length;
                    switch(count)
                    {
                        case 1:
                            dst = define(name, skip(args,0));
                        break;
                        case 2:
                            dst = define(name, skip(args,0), skip(args,1));
                        break;
                        case 3:
                            dst = define(name, skip(args,0), skip(args,1), skip(args,2));
                        break;
                        default:
                            dst = define(name);
                        break;
                    }
                }
                else
                    dst = define(name);

                result = Outcome.Success;
            }
            else
                dst = AsmDirective.Empty;

            return result;
        }

        internal static string render<T>(in T src)
            where T : IAsmDirective
        {
            var dst = text.buffer();
            dst.AppendFormat("{0}", src.Name.Format().Trim());
            if(src.Op0.IsNonEmpty)
            {
                dst.AppendFormat(" {0}", src.Op0.Format());
                if(src.Op1.IsNonEmpty)
                {
                    dst.AppendFormat(", {0}", src.Op1.Format());
                    if(src.Op2.IsNonEmpty)
                    {
                        dst.AppendFormat(", {0}", src.Op2.Format());

                        if(src.Op3.IsNonEmpty)
                            dst.AppendFormat(", {0}", src.Op3.Format());
                    }
                }
            }

            return dst.Emit();
        }

        public static string format(CoffSectionKind src)
        {
            var symbols = Symbols.index<CoffSectionKind>();
            return symbols[src].Expr.Text;
        }

        [Op]
        public static string format(CoffSectionFlags src)
        {
            var symbols = Symbols.index<CoffSectionFlags>();
            Span<char> dst = stackalloc char[64];
            var count = symbols.Count;
            var k = 0;
            for(var i=0u; i<count; i++)
            {
                ref readonly var sym = ref symbols[i];
                var kind = sym.Kind;
                if(kind != 0 && (src & kind) != 0)
                {
                    var expr = sym.Expr.Text;
                    seek(dst,k++) = expr[0];
                }
            }
            return new string(slice(dst,0,k));
        }

        public static string format(CoffComDatKind src)
        {
            var symbols = Symbols.index<CoffComDatKind>();
            if(symbols.MapKind(src, out var sym))
                return sym.Expr.Text;
            else
                return EmptyString;
        }
    }
}