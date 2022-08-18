//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;

    public unsafe readonly record struct Label : IMemoryString<Label,char>
    {
        /// <summary>
        /// Creates a label from an embedded string
        /// </summary>
        /// <param name="src"></param>
        [MethodImpl(Inline), Op]
        public static Label FromFixed(string src)
        {
            if(empty(src))
                return Label.Empty;
            StringAddress a = src;
            return new Label(a.Address, (byte)src.Length);
        }

        readonly ulong Data;

        public Label()
        {
            Data = 0;
        }

        [MethodImpl(Inline)]
        public Label(MemoryAddress @base, byte length)
        {
            Data = (ulong)@base | ((ulong)length << 56);
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => (byte)(Data >> 56);
        }

        public int Capacity
        {
            [MethodImpl(Inline)]
            get => Length;
        }

        public ByteSize ByteCount
        {
            [MethodImpl(Inline)]
            get => Length*2;
        }

        public MemoryAddress Address
        {
            [MethodImpl(Inline)]
            get => (MemoryAddress)(Data & 0x00FFFFFF_FFFFFFFFul);
        }

        public ReadOnlySpan<char> Cells
        {
            [MethodImpl(Inline)]
            get => Algs.cover(Address.Pointer<char>(), Length);
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => hash(Cells);
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Data != 0;
        }

        public bool Equals(Label src)
            => Algs.eq(Cells,src.Cells);

        public int CompareTo(Label src)
            => Cells.CompareTo(src.Cells, StringComparison.InvariantCulture);

        public string Format()
            => new string(Cells);

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => (int)Hash;

        [MethodImpl(Inline), Op]
        public static implicit operator Label(string src)
            => FromFixed(src);

        public static Label Empty => default;
    }
}