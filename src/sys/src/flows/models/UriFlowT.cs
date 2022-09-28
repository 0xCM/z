//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct ToolFlow<T,A,B> : IToolFlow<T,A,B>
        where T : ITool, new()
        where A : IUri, new()
        where B : IUri, new()
    {
        public readonly T Tool;

        public readonly A Source;

        public readonly B Target;

        [MethodImpl(Inline)]
        public ToolFlow(A src, B dst)
        {
            Tool = new();
            Source = src;
            Target = dst;
        }

        A IArrow<A, B>.Source 
            => Source;

        B IArrow<A, B>.Target 
            => Target;

        T IToolFlow<T, A, B>.Tool 
            => Tool;
    }
}