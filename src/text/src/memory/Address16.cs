//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using A = Address16;
    using W = W16;
    using T = System.UInt16;

    public readonly struct Address16 : IAddress<A,T>
    {
        public const NativeSizeCode StorageSize = NativeSizeCode.W16;

        public T Location {get;}

        [MethodImpl(Inline)]
        public Address16(T offset)
            => Location = offset;

        public static W W => default;

        public NativeSize Capacity
        {
            [MethodImpl(Inline)]
            get => StorageSize;
        }

        public bool IsEmpty
        {
             [MethodImpl(Inline)]
             get => Location == 0;
        }

        public bool IsNonEmpty
        {
             [MethodImpl(Inline)]
             get => Location != 0;
        }

        public bool IsNonZero
        {
            [MethodImpl(Inline)]
            get => Location != 0;
        }

        public Address8 Lo
        {
            [MethodImpl(Inline)]
            get => (byte)Location;
        }

        public Address8 Hi
        {
            [MethodImpl(Inline)]
            get => (byte)(Location >> 8);
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Location;
        }

        [MethodImpl(Inline)]
        public bool Between(A min, A max)
            => this >= min && this <= max;

        [MethodImpl(Inline)]
        public string Format()
            => HexFormatter.format(Location, NumericSpecifier.PreSpec, LetterCaseKind.Lower, W);

        public string FormatMinimal()
            => Location.FormatTrimmedAsmHex();

        [MethodImpl(Inline)]
        public bool Equals(A src)
            => Location == src.Location;

        [MethodImpl(Inline)]
        public int CompareTo(A src)
            => Location == src.Location ? 0 : Location < src.Location ? -1 : 1;

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => Hash;

        public override bool Equals(object src)
            => src is A a && Equals(a);

        [MethodImpl(Inline)]
        public static implicit operator MemoryAddress(Address16 src)
            => src.Location;

        [MethodImpl(Inline)]
        public static implicit operator A(T src)
            => new A(src);

        [MethodImpl(Inline)]
        public static implicit operator T(A src)
            => src.Location;

        [MethodImpl(Inline)]
        public static implicit operator Address<W,T>(A src)
            => new Address<W,T>(src.Location);

        [MethodImpl(Inline)]
        public static implicit operator A(Address<W,T> src)
            => new A(src.Location);

        [MethodImpl(Inline)]
        public static explicit operator Address16(MemoryAddress src)
            => new A((T)src.Location);

        [MethodImpl(Inline)]
        public static explicit operator Address16(Address64 src)
            => new A((T)src.Location);

        [MethodImpl(Inline)]
        public static implicit operator int(A src)
            => src.Location;

        [MethodImpl(Inline)]
        public static explicit operator ulong(A src)
            => src.Location;

        [MethodImpl(Inline)]
        public static A operator-(A a, A b)
            => new A((T)(a.Location - b.Location));

        [MethodImpl(Inline)]
        public static A operator+(A a, A b)
            => new A((T)(a.Location + b.Location));

        [MethodImpl(Inline)]
        public static A operator++(A a)
            => new A((T)(a.Location + 1));

        [MethodImpl(Inline)]
        public static A operator--(A a)
            => new A((T)(a.Location - 1));

        [MethodImpl(Inline)]
        public static bool operator==(A x, A y)
            => x.Location == y.Location;

        [MethodImpl(Inline)]
        public static bool operator!=(A x, A y)
            => x.Location != y.Location;

        public static A Zero
        {
             [MethodImpl(Inline)]
             get => Empty;
        }

       public static A Empty
            => new A(0);
    }
}