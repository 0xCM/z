//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly ref struct SymSpanSpec
    {
        public readonly Identifier Name;

        public readonly ReadOnlySpan<Sym> Data;

        public readonly bool IsStatic;

        public readonly string CellType;

        [MethodImpl(Inline)]
        public SymSpanSpec(string name, ReadOnlySpan<Sym> data, bool isStatic, string type)
        {
            Name = name;
            Data = data;
            IsStatic = isStatic;
            CellType = type;
        }

        public uint CellCount
        {
            [MethodImpl(Inline)]
            get => (uint)Data.Length;
        }
    }
}