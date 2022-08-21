//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using A = MemoryAddress;

    public unsafe readonly struct MemoryAddress : IDataType<MemoryAddress>, IDataString<MemoryAddress>
    {
        public const NativeSizeCode StorageSize = NativeSizeCode.W64;

        public ulong Location {get;}

        [MethodImpl(Inline)]
        public MemoryAddress(ulong absolute)
            => Location = absolute;

        [MethodImpl(Inline)]
        public MemoryAddress(void* pSrc)
            => Location = (ulong)pSrc;

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

        public string Format()
            => Location.ToString("x") + HexFormatSpecs.PostSpec;

        static string asmhex(ulong src, int? digits = null)
            => digits.Map(n => src.ToString($"x{n}"), () => src.ToString("x")) + HexFormatSpecs.PostSpec;

        public string Format(byte pad)
            => asmhex(Location,pad);

        [MethodImpl(Inline)]
        public int CompareTo(MemoryAddress src)
            => Location == src.Location ? 0 : Location < src.Location ? -1 : 1;

        [MethodImpl(Inline)]
        public bool Equals(MemoryAddress src)
            => Location == src.Location;

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => HashCodes.hash(Location);
        }

        [MethodImpl(Inline)]
        public unsafe ref T Ref<T>()
            => ref Unsafe.AsRef<T>((void*)Location);

        [MethodImpl(Inline)]
        public unsafe void* Pointer()
            => (void*)Location;

        public override int GetHashCode()
            => (int)Hash;

        public override bool Equals(object obj)
            => obj is MemoryAddress a && Equals(a);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public unsafe T* Pointer<T>()
            where T : unmanaged
                => (T*)Location;

        [MethodImpl(Inline)]
        public ref T As<T>()
        {
            var pSrc = Pointer();
            return ref sys.@as<T>(pSrc);
        }

        [MethodImpl(Inline)]
        public static implicit operator MemoryAddress(void* pSrc)
            => new MemoryAddress(pSrc);

        [MethodImpl(Inline)]
        public static explicit operator char*(MemoryAddress src)
            => (char*)src.Location;

        [MethodImpl(Inline)]
        public static explicit operator sbyte*(MemoryAddress src)
            => (sbyte*)src.Location;

        [MethodImpl(Inline)]
        public static explicit operator byte*(MemoryAddress src)
            => (byte*)src.Location;

        [MethodImpl(Inline)]
        public static explicit operator short*(MemoryAddress src)
            => (short*)src.Location;

        [MethodImpl(Inline)]
        public static explicit operator ushort*(MemoryAddress src)
            => (ushort*)src.Location;

        [MethodImpl(Inline)]
        public static explicit operator int*(MemoryAddress src)
            => (int*)src.Location;

        [MethodImpl(Inline)]
        public static explicit operator uint*(MemoryAddress src)
            => (uint*)src.Location;

        [MethodImpl(Inline)]
        public static explicit operator long*(MemoryAddress src)
            => (long*)src.Location;

        [MethodImpl(Inline)]
        public static explicit operator ulong*(MemoryAddress src)
            => (ulong*)src.Location;

        [MethodImpl(Inline)]
        public static explicit operator void*(MemoryAddress src)
            => (void*)src.Location;

        [MethodImpl(Inline)]
        public static implicit operator A(IntPtr src)
            => new A((ulong)src.ToInt64());

        [MethodImpl(Inline)]
        public static implicit operator A(UIntPtr src)
            => new A(src.ToUInt64());

        [MethodImpl(Inline)]
        public static implicit operator IntPtr(A src)
            => (IntPtr)src.Location;

        [MethodImpl(Inline)]
        public static implicit operator long(A src)
            => (long)src.Location;

        [MethodImpl(Inline)]
        public static implicit operator ulong(A src)
            => src.Location;

        [MethodImpl(Inline)]
        public static implicit operator A(ulong src)
            => new A(src);

        [MethodImpl(Inline)]
        public static explicit operator A(long src)
            => new A((ulong)src);

        [MethodImpl(Inline)]
        public static explicit operator A(int src)
            => new A((uint)src);

        [MethodImpl(Inline)]
        public static explicit operator A(ushort src)
            => new A(src);

        [MethodImpl(Inline)]
        public static explicit operator A(short src)
            => new A((ushort)src);

        [MethodImpl(Inline)]
        public static explicit operator ushort(A src)
            => (ushort)src.Location;

        [MethodImpl(Inline)]
        public static explicit operator uint(A src)
            => (uint)src.Location;

        [MethodImpl(Inline)]
        public static explicit operator ByteSize(A src)
            => new ByteSize((ulong)src.Location);

        [MethodImpl(Inline)]
        public static bool operator==(A a, A b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator!=(A a, A b)
            => !a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator<(A a, A b)
            => a.Location < b.Location;

        [MethodImpl(Inline)]
        public static bool operator>(A a, A b)
            => a.Location > b.Location;

        [MethodImpl(Inline)]
        public static bool operator<=(A a, A b)
            => a.Location <= b.Location;

        [MethodImpl(Inline)]
        public static bool operator>=(A a, A b)
            => a.Location >= b.Location;

        [MethodImpl(Inline)]
        public static A operator+(A a, A b)
            => new A(a.Location + b.Location);

        [MethodImpl(Inline)]
        public static A operator+(A a, byte* b)
            => new A(a.Location + (ulong)b);

        [MethodImpl(Inline)]
        public static A operator+(A a, ushort* b)
            => new A(a.Location + (ulong)b);

        [MethodImpl(Inline)]
        public static A operator+(A a, uint* b)
            => new A(a.Location + (ulong)b);

        [MethodImpl(Inline)]
        public static A operator+(A a, ulong* b)
            => new A(a.Location + (ulong)b);

        [MethodImpl(Inline)]
        public static A operator+(A a, void* b)
            => new A(a.Location + (ulong)b);

        [MethodImpl(Inline)]
        public static A operator+(A a, ByteSize b)
            => new A(a.Location + (ulong)b);

        [MethodImpl(Inline)]
        public static A operator+(A a, byte size)
            => new A(a.Location + size);

        [MethodImpl(Inline)]
        public static A operator+(A a, ushort size)
            => new A(a.Location + size);

        [MethodImpl(Inline)]
        public static A operator++(A a)
            => new A(a.Location + 1);

        [MethodImpl(Inline)]
        public static A operator--(A a)
            => new A(a.Location - 1);

        [MethodImpl(Inline)]
        public static A operator+(A a, uint size)
            => new A(a.Location + size);

        [MethodImpl(Inline)]
        public static A operator+(A a, ulong size)
            => new A(a.Location + size);

        [MethodImpl(Inline)]
        public static A operator-(A a, A b)
            => new A(a.Location - b.Location);

        public static A Zero
            => new A(0);
    }
}