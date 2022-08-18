//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class Flow<A,B> : IFlow<A,B>
    {
        public readonly A Source;

        public readonly B Target;

        [MethodImpl(Inline)]
        public Flow(A src, B dst)
        {
            Source = src;
            Target = dst;
        }

        A IArrow<A,B>.Source 
            => Source;

        B IArrow<A,B>.Target 
            => Target;

        [MethodImpl(Inline)]
        public static implicit operator Flow<A,B>((A a, B b) src)
            => new Flow<A,B>(src.a, src.b);
    }
}