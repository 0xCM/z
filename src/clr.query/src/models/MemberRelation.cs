//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a directed association between two data members
    /// </summary>
    public readonly struct ClrMemberRelation
    {
        /// <summary>
        /// The supplier member
        /// </summary>
        public readonly ClrMember Source {get;}

        /// <summary>
        /// The client member
        /// </summary>
        public readonly ClrMember Target {get;}

        [MethodImpl(Inline)]
        public ClrMemberRelation(ClrMember s, ClrMember t)
        {
            Source = s;
            Target = t;
        }

        const string MemberFormat = "{0}[{1}]";

        public string Format()
            => string.Format(RP.Arrow,
                string.Format(MemberFormat, Source.Name, Source.Token),
                string.Format(MemberFormat, Target.Name, Target.Token)
                );


        public override string ToString()
            => Format();


        [MethodImpl(Inline)]
        public static implicit operator ClrMemberRelation((MemberInfo src, MemberInfo dst) a)
            => new ClrMemberRelation(a.src, a.dst);
    }
}