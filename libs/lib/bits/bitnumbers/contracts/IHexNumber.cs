//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IHexNumber : INumeric
    {

    }

    public interface IHexNumber<K> : IHexNumber
        where K : unmanaged, INumeric<K>
    {

    }

    public interface IHexNumber<F,K> : IHexNumber<K>, IDataType<F>
        where K : unmanaged, INumeric<K>
        where F : unmanaged, IHexNumber<F,K>
    {
        BitWidth ISized.BitWidth
            => Sized.width<F>();

        ByteSize ISized.ByteCount
            => Sized.size<F>();
    }

    public interface IHexNumber<F,W,K> : IHexNumber, IDataType<F>
        where F : unmanaged, IHexNumber<F,W,K>
        where K : unmanaged
        where W : unmanaged, IDataWidth
    {
        BitWidth ISized.BitWidth
            => default(W).BitWidth;

        ByteSize ISized.ByteCount
            => default(W).BitWidth/8;
    }
}