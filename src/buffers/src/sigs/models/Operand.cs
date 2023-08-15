//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class NativeSigs
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public readonly record struct Operand
    {
        public const uint StorageSize = 12;

        public readonly Label Name;

        public readonly NativeType Type;

        public readonly Modifier Modifiers;

        [MethodImpl(Inline)]
        public Operand(Label name, NativeType type, Modifier mod)
        {
            Name = name;
            Type = type;
            Modifiers = mod;
        }

        public string Format()
            => format(this);

        public string Format(SigFormatStyle style)
            => format(this, style);

        public override string ToString()
            => Format();
    }
}
