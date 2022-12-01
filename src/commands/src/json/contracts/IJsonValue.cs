//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IJsonValue : IJsonNode
    {
        T GetValue<T>();

        bool TryGetValue<T>(out T value);
    }

    public interface IJsonValue<V> : IJsonValue
        where V : new()
    {
        V Value {get;}
    }    
}