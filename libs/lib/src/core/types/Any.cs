//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;

    [ApiHost]
    public readonly struct Any
    {
        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public static Any<T> any<T>(T src)
            => new Any<T>(src);

        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public static Any untype<T>(Any<T> src)
            => new Any(src.Value);

        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public static ref Any<T> retype<T>(in Any src)
            => ref @as<Any,Any<T>>(src);

        [MethodImpl(Inline)]
        public static ref Any<T> retype<S,T>(in Any<S> src)
            => ref @as<Any<S>,Any<T>>(src);

        readonly dynamic Data;

        [MethodImpl(Inline)]
        public Any(dynamic src)
            => Data = src;

        public Type DataType
        {
            [MethodImpl(Inline)]
            get => Data?.GetType();
        }

        [MethodImpl(Inline)]
        public T As<T>()
            => @as<dynamic,T>(Data);
    }
}