//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public interface ISymKey : ITextual
    {
        uint Value {get;}

        string ITextual.Format()
            => Value.ToString();
    }

    public interface ISymKey<K,T> : ISymKey, IEquatable<K>, IComparable<K>
        where T : unmanaged
        where K : unmanaged, ISymKey<K,T>
    {
        new T Value {get;}

        string ITextual.Format()
            => Value.ToString();

        uint ISymKey.Value
            => bw32(Value);
    }
}