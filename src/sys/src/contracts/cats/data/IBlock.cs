//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IBlock
    {
        dynamic Content {get;}
    }

    [Free]
    public interface IBlock<B> : IBlock
    {
        new B Content {get;}

        dynamic IBlock.Content
            => Content;
    }
}