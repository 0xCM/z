//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct ApiSigs
    {
        [MethodImpl(Inline), Op]
        public static ApiOperationSig operation(string name, ApiOperandSig @return, params ApiOperandSig[] operands)
            => new ApiOperationSig(name, @return, operands);
    }
}