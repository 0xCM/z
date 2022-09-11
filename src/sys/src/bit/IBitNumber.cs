//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IBitNumber : IHashed, IBits
    {
        bool IsZero {get;}

        bool IsNonZero
            => !IsZero;
    }

    [Free]
    public interface IBitNumber<F> : IBitNumber, IEquatable<F>, IComparable<F>
        where F : unmanaged, IBitNumber<F>
    {

    }

    [Free]
    public interface IBitNumber<F,T> : IBitNumber<F>, INullary<F,T>, IHashed, IBits<T>
        where F : unmanaged, IBitNumber<F,T>
        where T : unmanaged
    {

    }

    [Free]
    public interface IBitNumber<F,W,T> : IBitNumber<F,T>
        where F : unmanaged, IBitNumber<F,W,T>
        where W : unmanaged, IDataWidth
        where T : unmanaged
    {

    }

    [Free]
    public interface IBitNumber<F,W,K,T> : IBitNumber<F,W,T>
        where F : unmanaged, IBitNumber<F,W,K,T>
        where W : unmanaged, IDataWidth
        where K : unmanaged
        where T : unmanaged
    {

    }
}