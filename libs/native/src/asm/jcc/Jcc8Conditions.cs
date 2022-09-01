//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [StructLayout(LayoutKind.Sequential, Pack=1), DataTypeAttributeD("asm.conditions.jcc8")]
    public struct Jcc8Conditions : IConditional
    {
        public JccInfo<Jcc8Code> Primary;

        public JccInfo<Jcc8AltCode> Alt;

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
            => Jcc8.format(this,alt);

        public override string ToString()
            => Format(false);
    }
}