//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Characterizes a state machine partial function
    /// </summary>
    public interface IFsmFunc
    {
        Option<IFsmRule> Rule(IFsmRuleKey key);
    }

    public interface IFsmFunc<E,S> : IFsmFunc
    {
        Option<S> Eval(E input, S state);

        IEnumerable<E> Triggers {get;}
    }
}