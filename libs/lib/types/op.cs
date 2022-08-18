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
        public static NativeOpDef op(string name, NativeType type)
            => new NativeOpDef(name,type);

        [MethodImpl(Inline)]
        public static NativeOpDef op(string name, NativeType type, NativeOpMod mod)
            => new NativeOpDef(name,type, mod);

        [MethodImpl(Inline), Op]
        public static NativeOpDef ptr(string name, NativeType type)
            => op(name,type, Pointer);

        [MethodImpl(Inline), Op]
        public static NativeOpDef @const(string name, NativeType type)
            => op(name,type, Const);

        [MethodImpl(Inline), Op]
        public static NativeOpDef @constptr(string name, NativeType type)
            => op(name,type, Const | Pointer);

        [MethodImpl(Inline), Op]
        public static NativeOpDef @ref(string name, NativeType type)
            => op(name,type, Ref);

        [MethodImpl(Inline), Op]
        public static NativeOpDef @in(string name, NativeType type)
            => op(name,type, NativeOpMods.In);

        [MethodImpl(Inline), Op]
        public static NativeOpDef @out(string name, NativeType type)
            => op(name,type, NativeOpMods.Out);
    }
}