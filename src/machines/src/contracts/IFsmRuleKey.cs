//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IFsmRuleKey : IHashed
    {

    }

    public interface IFsmRuleKey<E,S> : IFsmRuleKey
    {
        /// <summary>
        /// The triggering event
        /// </summary>
        E Trigger {get;}

        /// <summary>
        /// The source state
        /// </summary>
        S Source {get;}
    }
}