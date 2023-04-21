//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Ecma
    {
        [Record(TableName)]
        public record struct TypeLayout
        {
            const string TableName = "types.layout";

            public LayoutKind Kind;

            public uint Size;

            public uint Pack;

            public TypeLayout(LayoutKind kind, uint size, uint pack)
            {
                Kind = kind;
                Size = size;
                Pack = pack;
            }

            public static TypeLayout Empty => default;
        }
    }
}