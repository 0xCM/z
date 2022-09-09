//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public record struct @float<F,P>
        where F : unmanaged, IEquatable<F>, IComparable<F>
        where P : unmanaged, ITypeNat
    {
        public F Value;

        public @float()
        {
            Value = default;
        }

        [MethodImpl(Inline)]
        public @float(F value)
        {
            Value = value;
        }
        
        [MethodImpl(Inline)]
        public static implicit operator @float<F,P>(F src)
            => new (src);

        [MethodImpl(Inline)]
        public static implicit operator F(@float<F,P> src)
            => src.Value;

        public static byte Precision => nat8u<P>();
    }
}