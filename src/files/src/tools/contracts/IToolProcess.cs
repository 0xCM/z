//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IToolProcess
    {
        ITool Tool {get;}
    }

    public interface IToolProcess<T> : IToolProcess
        where T : ITool<T>, new()
    {
        new T Tool => new();

        ITool IToolProcess.Tool
            => Tool;
    }
}