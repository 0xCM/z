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

    partial struct SFx
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static S.BinaryOp<T> canonical<T>(S.Func<T,T,T> src)
            => S.binary(src.Subject.ToBinaryOp(), src.Id);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static S.TernaryOp<T> canonical<T>(S.Func<T,T,T,T> src)
            => S.ternary(Delegates.@operator(src.Subject), src.Id);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static S.Emitter<T> canonical<T>(S.Func<T> src)
            => S.emitter(Delegates.producer(src.Subject), src.Id);
    }
}