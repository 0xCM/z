//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class StringMatcher
    {
        [Record(TableId), StructLayout(LayoutKind.Sequential, Pack=1)]
        public struct CharMatchRow : IComparable<CharMatchRow>
        {
            public const string TableId = "strings.match";

            public const byte FieldCount = 7;

            [Render(6)]
            public uint Seq;

            [Render(10)]
            public CharGroup Group;

            [Render(6)]
            public Constant<char> Char;

            [Render(6)]
            public ushort Pos;

            [Render(14)]
            public ushort TargetLength;

            [Render(14)]
            public uint TargetId;

            [Render(1)]
            public Constant<string> Target;

            public int CompareTo(CharMatchRow src)
            {
                var i = TargetLength.CompareTo(src.TargetLength);
                if(i == 0)
                    i = Pos.CompareTo(src.Pos);
                if(i == 0)
                    i = Char.Value.CompareTo(src.Char.Value);
                return i;
            }
        }
    }
}