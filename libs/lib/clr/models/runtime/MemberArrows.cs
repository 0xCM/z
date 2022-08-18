//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Collections;

    /// <summary>
    /// Defines a collection of directed member associations
    /// </summary>
    /// <typeparam name="S">The source type</typeparam>
    /// <typeparam name="T">The target type</typeparam>
    public sealed class MemberRelations<S,T> : IEnumerable<MemberRelation>
    {
        HashSet<MemberRelation> Associations {get;}

        public MemberRelations(IEnumerable<MemberRelation> associations)
            => Associations = associations.ToHashSet();

        public IEnumerator<MemberRelation> GetEnumerator()
            => Associations.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => Associations.GetEnumerator();
    }
}