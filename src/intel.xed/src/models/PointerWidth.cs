//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using K = XedModels.PointerWidthKind;

partial class XedModels
{
    public readonly struct PointerWidth
    {
        public static char symbol(K src)
            => src switch{
                K.Byte => 'b',
                K.Word => 'w',
                K.DWord => 'l',
                K.QWord => 'q',
                K.XmmWord => 'x',
                K.YmmWord => 'y',
                K.ZmmWord => 'z',
                _ => (char)0
            };


        public readonly K Kind;

        public readonly char Symbol;

        public readonly asci16 Keyword;

        public PointerWidth(K src)
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

        public PointerWidthInfo ToRecord()
        {
            var dst = new PointerWidthInfo();
            dst.Name = Keyword;
            dst.Symbol = Symbol;
            dst.Size = Size;
            return dst;
        }

        [MethodImpl(Inline)]
        public static implicit operator PointerWidth(K src)
            => new PointerWidth(src);

        [MethodImpl(Inline)]
        public static implicit operator K(PointerWidth src)
            => src.Kind;

        public static PointerWidth Empty => default;
    }
}
