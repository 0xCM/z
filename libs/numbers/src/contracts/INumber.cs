//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface INumber
    {
        byte PackedWidth {get;}

        ulong Value {get;}

    }

    [Free]
    public interface INumber<T> : INumber, IEquatable<T>, IComparable<T>
        where T : unmanaged, INumber<T>
    {
    }
}