//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Just one, neither more nor less
    /// </summary>
    public class SingleRule<T>
    {
        public readonly T Element;

        [MethodImpl(Inline)]
        public SingleRule(T src)
            => Element = src;

        [MethodImpl(Inline)]
        public static implicit operator SingleRule<T>(T src)
            => new SingleRule<T>(src);
    }
    
}