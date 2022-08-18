//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class NativeTypes
    {
        [MethodImpl(Inline), Op]
        public static NativeSigSpec sig(string scope, string name, NativeType ret, params NativeOpDef[] ops)
            => new NativeSigSpec(scope, name, ret, ops);

        [MethodImpl(Inline), Op]
        public static NativeSigSpec sig(string name, NativeType ret, params NativeOpDef[] ops)
            => new NativeSigSpec(EmptyString, name, ret, ops);
    }
}