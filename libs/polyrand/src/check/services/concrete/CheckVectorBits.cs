//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct CheckVectorBits : ICheckVectorBits, IClaimValidator<CheckVectorBits,ICheckVectorBits>
    {
        public static ICheckVectorBits Checker => default(CheckVectorBits);
    }
}