//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using S = Surrogates;
    using R = System;

    partial struct SFx
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static S.Action<A0> surrogate<A0>(OpIdentity id, R.Action<A0> src)
            => new S.Action<A0>(id, src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static S.Action<A0,A1> surrogate<A0,A1>(OpIdentity id, R.Action<A0,A1> src)
            => new S.Action<A0,A1>(id, src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static S.Action<A0,A1,A3> surrogate<A0,A1,A3>(OpIdentity id, R.Action<A0,A1,A3> src)
            => new S.Action<A0,A1,A3>(id, src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static S.Func<T> surrogate<T>(S.Emitter<T> src)
            => new S.Func<T>(Delegates.func(src.Subject), src.Id);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static S.Func<T,T> surrogate<T>(S.UnaryOp<T> src)
            => new S.Func<T,T>(Delegates.func(src.Subject), src.Id);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static S.Func<T,T,T> surrogate<T>(S.BinaryOp<T> src)
            => new S.Func<T,T,T>(Delegates.func(src.Subject), src.Id);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static S.Func<T,T,T,T> surrogate<T>(S.TernaryOp<T> src)
            => new S.Func<T,T,T,T>(Delegates.func(src.Subject), src.Id);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static S.Func<T,bit> surrogate<T>(S.UnaryPredicate<T> src)
            => new S.Func<T,bit>(Delegates.func(src.Subject), src.Id);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static S.Func<T,T,bit> surrogate<T>(S.BinaryPredicate<T> src)
            => new S.Func<T,T,bit>(Delegates.func(src.Subject), src.Id);
    }
}