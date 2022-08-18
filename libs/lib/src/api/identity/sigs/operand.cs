//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct ApiSigs
    {
        [MethodImpl(Inline), Op]
        public static ApiOperandSig operand(string name, ApiTypeSig type, params ApiSigModKind[] modifiers)
            => new ApiOperandSig(name, type, modifiers);
    }
}