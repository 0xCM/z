//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IRepository<K,S,T>
    {
        void Store(S src, T dst);

        S Load(K key);
    }

    [Schema]
    public abstract record class Schema : ISchema
    {

    }

    public interface ISchema
    {


    }

    public interface ISchema<S> : ISchema
        where S : ISchema<S>, new()
    {

    }


    public abstract class Schema<S,K>
        where S : Schema<S>, new()
        where K : unmanaged
    {


    }

    public abstract record class Schema<S> : ISchema, ISchema<S>
        where S : ISchema<S>, new()
    {
        public static S Empy = new();
    }

    public abstract class Repository<K,S,T> : IRepository<K,S,T>
    {
        public abstract void Store(S src, T dst);

        public abstract S Load(K key);
    }
}