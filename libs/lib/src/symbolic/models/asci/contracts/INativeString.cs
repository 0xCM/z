//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;

    [Free]
    public interface IString8<S,B> : INativeString<S,AsciSymbol>
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
    public interface IString16<S,B> : INativeString<S,char>
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