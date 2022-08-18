//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Rules
    {

    public class ZeroOrManyRule<T>
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
        public ZeroOrManyRule(T[] src)
            => Elements = src;

        [MethodImpl(Inline)]
        public static implicit operator ZeroOrManyRule<T>(T[] src)
            => new ZeroOrManyRule<T>(src);
    }

    }

}