//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface ISettingProvider
    {
        Name Name {get;}

        ReadOnlySpan<Name> Names {get;}

        string ToString();

        string Format() => ToString();
    }

    [Free]
    public interface ISettingProvider<V> : ISettingProvider
    {
        V Value(Name name);

        bool Value(Name name, out V value);


        ReadOnlySpan<V> Values {get;}
    }
}