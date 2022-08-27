//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IDbRow : IEntity, IKeyed<uint>, ISequential
    {
        uint IKeyed<uint>.Key
            => Seq;
    }

    [Free]
    public interface IDbRow<T> : IDbRow, IEntity<T>, ISequential<T>
        where T : IDbRow<T>, new()
    {

    }
}