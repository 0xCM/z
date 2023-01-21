//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class ToolProcess<P,T> : ToolProcess, IToolProcess<T>
        where P : ToolProcess<P,T>, new()
        where T : ITool<T>, new()
    {

        protected ToolProcess()
            : base(Tool)
        {

        }

        public static readonly new T Tool = new();
    }
}