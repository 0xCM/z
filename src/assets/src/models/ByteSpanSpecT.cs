//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ByteSpanSpec<T>
        where T : unmanaged
    {
        public readonly Identifier Name;

        public readonly Index<T> Data;

        public readonly bool IsStatic;

        public readonly string CellType;

        [MethodImpl(Inline)]
        public ByteSpanSpec(string name, T[] data, bool isStatic = true)
        {
            Name = name;
            Data = data;
            IsStatic = isStatic;
            CellType = "byte";
        }

        public ref T FirstCell
        {
            [MethodImpl(Inline)]
            get => ref Data.First;
        }

        public uint CellCount
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public ByteSize DataSize
        {
            [MethodImpl(Inline)]
            get => Data.Size;
        }
    }
}