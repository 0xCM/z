//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost]
    public partial class StringMatcher
    {
        readonly Index<CharMatchRow> Rows;

        readonly Index<GroupMembers> Members;

        StringMatcher(Builder state)
        {
            Rows = state.RowData;
            Members = state.GroupMemberData;
        }

        public ReadOnlySpan<CharMatchRow> MemberRows(GroupMembers g)
            => slice(Rows.View, g.MinSeq, g.Count);
    }
}