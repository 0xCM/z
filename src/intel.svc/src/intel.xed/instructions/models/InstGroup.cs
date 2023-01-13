//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public class InstGroup : IComparable<InstGroup>
        {
            public readonly AsmInstClass Class;

            public readonly Index<InstGroupMember> Members;

            [MethodImpl(Inline)]
            public InstGroup(AsmInstClass @class, Index<InstGroupMember> src)
            {
                Class = @class;
                Members = src;
            }

            public uint MemberCount
            {
                [MethodImpl(Inline)]
                get => Members.Count;
            }

            public ref InstGroupMember this[uint i]
            {
                [MethodImpl(Inline)]
                get => ref Members[i];
            }

            public ref InstGroupMember this[int i]
            {
                [MethodImpl(Inline)]
                get => ref Members[i];
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Class.IsEmpty;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Class.IsNonEmpty;
            }

            public override int GetHashCode()
                => Class.Hash;

            public int CompareTo(InstGroup src)
                => Class.CompareTo(src.Class);
        }
    }
}