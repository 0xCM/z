//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public readonly record struct NativeOp
    {
        public const uint StorageSize = 12;

        public readonly Label Name;

        public readonly NativeType Type;

        public readonly NativeOpMod Mod;

        [MethodImpl(Inline)]
        public NativeOp(Label name, NativeType type, NativeOpMod mod)
        {
            Name = name;
            Type = type;
            Mod = mod;
        }

        public string Format()
            => NativeSigs.format(this);

        public string Format(SigFormatStyle style)
            => NativeSigs.format(this, style);

        public override string ToString()
            => Format();
    }
}
