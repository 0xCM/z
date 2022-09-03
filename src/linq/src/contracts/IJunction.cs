//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.DynamicModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public interface IJunction
    {
        IReadOnlyList<IPredicateApplication> Criteria { get; }
    }
}