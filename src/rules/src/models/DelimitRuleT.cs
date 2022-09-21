//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class DelimitRule<T> : Rule
        where T : IEquatable<T>
    {
        public T Marker {get;}

        [MethodImpl(Inline)]
        public DelimitRule(T marker)
        {
            Marker = marker;
        }

        [MethodImpl(Inline)]
        public bool Test(T src)
            => src.Equals(Marker);

        public override string Format()
            => Marker.ToString();

        [MethodImpl(Inline)]
        public static implicit operator DelimitRule<T>(T src)
            => new DelimitRule<T>(src);
    }

}