//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public sealed class PointMap<A,B>
    {
        readonly Dictionary<A,B> Lookup;

        Index<A> _Domain;

        Index<B> _Range;

        internal PointMap(A[] src, B[] dst)
        {
            Lookup = new();
            _Domain = src;
            _Range = dst;
            var count = Require.equal(src.Length, dst.Length);
            for(var i=0; i<count; i++)
                Lookup.Add(skip(src,i), skip(dst,i));
        }

        [MethodImpl(Inline)]
        public B Eval(A a)
            => Lookup[a];

        public ReadOnlySpan<A> Domain
        {
            [MethodImpl(Inline)]
            get => _Domain;
        }

        public ReadOnlySpan<B> Range
        {
            [MethodImpl(Inline)]
            get => _Range;
        }
    }
}