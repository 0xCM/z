//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class SyntaxRules
    {
        public class ZeroOrMany<T>
            where T : IEquatable<T>
        {
            public Index<T> Elements {get;}

            public bool IsZero
            {
                [MethodImpl(Inline)]
                get => Elements.Count == 0;
            }

            public bool IsMore
            {
                [MethodImpl(Inline)]
                get => Elements.Count > 0;
            }

            public MultiplicityKind Kind
                => MultiplicityKind.ZeroOrMany;

            [MethodImpl(Inline)]
            public ZeroOrMany(T[] src)
                => Elements = src;

            [MethodImpl(Inline)]
            public static implicit operator ZeroOrMany<T>(T[] src)
                => new ZeroOrMany<T>(src);
        }
    }
}