//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public interface IFreeGroup<S> : IAdditiveGroup<S>, IFreeMonoid<S>
        where S : IFreeGroup<S>, new()
    {

    }

}