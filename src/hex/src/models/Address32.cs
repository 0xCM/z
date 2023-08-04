//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using A = Address32;
    using W = W32;
    using T = System.UInt32;

    public readonly struct Address32 : IAddress<A,T>
    {
        public const NativeSizeCode StorageSize = NativeSizeCode.W32;

        public T Location {get;}

        [MethodImpl(Inline)]
        public Address32(T offset)
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

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => HashCodes.hash(Location);
        }

        public Address16 Lo
        {
            [MethodImpl(Inline)]
            get => (ushort)Location;
        }

        public Address16 Hi
        {
            [MethodImpl(Inline)]
            get => (ushort)(Location >> 16);
        }

        [MethodImpl(Inline)]
        public bool Between(A min, A max)
            => this >= min && this <= max;

        [MethodImpl(Inline)]
        public bool Equals(A src)
            => Location == src.Location;

        public override bool Equals(object src)
            => src is A a && Equals(a);

        [MethodImpl(Inline)]
        public int CompareTo(A src)
            => Location == src.Location ? 0 : Location < src.Location ? -1 : 1;

        [MethodImpl(Inline)]
        public string Format()
             => HexFormatter.format(Location, NumericSpecifier.PreSpec, LetterCaseKind.Lower, W);

        public string FormatTrimmed(bool prespec = false, bool postspec = false)
            => Location.FormatTrimmedHex(prespec, postspec);

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public static implicit operator MemoryAddress(Address32 src)
            => src.Location;

        [MethodImpl(Inline)]
        public static implicit operator A(T src)
            => new A(src);

        [MethodImpl(Inline)]
        public static implicit operator A(byte src)
            => new A(src);

        [MethodImpl(Inline)]
        public static implicit operator A(ushort src)
            => new A(src);

        [MethodImpl(Inline)]
        public static explicit operator Address32(IntPtr src)
            => (uint)src.ToInt32();

        [MethodImpl(Inline)]
        public static explicit operator Address32(MemoryAddress src)
            => new Address32((uint)src);

        [MethodImpl(Inline)]
        public static implicit operator Address32(Address16 src)
            => new Address32(src);

        [MethodImpl(Inline)]
        public static implicit operator Address32(int src)
            => new A((uint)src);

        [MethodImpl(Inline)]
        public static implicit operator Address<W,T>(A src)
            => new Address<W,T>(src.Location);

        [MethodImpl(Inline)]
        public static implicit operator A(Address<W,T> src)
            => new A(src.Location);

        [MethodImpl(Inline)]
        public static explicit operator long(A src)
            => src.Location;

        [MethodImpl(Inline)]
        public static explicit operator ulong(A src)
            => src.Location;

        [MethodImpl(Inline)]
        public static explicit operator int(A src)
            => (int)src.Location;

        [MethodImpl(Inline)]
        public static explicit operator ushort(A src)
            => (ushort)src.Location;

        [MethodImpl(Inline)]
        public static explicit operator short(A src)
            => (short)src.Location;

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

       [MethodImpl(Inline)]
        public static A operator++(A a)
            => new A(a.Location + 1);

        [MethodImpl(Inline)]
        public static A operator--(A a)
            => new A(a.Location - 1);

        [MethodImpl(Inline)]
        public static A operator+(A x, T y)
            => new A((T)(x.Location + y));

        [MethodImpl(Inline)]
        public static A operator+(A a, A b)
            => new A(a.Location + b.Location);

        [MethodImpl(Inline)]
        public static A operator-(A a, A b)
            => new A(a.Location - b.Location);

        public static A Empty
            => new A(0);

        public static A Zero
        {
             [MethodImpl(Inline)]
             get => default;
        }
    }
}