//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ICfgEntry : IHashed
    {
        @string Name {get;}

        ICfgValue Value {get;}

        Hash32 IHashed.Hash
            => Name.Hash | Value.Hash;
    }

    public interface ICfgEntry<T> : ICfgEntry
        where T : ICfgValue, new()
    {
        new T Value {get;}

        ICfgValue ICfgEntry.Value
            => Value;
    }

    public interface ICfgEntry<E,T> : ICfgEntry<T>
        where E : ICfgEntry<E,T>,new()
        where T : ICfgValue, new()
    {

    }
}
