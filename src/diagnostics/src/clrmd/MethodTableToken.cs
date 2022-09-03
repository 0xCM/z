//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct ClrMdRecords
    {
        [Record(TableId), StructLayout(LayoutKind.Sequential)]
        public struct MethodTableToken : IComparable<MethodTableToken>
        {
            const string TableId = "clr.md.methods";

            [Render(16)]
            public MemoryAddress Table;

            [Render(12)]
            public CliToken Method;

            [MethodImpl(Inline)]
            public MethodTableToken(MemoryAddress address, CliToken token)
            {
                Table = address;
                Method = token;
            }

            [MethodImpl(Inline)]
            public int CompareTo(MethodTableToken src)
            {
                var result = Table.CompareTo(src.Table);
                if(result == 0)
                    result = Method.CompareTo(src.Method);
                return result;
            }
        }
    }
}