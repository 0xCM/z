//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class Executor<E> : Executor
        where E : Executor<E>, new()
    {
        public static E create(IWfRuntime wf)
        {
            var e = new E();
            e.Wf = wf;
            e.Channel = wf.Channel;
            return e;
        }
    }
}