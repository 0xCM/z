//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class DiscreteRefinement<T,V> : TypeRefinement<T,V>
        where T : IType
    {
        readonly Index<V> _Members;

        readonly HashSet<V> MemberSet;

        public DiscreteRefinement(Identifier name, T @base, V[] members)
            : base(name, @base)
        {
            _Members = members;
            MemberSet = core.hashset(members);
        }

        public ReadOnlySpan<V> Members
        {
            [MethodImpl(Inline)]
            get => _Members;
        }

        public override Predicate<V> Predicate
            => x => MemberSet.Contains(x);
    }
}