//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static NativeOpMods;

    partial class NativeTypes
    {
        [MethodImpl(Inline)]
        public static NativeOpDef op(Label name, NativeType type)
            => new NativeOpDef(name,type);

        [MethodImpl(Inline)]
        public static NativeOpDef op(Label name, NativeType type, NativeOpMod mod)
            => new NativeOpDef(name,type, mod);

        [MethodImpl(Inline), Op]
        public static NativeOpDef ptr(Label name, NativeType type)
            => op(name,type, Pointer);

        [MethodImpl(Inline), Op]
        public static NativeOpDef @const(Label name, NativeType type)
            => op(name,type, Const);

        [MethodImpl(Inline), Op]
        public static NativeOpDef @constptr(Label name, NativeType type)
            => op(name,type, Const | Pointer);

        [MethodImpl(Inline), Op]
        public static NativeOpDef @ref(Label name, NativeType type)
            => op(name,type, Ref);

        [MethodImpl(Inline), Op]
        public static NativeOpDef @in(Label name, NativeType type)
            => op(name,type, NativeOpMods.In);

        [MethodImpl(Inline), Op]
        public static NativeOpDef @out(Label name, NativeType type)
            => op(name,type, NativeOpMods.Out);
    }
}