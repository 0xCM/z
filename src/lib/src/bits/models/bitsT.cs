//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    /// <summary>
    /// Defines a bit sequence representation compatible with both llvm and SMTLib 'FixedSizeBitVectors' theory
    /// </summary>
    public record struct bits<T>
        where T : unmanaged
    {
        const char DefaultSep = Chars.Comma;

        public T Packed;

        public uint N;

        [MethodImpl(Inline)]
        public bits(uint n, T src)
        {
            N = n;
            Packed = src;
        }

        [MethodImpl(Inline)]
        public bits(T src)
        {
            N = sys.width<T>();
            Packed = src;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => hash((ulong)this);
        }

        public override int GetHashCode()
            => Hash;

        public bit this[uint pos]
        {
            [MethodImpl(Inline)]
            get => bit.test(Packed, pos);
            [MethodImpl(Inline)]
            set => Packed = @as<ulong,T>(bit.set(@as<T,ulong>(Packed), (byte)pos, value));
        }

        public string Format(CharFence fence, char sep = (char)0)
        {
            var dst = text.buffer();
            BitRender.render(N, fence, sep, Packed, dst);
            return dst.Emit();
        }

        public string Format()
        {
            var dst = text.buffer();
            BitRender.render(N, Fenced.Embraced, DefaultSep, Packed, dst);
            return dst.Emit();
        }


        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public S Convert<S>()
            where S : unmanaged
                => @as<T,S>(Packed);

        [MethodImpl(Inline)]
        public bool Equals(bits<T> src)
            => (ulong)this == (ulong)src;

        [MethodImpl(Inline)]
        public static implicit operator bits<T>((uint n, T value) src)
            => new bits<T>(src.n, src.value);

        [MethodImpl(Inline)]
        public static implicit operator bits<T>(T src)
            => new bits<T>(src);

        [MethodImpl(Inline)]
        public static implicit operator T(bits<T> src)
            => src.Packed;

        [MethodImpl(Inline)]
        public static explicit operator ulong(bits<T> src)
            => u64(src.Packed);

        public static bits<T> Zero => default;
    }
}