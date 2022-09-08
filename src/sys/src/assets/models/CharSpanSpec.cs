//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public readonly struct CharSpanSpec
    {
        public readonly Identifier Name;

        public readonly string _Data;

        public readonly bool IsStatic;

        public readonly string CellType;

        [MethodImpl(Inline)]
        public CharSpanSpec(string name, string data, bool isStatic = true)
        {
            Name = name;
            _Data = data;
            IsStatic = isStatic;
            CellType = "char";
        }

        public ReadOnlySpan<char> Data
        {
            get => _Data;
        }

        public ref readonly char FirstCell
        {
            [MethodImpl(Inline)]
            get => ref first(Data);
        }

        public uint CellCount
        {
            [MethodImpl(Inline)]
            get => (uint)Data.Length;
        }

        public ByteSize DataSize
        {
            [MethodImpl(Inline)]
            get => CellCount*2;
        }
    }
}