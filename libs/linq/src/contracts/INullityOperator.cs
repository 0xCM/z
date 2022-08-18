//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.DynamicModels
{
    public interface INullityOperator : IOperator
    {

    }

    public interface INullityOperator<F> : INullityOperator, IOperator<F>
        where F : INullityOperator<F>
    {

    }

}