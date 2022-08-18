//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ILeaf
    {
        dynamic Content {get;}
    }

    public interface ILeaf<T> : ILeaf
    {
        new T Content {get;}

        dynamic ILeaf.Content
            => Content;
    }
}