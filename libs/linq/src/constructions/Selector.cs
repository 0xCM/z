//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0.DynamicModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct Selector<T,Y>
    {
        [MethodImpl(Inline)]
        public static SelectionBuilder<T,Y> Define()
            => new SelectionBuilder<T,Y>();

        readonly IReadOnlyDictionary<T, Func<Y>> functions;

        [MethodImpl(Inline)]
        public Selector(IEnumerable<KeyValuePair<T, Func<Y>>> choices)
            => functions = choices.ToDictionary(x => x.Key, x => x.Value);

        [MethodImpl(Inline)]
        public Y Select(T t)
            => functions[t]();
    }

    public readonly struct Selector<T,X,R>
    {
        [MethodImpl(Inline)]
        public static SelectionBuilder<T,X,R> Define()
            => new SelectionBuilder<T,X,R>();

        readonly IReadOnlyDictionary<T,Func<X,R>> functions;

        [MethodImpl(Inline)]
        public Selector(IEnumerable<KeyValuePair<T,Func<X,R>>> choices)
            => functions = choices.ToDictionary(x => x.Key, x => x.Value);

        [MethodImpl(Inline)]
        public R Select(T t, X x) => functions[t](x);
    }
}