//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

   public readonly struct NaturalNumericClosure<M,N,T>
        where M : unmanaged, ITypeNat
        where N : unmanaged, ITypeNat
        where T : unmanaged
    {
        public readonly MethodInfo Definition;

        [MethodImpl(Inline)]
        public NaturalNumericClosure(MethodInfo def)
            => Definition = def;

        public NaturalNumericClosure Untyped
            => new NaturalNumericClosure(Definition, nat64u<M>(), nat64u<N>(), typeof(T).NumericKind());
    }
}