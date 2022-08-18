//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial struct SFx
    {
        [MethodImpl(Inline), Op]
        public static ValueProjector projector(BoxedValueMap f)
            => new ValueProjector(f);

        [MethodImpl(Inline), Op]
        public static ValueProjector projector(Func<object,object> f)
            => new ValueProjector(x => (ValueType)f((ValueType)x));

        [MethodImpl(Inline), Op]
        public static ValueProjector projector(Func<ValueType,ValueType> f)
            => new ValueProjector(x => (ValueType)f((ValueType)x));

        [MethodImpl(Inline)]
        public static ValueProjector<T> projector<T>(Func<object,T> f)
            where T : struct
                => projector(f, alloc<T>(1));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ValueProjector<T> projector<T>(Func<ValueType,T> f)
            where T : struct
                => new ValueProjector<T>(convert(f));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ValueProjector<T> projector<T>(BoxedValueMap<T> f)
            where T : struct
                => new ValueProjector<T>(f);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ValueProjector<T,T> projector<T>(ValueMap<T,T> f)
            where T : struct
                => projector<T,T>(f);

        [MethodImpl(Inline)]
        public static ValueProjector<S,T> projector<S,T>(ValueMap<S,T> f)
            where S : struct
            where T : struct
                => new ValueProjector<S,T>(f);

        [MethodImpl(Inline)]
        public static ValueProjector<S,T> projector<S,T>(Func<S,T> f)
            where S : struct
            where T : struct
                => projector(f, sys.alloc<T>(1));

        [MethodImpl(Inline), Op, Closures(Closure)]
        static ValueProjector<T> projector<T>(Func<object,T> f, T[] dst)
            where T : struct
                => new ValueProjector<T>(boxed(f, dst));

        [MethodImpl(Inline)]
        static ValueProjector<S,T> projector<S,T>(Func<S,T> f, T[] dst)
            where S : struct
            where T : struct
                => new ValueProjector<S,T>(convert(f,dst));
    }
}