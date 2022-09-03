//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.Intrinsics.X86;

    using static Chars;
    using static CodeGenerator;

    partial class CsLang
    {
        public class GBinaryKind
        {
            public static GBinaryKind create(uint max = 0xFF)
                => new GBinaryKind(max);

            public GBinaryKind(uint max)
            {
                MaxValue = max;
                MaxBitCount = effwidth(MaxValue);
                Formatter = BitRender.formatter<byte>(BitFormat.limited(MaxBitCount, MaxBitCount));
            }

            BitFormatter<byte> Formatter {get;}
                = BitRender.formatter<byte>();

            public string Namespace {get;}
                = "Z0";

            public string BaseType {get;}
                = "byte";

            public string Access {get;}
                = "public";

            public string TypeKind {get;}
                = "enum";

            public string RootName {get;}
                = "BinaryKind";

            public uint MaxValue {get; set;}
                = 0xFF;

            [MethodImpl(Inline)]
            static byte nlz(uint src)
                => (byte)Lzcnt.LeadingZeroCount(src);

            [MethodImpl(Inline)]
            static byte effwidth(uint src)
                => (byte)(32 - nlz(src));

            byte MaxBitCount {get;}

            public string TypeName
            {
                get
                {
                    if(MaxValue == 0xFF)
                        return RootName;
                    else
                        return RootName + MaxBitCount;
                }
            }

            public string Generate()
            {
                var dst = text.build();
                dst.Append(FileHeader);
                line(l0("namespace", Chars.Space, Namespace), dst);
                line(l0(LBrace), dst);
                line(text.concat(Level1,Access, Chars.Space, spaced(TypeKind, TypeName, Colon, BaseType)), dst);
                line(l1(LBrace), dst);
                lines(Literals(), dst);
                line(l1(RBrace), dst);
                line(l0(RBrace), dst);

                return dst.ToString();
            }

            IEnumerable<string> Literals()
            {
                for(var i=0; i<=MaxValue; i++)
                {
                    yield return l2(Literal(LiteralName((byte)i), LiteralValue((byte)i)), Comma);
                    yield return EmptyString;
                }
            }

            string LiteralName(byte value)
                => text.concat(AsciLetterLoSym.b, Formatter.Format(value));

            string LiteralValue(byte value)
                => text.concat("0b", Formatter.Format(value));

            string Literal(string Name, string Value)
                => RpOps.assign(Name, Value);
        }
    }
}