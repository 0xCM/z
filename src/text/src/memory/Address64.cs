//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using A = Address64;
    using W = W64;
    using T = System.UInt64;

    public readonly struct Address64 : IAddress<A,T>
    {
        public const NativeSizeCode StorageSize = NativeSizeCode.W64;

        public T Location {get;}

        [MethodImpl(Inline)]
        public Address64(T offset)
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

        public Address32 Lo
        {
            [MethodImpl(Inline)]
            get => (uint)Location;
        }

        public Address32 Hi
        {
            [MethodImpl(Inline)]
            get => (uint)(Location >> 32);
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => HashCodes.hash(Location);
        }

        [MethodImpl(Inline)]
        public bool Between(A min, A max)
            => this >= min && this <= max;

        [MethodImpl(Inline)]
        public bool Equals(A src)
            => Location == src.Location;

        [MethodImpl(Inline)]
        public int CompareTo(A src)
            => Location == src.Location ? 0 : Location < src.Location ? -1 : 1;

        [MethodImpl(Inline)]
        public string Format()
            => HexFormatter.format(Location, NumericSpecifier.PreSpec, LetterCaseKind.Lower, W);

        public string FormatMinimal()
            => Location.FormatTrimmedAsmHex();

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => Location.GetHashCode();

        public override bool Equals(object src)
            => src is A a && Equals(a);

        [MethodImpl(Inline)]
        public static implicit operator MemoryAddress(Address64 src)
            => src.Location;

        [MethodImpl(Inline)]
        public static implicit operator Address64(IntPtr src)
            => (ulong)src.ToInt64();

        [MethodImpl(Inline)]
        public static implicit operator ulong(A src)
            => src.Location;

        [MethodImpl(Inline)]
        public static implicit operator Address<W,T>(A src)
            => new Address<W,T>(src.Location);

        [MethodImpl(Inline)]
        public static implicit operator A(Address<W,T> src)
            => new A(src.Location);

        [MethodImpl(Inline)]
        public static implicit operator A(T src)
            => new A(src);

        [MethodImpl(Inline)]
        public static A operator+(A x, T y)
            => new A((T)(x.Location + y));

        [MethodImpl(Inline)]
        public static bool operator <(A a, A b)
            => a.Location < b.Location;

        [MethodImpl(Inline)]
        public static bool operator >(A a, A b)
            => a.Location > b.Location;

        [MethodImpl(Inline)]
        public static bool operator <=(A a, A b)
            => a.Location <= b.Location;

        [MethodImpl(Inline)]
        public static bool operator >=(A a, A b)
            => a.Location >= b.Location;

        [MethodImpl(Inline)]
        public static bool operator==(A x, A y)
            => x.Location == y.Location;

        [MethodImpl(Inline)]
        public static bool operator!=(A x, A y)
            => x.Location != y.Location;

        public static A Empty
            => new A(0);

        public static A Zero
        {
             [MethodImpl(Inline)]
             get => 0;
        }
    }
}