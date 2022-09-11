//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = MemoryScales;

    public readonly record struct MemoryScale<T>
        where T : unmanaged
    {

    }
    [DataWidth(4)]
    public readonly record struct MemoryScale : IComparable<MemoryScale>
    {
        public readonly ScaleFactor Factor;

        [MethodImpl(Inline)]
        public MemoryScale(ScaleFactor kind)
            => Factor = kind;

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Factor == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Factor != 0;
        }

        public bool IsNonUnital
        {
             [MethodImpl(Inline)]
             get => Factor != ScaleFactor.S1;
        }

        public bool IsNonZero
        {
            [MethodImpl(Inline)]
            get =>  Factor != 0;
        }

        public byte Value
        {
            [MethodImpl(Inline)]
            get => (byte) Factor;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => (byte)Factor;
        }

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public bool Equals(MemoryScale src)
            => Factor == src.Factor;

        public string Format()
            => IsNonZero ? ((byte)Factor).ToString() : EmptyString;

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public int CompareTo(MemoryScale src)
            => ((byte)Factor).CompareTo((byte)src.Factor);

        [MethodImpl(Inline)]
        public static MemoryAddress operator *(MemoryScale scale, MemoryAddress address)
            => (ulong)scale.Factor * address;

        [MethodImpl(Inline)]
        public static MemoryAddress operator *(MemoryAddress address, MemoryScale scale)
            => (ulong)scale.Factor * address;

        public static MemoryScale Empty
            => new MemoryScale(0);

        [MethodImpl(Inline)]
        public static implicit operator MemoryScale(int src)
            => api.scale((byte)src);

        [MethodImpl(Inline)]
        public static implicit operator byte(MemoryScale src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator MemoryScale(ScaleFactor src)
            => new MemoryScale(src);

        [MethodImpl(Inline)]
        public static implicit operator ScaleFactor(MemoryScale src)
            => src.Factor;
    }
}