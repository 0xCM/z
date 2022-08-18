//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface INatBytes<F,N> : IByteSeq<F>, IEquatable<F>, INullary<F>, ICounted<uint>
        where F : struct, INatBytes<F,N>
        where N : unmanaged, ITypeNat
    {
        F Empty()
            => new F();

        F Load(F src)
            => Empty().Load(src);

        uint ICounted<uint>.Count
            => (uint)default(N).NatValue;

        F IContented<F>.Content
            => (F)this;

        ByteSize ISized.ByteCount
            =>default(N).NatValue;

        BitWidth ISized.BitWidth
            => Count*8;

        int IByteSeq.Capacity
            => Length;

        int IByteSeq.Length
            => (int)Count;

        F INullary<F>.Zero
            => new F();
    }
}