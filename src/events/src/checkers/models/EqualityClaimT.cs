//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct EqualityClaim<C> : IEqualityClaim<C>
        where C : IEquatable<C>
    {
        public readonly C Actual {get;}

        public readonly C Expect {get;}

        [MethodImpl(Inline)]
        public EqualityClaim(C actual, C expect)
        {
            Actual = actual;
            Expect = expect;
        }

        public bool IsEmpty
        {
            get => false;            
        }
        
        public string Format()
            => string.Format("claim(equal<{0}>(actual:{1}, expect:{2}))", typeof(C).DisplayName(),  Actual, Expect);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator EqualityClaim<C>((C actual, C expect) src)
            => new EqualityClaim<C>(src.actual, src.expect);
    }
}