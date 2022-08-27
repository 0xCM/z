//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface ISizedString : IString
    {
        uint CharCapacity {get;}

        BitWidth StorageWidth {get;}

        BitWidth CharWidth {get;}

        BitWidth ISized.BitWidth
            => CharWidth*CharCapacity;
    }

    [Free]
    public interface ISizedString<F,T> : ISizedString, IString<F,T>
        where T : unmanaged, IEquatable<T>, IComparable<T>
        where F : unmanaged, ISizedString<F,T>
    {

    }
}