//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IBitNumber : IHashed, IBits
    {
        Span<bit> _Bits
            => throw new NotImplementedException();

        void Bits<B>(B dst)
            where B : unmanaged, IStorageBlock<B>
        {
            var src = sys.recover<bit,byte>(_Bits);
            var buffer = dst.Bytes;
            for(var i=0; i<Width; i++)
                sys.seek(buffer,i) = sys.skip(src,i);
        }

        bool IsZero {get;}

        bool IsNonZero
            => !IsZero;
    }

    public interface IBitNumber<F> : IBitNumber, IEquatable<F>, IComparable<F>
        where F : unmanaged, IBitNumber<F>
    {

    }

    public interface IBitNumber<F,T> : IBitNumber<F>, INullary<F,T>, IHashed, IBits<T>
        where F : unmanaged, IBitNumber<F,T>
        where T : unmanaged
    {

    }

    public interface IBitNumber<F,W,T> : IBitNumber<F,T>
        where F : unmanaged, IBitNumber<F,W,T>
        where W : unmanaged, IDataWidth
        where T : unmanaged
    {

    }

    public interface IBitNumber<F,W,K,T> : IBitNumber<F,W,T>
        where F : unmanaged, IBitNumber<F,W,K,T>
        where W : unmanaged, IDataWidth
        where K : unmanaged
        where T : unmanaged
    {

    }
}