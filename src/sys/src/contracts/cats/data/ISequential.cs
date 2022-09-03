//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface ISequential
    {
        uint Seq {get; set;}
    }

    [Free]
    public interface ISequential<T> : ISequential
        where T : ISequential<T>
    {

    }
}