//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct RelativeAddress<T> : ITextual, INullity
        where T : unmanaged, IAddress
    {
        public readonly MemoryAddress Base;

        public readonly T Offset;

        [MethodImpl(Inline)]
        public RelativeAddress(MemoryAddress @base, T offset)
        {
            Base = @base;
            Offset = offset;
        }

        public DataWidth Grain
        {
            [MethodImpl(Inline)]
            get => core.width<T>();
        }

        public bool IsEmpty
        {
             [MethodImpl(Inline)]
             get => Offset.Equals(default);
        }

        public bool IsNonEmpty
        {
             [MethodImpl(Inline)]
             get => !Offset.Equals(default);
        }

        public uint Hash
        {
            [MethodImpl(Inline)]
            get => alg.ghash.calc(Offset);
        }

        [MethodImpl(Inline)]
        public string Format()
            => EmptyString;

        public bool Equals(RelativeAddress<T> src)
            => Offset.Equals(src.Offset);

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => (int)Hash;

        public override bool Equals(object src)
            => src is RelativeAddress l && Equals(l);

        [MethodImpl(Inline)]
        public static bool operator==(RelativeAddress<T> x, RelativeAddress<T> y)
            => x.Equals(y);

        [MethodImpl(Inline)]
        public static bool operator!=(RelativeAddress<T> x, RelativeAddress<T> y)
            => !x.Equals(y);

        public static RelativeAddress<T> Empty
            => default;
    }
}