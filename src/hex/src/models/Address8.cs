//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using A = Address8;
    using W = W8;
    using T = System.Byte;

    public readonly struct Address8 : IAddress<A,T>
    {
        public const NativeSizeCode StorageSize = NativeSizeCode.W8;

        public T Location {get;}

        [MethodImpl(Inline)]
        public Address8(T offset)
            => Location = offset;

        public static W W => default;

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Location;
        }

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

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => Hash;

        public override bool Equals(object src)
            => src is A a && Equals(a);

        public static A Empty
            => new A(0);

        [MethodImpl(Inline)]
        public static implicit operator A(T src)
            => new A(src);

        [MethodImpl(Inline)]
        public static implicit operator T(A src)
            => src.Location;

        [MethodImpl(Inline)]
        public static explicit operator A(MemoryAddress src)
            => new A((byte)src.Location);

        [MethodImpl(Inline)]
        public static implicit operator Address<W,T>(A src)
            => new Address<W,T>(src.Location);

        [MethodImpl(Inline)]
        public static implicit operator A(Address<W,T> src)
            => new A(src.Location);

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

        public static A Zero
        {
             [MethodImpl(Inline)]
             get => Empty;
        }
    }
}