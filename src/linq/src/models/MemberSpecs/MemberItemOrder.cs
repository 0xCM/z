//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.DynamicModels
{
    using System;
    using System.Reflection;

    public class MemberItemOrder
    {
        public MemberItemOrder(MemberInfo Member, SortDirection Direction, int? Precedence = null)
        {
            this.Member = Member;
            this.Precedence = Precedence;
            this.Direction = Direction;
        }

        public MemberInfo Member {get;}

        public int? Precedence {get;}

        public SortDirection Direction { get; }

        public override string ToString()
            => $"order by {Member.Name}"
            + (Direction == SortDirection.Descending ? " desc" : String.Empty)
            + (Precedence != null ? $" {Precedence}" : String.Empty);

        public MemberItemOrder Clone(MemberInfo NewMember = null, SortDirection? NewDirection = null, int? NewPrecedence = null)
            => new MemberItemOrder
            (
                NewMember ?? this.Member,
                NewDirection ?? this.Direction,
                NewPrecedence ?? this.Precedence
            );
    }



}