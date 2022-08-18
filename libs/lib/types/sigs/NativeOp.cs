//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public readonly struct NativeOp
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
            => NativeRender.format(this);

        public string Format(SigFormatStyle style)
            => NativeRender.format(this, style);

        public override string ToString()
            => Format();
    }
}
