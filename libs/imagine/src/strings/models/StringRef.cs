//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using api = StringRefs;

    /// <summary>
    /// Defines a reference to an immutable character sequence
    /// </summary>
    public unsafe readonly struct StringRef : IMemoryString<StringRef,char>
    {
        public readonly MemoryAddress Address;

        public readonly int Length;

        [MethodImpl(Inline)]
        public StringRef(MemoryAddress @base, uint length)
        {
            Address = @base;
            Length = (int)length;
        }

        public int Capacity
        {
            [MethodImpl(Inline)]
            get => Length;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Length == 0 || Address == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Length != 0 || Address != 0;
        }

        public ref readonly char this[ulong index]
        {
            [MethodImpl(Inline)]
            get => ref seek(Address.Ref<char>(), index);
        }

        public ref readonly char this[long index]
        {
            [MethodImpl(Inline)]
            get => ref seek(Address.Ref<char>(), index);
        }

        public ByteSize ByteCount
        {
            [MethodImpl(Inline)]
            get => Length*size<char>();
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => hash(Cells);
        }

        public override int GetHashCode()
            => Hash;

        int IByteSeq.Length 
            => Length;

        public ReadOnlySpan<char> Cells
        {
            [MethodImpl(Inline)]
            get => cover<char>(Address.Pointer<char>(), Length);
        }

        public ReadOnlySpan<byte> Bytes
        {
            [MethodImpl(Inline)]
            get => cover(Address.Pointer<byte>(), ByteCount);
        }

        MemoryAddress IAddressable.Address
            => Address;

        public bool Equals(StringRef src)
            => Algs.eq(Cells,src.Cells);

        public int CompareTo(StringRef src)
            => Cells.CompareTo(src.Cells, StringComparison.InvariantCulture);

        public string Format()
            => api.format(this);


        public override string ToString()
            => Format();

        public static StringRef Empty
        {
            [MethodImpl(Inline)]
            get => new StringRef(0,0);
        }
    }
}