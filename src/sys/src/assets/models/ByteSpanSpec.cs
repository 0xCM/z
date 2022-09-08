//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public readonly struct ByteSpanSpec
    {
        public readonly Identifier Name;

        public readonly BinaryCode Data;

        public readonly bool IsStatic;

        public readonly string CellType;

        [MethodImpl(Inline)]
        public ByteSpanSpec(string name, byte[] data, bool isStatic = true)
        {
            Name = name;
            Data = data;
            IsStatic = isStatic;
            CellType = "byte";
        }

        public ref byte FirstByte
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

        [MethodImpl(Inline)]
        public ReadOnlySpan<byte> Segment(ByteSize offset, ByteSize size)
            => slice(Data.View, offset, size);
    }
}