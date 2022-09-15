//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public abstract class Tool<T> : Actor<T>, ITool
        where T : Tool<T>, new()
    {
        protected Tool(@string name)
            : base(name)
        {
            ToolId = name;
        }

        public Actor ToolId {get;}

        public static implicit operator Actor(Tool<T> src)
            => src.ToolId;
    }
}