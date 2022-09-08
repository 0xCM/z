//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct NaturalNumericClosure<N,T>
        where N : unmanaged, ITypeNat
        where T : unmanaged
    {
        public MethodInfo Definition {get;}

        [MethodImpl(Inline)]
        public NaturalNumericClosure(MethodInfo def)
            => Definition = def;

        public NaturalNumericClosure Untyped
            => new NaturalNumericClosure(Definition, null, sys.nat64u<N>(), typeof(T).NumericKind());
    }
}