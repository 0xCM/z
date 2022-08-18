//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IHashCode : IExpr
    {
        ReadOnlySpan<byte> Data {get;}

        bool INullity.IsEmpty
            => Sized.bw64u(Data) == 0;
        bool INullity.IsNonEmpty
            => Sized.bw64u(Data) != 0;
    }

    [Free]
    public interface IHashCode<T> : IHashCode
        where T : unmanaged
     {
         T Value {get;}

        string IExpr.Format()
            => Value.ToString();

        ReadOnlySpan<byte> IHashCode.Data
            => sys.bytes(Value);
     }

    [Free]
    public interface IHashCode<H,T> : IHashCode<T>, IEquatable<H>, IComparable<H>
        where H : unmanaged, IHashCode<H,T>
        where T : unmanaged
    {

    }
}