//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public record struct bits<M,T>
        where M : unmanaged, ITypeNat
        where T : unmanaged
    {
        const char DefaultSep = Chars.Comma;

        public static bool parse(string src, out bits<M,T> dst)
            => BitParser.parse(src, out dst);

        public T Packed;

        [MethodImpl(Inline)]
        public bits(T src)
        {
            Packed = src;
        }

        public uint N
        {
            [MethodImpl(Inline)]
            get => Typed.nat32u<M>();
        }

        public bit this[uint pos]
        {
            [MethodImpl(Inline)]
            get => bit.test(Packed, pos);
            [MethodImpl(Inline)]
            set => Packed = @as<ulong,T>(bit.set(@as<T,ulong>(Packed), (byte)pos, value));
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => hash((ulong)this);
        }

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public bool Equals(bits<T> src)
            => (ulong)this == (ulong)src;

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
        public static implicit operator bits<M,T>(T src)
            => new bits<M,T>(src);

        [MethodImpl(Inline)]
        public static implicit operator T(bits<M,T> src)
            => src.Packed;

        [MethodImpl(Inline)]
        public static explicit operator ulong(bits<M,T> src)
            => u64(src.Packed);

        public static bits<M,T> Zero => default;
    }
}