//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class StringMatcher
    {
        /// <summary>
        /// Defines an equivalence class member predicated on the target string length and a position within a string
        /// </summary>
        [Record(TableId), StructLayout(LayoutKind.Sequential, Pack=1)]
        public struct GroupMembers
        {
            public const string TableId = "strings.match.groups";

            [Render(12)]
            public CharGroup Group;

            [Render(12)]
            public uint MinSeq;

            [Render(12)]
            public uint MaxSeq;

            [MethodImpl(Inline)]
            public GroupMembers(CharGroup group, uint min, uint max)
            {
                Group = group;
                MinSeq = min;
                MaxSeq = max;
            }

            public uint Count
            {
                [MethodImpl(Inline)]
                get => MaxSeq - MinSeq;
            }

            public string Format()
                => string.Format("{0}:[{1}, {2}]", Group, MinSeq, MaxSeq);

            public override string ToString()
                => Format();
        }

    }
}