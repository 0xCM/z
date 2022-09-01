//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [StructLayout(LayoutKind.Sequential, Pack=1), DataTypeAttributeD("asm.conditions.jcc32")]
    public struct Jcc32Conditions : IConditional
    {
        [Op]
        public static string format(in Jcc32Conditions src, bit alt)
        {
            const string Pattern = "{0,-4} rel{1} [{2}:{3}b] => {4}";
            var dst = EmptyString;
            if(alt)
                dst =  string.Format(Pattern, src.Alt.Name, src.Alt.Size.Width, HexFormatter.asmhex(src.Alt.Encoding), BitRender.format8x4(src.Alt.Encoding), src.AltInfo);
            else
                dst = string.Format(Pattern, src.Primary.Name, src.RelWidth, HexFormatter.asmhex(src.Encoding), text.format(src.Bitstring), src.PrimaryInfo);
            return dst;
        }

        public JccInfo<Jcc32Code> Primary;

        public JccInfo<Jcc32AltCode> Alt;

        public CharBlock64 PrimaryInfo;

        public CharBlock64 AltInfo;

        public BitWidth RelWidth
        {
            [MethodImpl(Inline)]
            get => Primary.Size.Width;
        }

        public byte Encoding
        {
            [MethodImpl(Inline)]
            get => Primary.Encoding;
        }

        public ReadOnlySpan<char> Bitstring
        {
            [MethodImpl(Inline)]
            get => BitRender.render8x4(Encoding);
        }

        public bit Identical
        {
            [MethodImpl(Inline)]
            get => Alt.Name == Primary.Name;
        }

        public string Format(bit alt)
            => format(this,alt);

        public override string ToString()
            => Format(false);
    }
}