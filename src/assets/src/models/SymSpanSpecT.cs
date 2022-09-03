//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly ref struct SymSpanSpec<T>
        where T : unmanaged
    {
        public readonly string Name;

        public readonly ReadOnlySpan<Sym<T>> Data;

        public readonly bool IsStatic;

        public readonly string CellType;

        [MethodImpl(Inline)]
        public SymSpanSpec(string name, ReadOnlySpan<Sym<T>> data, bool isStatic = true, string type = null)
        {
            Name = name;
            Data = data;
            IsStatic = isStatic;
            CellType = type ?? typeof(T).Name;
        }

        public uint CellCount
        {
            [MethodImpl(Inline)]
            get => (uint)Data.Length;
        }
    }
}