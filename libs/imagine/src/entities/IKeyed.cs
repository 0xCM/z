//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IKeyed : IExpr
    {
        dynamic Key {get;}

        bool INullity.IsEmpty 
            => Key is null;

        bool INullity.IsNonEmpty
            => Key is not null;

        string IExpr.Format()
            => $"{Key}";
    }

    [Free]
    public interface IKeyed<K> : IKeyed
        where K : IEquatable<K>, IComparable<K>
    {
        new K Key {get;}

        dynamic IKeyed.Key
            => Key;
    }
}