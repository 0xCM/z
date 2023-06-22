//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct RelAddress<T> : IDataType<RelAddress<T>>
        where T : unmanaged, IAddress
    {
        public readonly MemoryAddress Base;

        public readonly T Offset;

        [MethodImpl(Inline)]
        public RelAddress(MemoryAddress @base, T offset)
        {
            Base = @base;
            Offset = offset;
        }

        public DataWidth Grain
        {
            [MethodImpl(Inline)]
            get => sys.width<T>();
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

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => sys.hash(Offset);
        }

        [MethodImpl(Inline)]
        public string Format()
            => EmptyString;

        public bool Equals(RelAddress<T> src)
            => Offset.Equals(src.Offset);

        [MethodImpl(Inline)]
        public MemoryAddress Resolve()
            => Base + sys.u64(Offset);
            
        public int CompareTo(RelAddress<T> src)
            => Resolve().CompareTo(src.Resolve());

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => (int)Hash;

        public override bool Equals(object src)
            => src is RelAddress l && Equals(l);

        [MethodImpl(Inline)]
        public static bool operator==(RelAddress<T> x, RelAddress<T> y)
            => x.Equals(y);

        [MethodImpl(Inline)]
        public static bool operator!=(RelAddress<T> x, RelAddress<T> y)
            => !x.Equals(y);

        public static RelAddress<T> Empty
            => default;
    }
}