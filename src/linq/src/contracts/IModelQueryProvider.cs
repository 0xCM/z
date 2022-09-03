//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.DynamicModels
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using static FacetsDynamic;

    public interface IModelQueryProvider : IQueryProvider
    {
        Type ModelType { get; }

        M CreateModel<M>(Expression X, params SelectionFacet[] facets);
    }
}