//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using PW = XedModels.PointerWidthKind;

    partial struct XedModels
    {
        public readonly struct PointerWidth
        {
            public static char symbol(PointerWidthKind src)
                => src switch{
                    PW.Byte => 'b',
                    PW.Word => 'w',
                    PW.DWord => 'l',
                    PW.QWord => 'q',
                    PW.XmmWord => 'x',
                    PW.YmmWord => 'y',
                    PW.ZmmWord => 'z',
                    _ => (char)0
                };


            public readonly PointerWidthKind Kind;

            public readonly char Symbol;

            public readonly text15 Keyword;

            public PointerWidth(PointerWidthKind src)
            {
                Kind = src;
                Symbol =  symbol(src);
                Keyword = src.ToString().ToLower();
            }

            public NativeSize Size
            {
                [MethodImpl(Inline)]
                get => Sizes.native(((uint)Kind)*8);
            }

            public string Format()
                => Keyword.Format();

            public override string ToString()
                => Format();

            public PointerWidthInfo ToRecord(byte seq)
            {
                var dst = new PointerWidthInfo();
                dst.Seq = seq;
                dst.Name = Keyword;
                dst.Symbol = Symbol;
                dst.Size = Size;
                return dst;
            }

            [MethodImpl(Inline)]
            public static implicit operator PointerWidth(PointerWidthKind src)
                => new PointerWidth(src);

            [MethodImpl(Inline)]
            public static implicit operator PointerWidthKind(PointerWidth src)
                => src.Kind;

            public static PointerWidth Empty => default;
        }
    }
}