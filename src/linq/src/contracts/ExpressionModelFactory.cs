//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.DynamicModels
{
    using System;
    using System.Linq.Expressions;

     using static FacetsDynamic;

    /// <summary>
    /// Defines contract for functions that create models from LINQ expression trees
    /// </summary>
    /// <typeparam name="M">The type of model the function will produce</typeparam>
    /// <param name="X">The expression from which the model's structure will be derived</param>
    public delegate M ExpressionModelFactory<out M>(Expression X, params SelectionFacet[] facets);
}