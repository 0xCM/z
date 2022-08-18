//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IClaimEvaluator : IEvaluator<IClaim,IClaim>
    {

    }

    [Free]
    public interface IClaimEvaluator<C> : IEvaluator<C,bool>
        where C : IClaim
    {

    }

    [Free]
    public interface IClaimEvaluator<S,T> : IEvaluator<S,T>
        where S : IClaim
        where T : IClaim
    {

    }
}