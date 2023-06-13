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
    public sealed class MemberRelations<S,T> : IEnumerable<ClrMemberRelation>
    {
        HashSet<ClrMemberRelation> Associations {get;}

        public MemberRelations(IEnumerable<ClrMemberRelation> associations)
            => Associations = associations.ToHashSet();

        public IEnumerator<ClrMemberRelation> GetEnumerator()
            => Associations.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => Associations.GetEnumerator();
    }
}