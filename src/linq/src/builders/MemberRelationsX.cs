//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq.Expressions;

    public class MemberRelations
    {
        public static ClrMemberRelation define<S,T>(Expression<Func<S,object>> s, Expression<Func<T,object>> t)
            => new ClrMemberRelation(s.GetDataMember(), t.GetDataMember());

        public static RelationBuilder<S,T> build<S,T>()
            => new RelationBuilder<S,T>();
    }

    public class RelationBuilder<S,T>
    {
        HashSet<ClrMemberRelation> Relations {get;}
            = new HashSet<ClrMemberRelation>();

        public RelationBuilder<S,T> Include(Expression<Func<S, object>> s, Expression<Func<T,object>> t)
        {
            Relations.Add(MemberRelations.define(s, t));
            return this;
        }

        public RelationBuilder<S,T> Include(params (Expression<Func<S,object>> SourceMember, Expression<Func<T, object>> TargetMember)[] pairs)
        {
            foreach (var association in pairs.Select(p => MemberRelations.define(p.SourceMember, p.TargetMember)))
                Relations.Add(association);
            return this;
        }

        public MemberRelations<S,T> Complete()
            => new MemberRelations<S,T>(Relations);

        public static implicit operator MemberRelations<S,T>(RelationBuilder<S,T> builder)
            => builder.Complete();
    }
}