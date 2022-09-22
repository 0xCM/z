//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Specifies that an element either occurs once or not at all
    /// </summary>
    public class ZeroOrOneRule<T>
        where T : IEquatable<T>
    {
        public Option<T> Element {get;}

        [MethodImpl(Inline)]
        public ZeroOrOneRule(T src)
            => Element = src;

        public bool IsOne
        {
            [MethodImpl(Inline)]
            get => Element.Exists;
        }


        public bool IsNone
        {
            [MethodImpl(Inline)]
            get => !Element.Exists;
        }

        public MultiplicityKind Multiplicity
            => MultiplicityKind.ZeroOrOne;

        [MethodImpl(Inline)]
        public static implicit operator ZeroOrOneRule<T>(T src)
            => new ZeroOrOneRule<T>(src);
    }    
}