//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public record class ColumDef
    {
        public readonly ushort Index;

        public readonly Identifier Name;

        public readonly Identifier DataType;

        [MethodImpl(Inline)]
        public ColumDef(ushort index, string name, Identifier type)
        {
            Index = index;
            Name = name;
            DataType = type;
        }

        public string Format()
            => string.Format("[{0:D2} {1}:{2}]", Index, Name, DataType);

        public override string ToString()
            => Format();
    }
}