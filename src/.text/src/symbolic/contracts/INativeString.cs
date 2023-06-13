//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [Free]
    public interface INativeString<S,K> : IString<S,K>
        where K : unmanaged, IEquatable<K>, IComparable<K>
        where S : unmanaged, INativeString<S,K>
    {

    }

    [Free]
    public interface INativeString<S,K,B> : INativeString<S,K>
        where K : unmanaged, IEquatable<K>, IComparable<K>
        where B : unmanaged, IStorageBlock<B>
        where S : unmanaged, INativeString<S,K,B>
    {

    }

    [Free]
    public interface IString8<S,B> : INativeString<S,AsciSymbol>, IUnmanaged<S>
        where B : unmanaged, IStorageBlock<B>
        where S : unmanaged, IString8<S,B>
    {
        BitWidth ISized.BitWidth
            => width<B>();

        ByteSize ISized.ByteCount
            => size<B>();

        int IByteSeq.Capacity
            => (int)size<B>();
    }

    [Free]
    public interface IString16<S,B> : INativeString<S,char>, IUnmanaged<S>
        where S : unmanaged, IString16<S,B>
        where B : unmanaged, ICharBlock<B>
    {
        BitWidth ISized.BitWidth
            => width<B>();

        ByteSize ISized.ByteCount
            => size<B>();

        int IByteSeq.Capacity
            => (int)size<B>()/2;
    }    
}