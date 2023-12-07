//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class SyntaxRules
    {
        /// <summary>
        /// Just one, neither more nor less
        /// </summary>
        public class ExactlyOne<T>
        {
            public readonly T Element;

            [MethodImpl(Inline)]
            public ExactlyOne(T src)
                => Element = src;

            [MethodImpl(Inline)]
            public static implicit operator ExactlyOne<T>(T src)
                => new ExactlyOne<T>(src);
        }   

    }
}