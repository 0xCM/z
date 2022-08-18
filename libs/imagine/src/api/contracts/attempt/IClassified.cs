//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IClassified<K> : ITextual
    {
        string Name => typeof(K).Name;

        string ITextual.Format()
            => Name;
    }

    public interface IClassified<K,T> : IClassified<K>
    {

    }
}