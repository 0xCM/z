//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct Address<W,T> : IAddress<Address<W,T>,T>
        where W : unmanaged, INumericWidth
        where T : unmanaged
    {
        public T Location {get;}

        public NativeSize Capacity
        {
            [MethodImpl(Inline)]
            get => Sized.native<T>();
        }

        ulong Location64
        {
            [MethodImpl(Inline)]
            get => Numeric.force<T,ulong>(Location);
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => HashCodes.hash(Location);
        }

        public bool IsNonZero
        {
            [MethodImpl(Inline)]
            get => Location64 != 0;
        }

        public string Identifier
            => Numeric.force<T,ulong>(Location).ToString("x") + "h";

        [MethodImpl(Inline)]
        public Address(ulong absolute)
            => Location = Numeric.force<ulong,T>(absolute);

        public string Format()
            => Identifier;

        public string Format(int digits)
            => Location64.ToString($"x{digits}") + "h";

        [MethodImpl(Inline)]
        public int CompareTo(Address<W,T> other)
            => this == other ? 0 : this < other ? -1 : 1;

        [MethodImpl(Inline)]
        public bool Equals(Address<W,T> src)
            => Location64 == src.Location64;

        public override bool Equals(object obj)
            => obj is Address<W,T> x && Equals(x);

        public override int GetHashCode()
            => Location.GetHashCode();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public unsafe P* ToPointer<P>()
            where P : unmanaged
                => (P*)Location64;

        [MethodImpl(Inline)]
        public static explicit operator byte(Address<W,T> src)
            => (byte)src.Location64;

        [MethodImpl(Inline)]
        public static explicit operator ushort(Address<W,T> src)
            => (ushort)src.Location64;

        [MethodImpl(Inline)]
        public static explicit operator uint(Address<W,T> src)
            => (uint)src.Location64;

        [MethodImpl(Inline)]
        public static explicit operator ulong(Address<W,T> src)
            => src.Location64;

        [MethodImpl(Inline)]
        public static bool operator==(Address<W,T> a, Address<W,T> b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator!=(Address<W,T> a, Address<W,T> b)
            => !a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator<(Address<W,T> a, Address<W,T> b)
            => a.Location64 < b.Location64;

        [MethodImpl(Inline)]
        public static bool operator>(Address<W,T> a, Address<W,T> b)
            => a.Location64 > b.Location64;

        [MethodImpl(Inline)]
        public static bool operator<=(Address<W,T> a, Address<W,T> b)
            => a.Location64 <= b.Location64;

        [MethodImpl(Inline)]
        public static bool operator>=(Address<W,T> a, Address<W,T> b)
            => a.Location64 >= b.Location64;

        [MethodImpl(Inline)]
        public static Address<W,T> operator+(Address<W,T> a, Address<W,T> b)
            => new Address<W,T>(a.Location64 + b.Location64);

        [MethodImpl(Inline)]
        public static Address<W,T> operator-(Address<W,T> a, Address<W,T> b)
            => new Address<W,T>(a.Location64 - b.Location64);

        public static Address<W,T> Zero
            => default;
    }
}