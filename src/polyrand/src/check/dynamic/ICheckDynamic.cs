//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ICheckDynamic : IClaimValidator
    {
        IDynexus Dynamic => Dynops.Dynexus;
    }
}