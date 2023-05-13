//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static NativeOpMods;

    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public readonly record struct NativeOpDef
    {
        public readonly Label Name;

        public readonly NativeType Type;

        public readonly NativeOpMod Mod;

        [MethodImpl(Inline)]
        public NativeOpDef(Label name, NativeType type, NativeOpMod mod = default)
        {
            Name = name;
            Type = type;
            Mod = mod;
        }

        [MethodImpl(Inline)]
        NativeOpDef Modify(NativeOpMod mod)
            => new NativeOpDef(Name, Type, mod);

        [MethodImpl(Inline)]
        public NativeOpDef ModPointer()
            => Modify(Pointer | Mod);

        [MethodImpl(Inline)]
        public NativeOpDef ModOut()
            => Modify(Out | Mod);

        [MethodImpl(Inline)]
        public NativeOpDef ModRef()
            => Modify(Ref | Mod);

        [MethodImpl(Inline)]
        public NativeOpDef ModIn()
            => Modify(In | Mod);

        [MethodImpl(Inline)]
        public NativeOpDef ModConst()
            => Modify(Const | Mod);

        public string Format()
            => NativeSigs.format(this);

        public string Format(SigFormatStyle style)
            => NativeSigs.format(this, style);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator NativeOpDef((string name, NativeType type) src)
            => new NativeOpDef(src.name, src.type);

        [MethodImpl(Inline)]
        public static implicit operator NativeOpDef((string name, NativeType type, NativeOpMod mod) src)
            => new NativeOpDef(src.name, src.type, src.mod);
    }
}