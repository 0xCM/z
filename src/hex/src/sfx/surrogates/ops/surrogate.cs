//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class SFx
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SurrogateAction<A0> surrogate<A0>(OpIdentity id, Action<A0> src)
            => new SurrogateAction<A0>(id, src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SurrogateAction<A0,A1> surrogate<A0,A1>(OpIdentity id, Action<A0,A1> src)
            => new SurrogateAction<A0,A1>(id, src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SurrogateAction<A0,A1,A3> surrogate<A0,A1,A3>(OpIdentity id, Action<A0,A1,A3> src)
            => new SurrogateAction<A0,A1,A3>(id, src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SurrogateFunc<T> surrogate<T>(SurrogateEmitter<T> src)
            => new SurrogateFunc<T>(Delegates.func(src.Subject), src.Id);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SurrogateFunc<T,T> surrogate<T>(UnarySurrogate<T> src)
            => new SurrogateFunc<T,T>(Delegates.func(src.Subject), src.Id);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SurogateFunc<T,T,T> surrogate<T>(BinarySurrogate<T> src)
            => new SurogateFunc<T,T,T>(Delegates.func(src.Subject), src.Id);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SurrogateFunc<T,T,T,T> surrogate<T>(TernarySurrogate<T> src)
            => new SurrogateFunc<T,T,T,T>(Delegates.func(src.Subject), src.Id);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SurrogateFunc<T,bit> surrogate<T>(UnaryPredSurrogate<T> src)
            => new SurrogateFunc<T,bit>(Delegates.func(src.Subject), src.Id);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SurogateFunc<T,T,bit> surrogate<T>(BinaryPredSurrogate<T> src)
            => new SurogateFunc<T,T,bit>(Delegates.func(src.Subject), src.Id);
    }
}