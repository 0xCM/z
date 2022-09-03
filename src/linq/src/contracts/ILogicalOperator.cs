//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.DynamicModels
{
    public interface ILogicalOperator : IOperator
    {
    }

    public interface ILogicalOperator<F> : ILogicalOperator, IOperator<F>
        where F : ILogicalOperator<F>
    {

    }
}
