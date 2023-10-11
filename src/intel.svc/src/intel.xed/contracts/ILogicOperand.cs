//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedRules
{
    public interface ILogicOperand
    {
        RuleOperator Operator {get;}
    }

    public interface ILogicOperand<T> : ILogicOperand
        where T : unmanaged, IValue
    {
        T Value {get;}
    }
}
