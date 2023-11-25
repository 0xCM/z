//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

[StructLayout(LayoutKind.Sequential, Pack=1), DataTypeAttributeD("asm.conditions.jcc32")]
public record struct Jcc32Conditions : IConditional
{
    public JccInfo<Jcc32Code> Definition;

    public CharBlock64 Description;

    public BitWidth RelWidth
    {
        [MethodImpl(Inline)]
        get => Definition.Size.Width;
    }

    public byte Encoding
    {
        [MethodImpl(Inline)]
        get => Definition.Encoding;
    }

    public ReadOnlySpan<char> Bitstring
    {
        [MethodImpl(Inline)]
        get => BitRender.render8x4(Encoding);
    }

    public string Format()
        => Conditions.format(this);

    public override string ToString()
        => Format();
}
