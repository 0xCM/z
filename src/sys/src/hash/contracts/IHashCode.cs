//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [Free]
    public interface IHashCode : IExpr, ISized
    {
        ReadOnlySpan<byte> Data {get;}

        ByteSize ISized.ByteCount
            => Data.Length;

        BitWidth ISized.BitWidth
            => Data.Length*8;

        bool INullity.IsEmpty
            => bw64u(Data) == 0;

        bool INullity.IsNonEmpty
            => bw64u(Data) != 0;
    }

    [Free]
    public interface IHashCode<V> : IHashCode
        where V : unmanaged
     {
         V Value {get;}

        string IExpr.Format()
            => Value.ToString();

        ReadOnlySpan<byte> IHashCode.Data
            => bytes(Value);
    }

    [Free]
    public interface IHashCode<H,V> : IHashCode<V>
        where H : unmanaged, IHashCode<H,V>
        where V : unmanaged
    {

    }
}