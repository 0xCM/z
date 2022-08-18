//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    /// <summary>
    /// Defines a parametric displacement that may resolve to an 8-bit, 16-bit or 32-bit signed displacement
    /// </summary>
    public readonly record struct Disp<T> : IDisplacement
        where T : unmanaged, IDisplacement<T>
    {
        public readonly T Source;

        [MethodImpl(Inline)]
        public Disp(T src)
        {
            Source = src;
        }

        public long Value
        {
            [MethodImpl(Inline)]
            get => int64(Source.Value);
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => u32(Source);
        }

        public NativeSize Size
            => Sizes.native(width<T>());

        public bool Positive
        {
            [MethodImpl(Inline)]
            get => Value > 0;
        }

        public bool Negative
        {
            [MethodImpl(Inline)]
            get => Value < 0;
        }

        [MethodImpl(Inline)]
        public bool Equals(Disp<T> src)
            => Value == src.Value;

        public override int GetHashCode()
            => Hash;

        public string Format()
            => Disp.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Disp<T>(byte src)
            => new Disp<T>(@as<byte,T>(src));

        [MethodImpl(Inline)]
        public static implicit operator Disp<T>(Disp8 src)
            => new Disp<T>(@as<sbyte,T>(src.Value));

        [MethodImpl(Inline)]
        public static implicit operator Disp<T>(short src)
            => new Disp<T>(@as<short,T>(src));

        [MethodImpl(Inline)]
        public static implicit operator Disp<T>(Disp16 src)
            => new Disp<T>(@as<short,T>(src.Value));

        [MethodImpl(Inline)]
        public static implicit operator Disp<T>(int src)
            => new Disp<T>(@as<int,T>(src));

        [MethodImpl(Inline)]
        public static implicit operator Disp<T>(Disp32 src)
            => new Disp<T>(@as<int,T>(src.Value));

        [MethodImpl(Inline)]
        public static implicit operator Disp(Disp<T> src)
            => new Disp(src.Value, src.Size);

        [MethodImpl(Inline)]
        public static implicit operator Disp<T>(Disp64 src)
            => new Disp<T>(@as<long,T>(src.Value));

        [MethodImpl(Inline)]
        public static implicit operator T(Disp<T> src)
            => src.Source;
    }
}