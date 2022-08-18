//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// A byte, just one
    /// </summary>
    [Free]
    public interface IByte : IHashed, ISized, IValued<byte>
    {
        BitWidth IWidth
            => 8;

        ByteSize ISize
            => 1;

        Hash32 IHashed.Hash
            => Value;
    }

    [Free]
    public interface IByte<F> : IByte, IHashed, ISized<F>
        where F : unmanaged, IByte<F>
    {

    }
}