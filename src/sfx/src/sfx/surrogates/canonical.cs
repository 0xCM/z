//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using S = Surrogates;

    partial class SFx
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BinarySurrogate<T> canonical<T>(SurogateFunc<T,T,T> src)
            => S.binary(src.Subject.ToBinaryOp(), src.Id);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static TernarySurrogate<T> canonical<T>(SurrogateFunc<T,T,T,T> src)
            => S.ternary(Delegates.@operator(src.Subject), src.Id);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SurrogateEmitter<T> canonical<T>(SurrogateFunc<T> src)
            => S.emitter(Delegates.producer(src.Subject), src.Id);
    }
}