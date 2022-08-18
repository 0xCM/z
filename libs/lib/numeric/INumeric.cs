//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Sized;
    using static Refs;

    [Free]
    public interface INumeric : ISized, IDataType
    {
        bool IsZero {get;}

        bool IsNonZero {get;}

        bool INullity.IsEmpty
            => IsZero;

        bool INullity.IsNonEmpty
            => IsNonZero;
    }

    [Free]
    public interface INumeric<T> : INumeric, ISized<T>, IDataType<T>, IValued<T>, IAdditive<T>
        where T : unmanaged, IDataType<T>
    {

        T IAdditive<T>.Add(T src)
            => @as<T>(bw64(Value) + bw64(src));

        Hash32 IHashed.Hash
            => HashCodes.hash(Value);

        bool INumeric.IsZero
            => bw64(Value) == 0;

        bool INumeric.IsNonZero
            => bw64(Value) != 0;

        bool IEquatable<T>.Equals(T src)
            =>  bw64(Value) == bw64(src);

        int IComparable<T>.CompareTo(T src)
            =>  bw64(Value).CompareTo(bw64(src));
    }
}