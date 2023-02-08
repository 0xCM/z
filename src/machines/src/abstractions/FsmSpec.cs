//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class FsmSpec<E,S,O>
    {
        public virtual IEnumerable<FsmTransitionRule<E,S>> TransRules {get;}

        public virtual IEnumerable<FsmOutputRule<E,S,O>> OutputRules{get;}

        public FsmTransitionFunc<E,S> TransFunc
            => TransRules.ToFunction();
    }
}