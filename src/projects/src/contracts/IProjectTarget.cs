//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IProjectTarget
    {

    }

    public interface IProjectTarget<T> : IProjectTarget
        where T : IProjectTarget<T>, new()
    {

    }

}