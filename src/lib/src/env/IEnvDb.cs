//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IEnvDb
    {

    }

    public interface IEnvDb<E> : IEnvDb
        where E : IEnvDb<E>, new()

    {

    }
}