//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [Free]
    public interface IToken
    {
        ulong Kind {get;}

        ulong Value {get;}
    }

    [Free]
    public interface IToken<T> : IToken
        where T : unmanaged
    {
        new T Kind {get;}

        new T Value {get;}

        ulong IToken.Kind
            => bw64(Kind);

        ulong IToken.Value
            => bw64(Value);
    }

    [Free]
    public interface IToken<K,V> : IToken<V>
        where K : unmanaged
        where V : unmanaged
    {
        new K Kind {get;}

        V IToken<V>.Kind
            => @as<K,V>(Kind);
    }

    [Free]
    public interface IToken<T,K,V> : IEquatable<T>, IToken<K,V>, IComparable<T>, IHashed
        where K : unmanaged
        where V : unmanaged
        where T : unmanaged
    {
        uint Id {get;}
    }

}