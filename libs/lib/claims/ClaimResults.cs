//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public readonly struct ClaimResults
    {
        const NumericKind Closure = UnsignedInts;


        [MethodImpl(Inline), Op, Closures(Closure)]
        public static RenderPattern<T,T> neq<T>()
            where T : unmanaged
                => "not({0}=={1})";

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static RenderPattern<T,T> ngt<T>()
            where T : unmanaged
                => "not({0}>{1})";

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static RenderPattern<T> nonempty<T>()
            where T : unmanaged
                => "nonempty({0})";

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static RenderPattern<T,T> nlt<T>()
            where T : unmanaged
                => "not({0}<{1})";

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static RenderPattern<T,T> ngteq<T>()
            where T : unmanaged
                => "not({0}>={1})";

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static RenderPattern<T,T> nlteq<T>()
            where T : unmanaged
                => "not({0}<={1})";

        public static ClaimResult<A> define<A>(string identifier, ClaimKind claim, bool success, TextBlock message, A a)
            => new ClaimResult<A>(identifier, claim, success, message, a);

        public static ClaimResult<A0,A1> define<A0,A1>(string identifier, ClaimKind claim, bool success, TextBlock message, A0 a0, A1 a1)
            => new ClaimResult<A0,A1>(identifier, claim, success, message, a0, a1);

        public static ClaimResult<A0,A1,A2> define<A0,A1,A2>(string identifier, ClaimKind claim, bool success, TextBlock message, A0 a0, A1 a1, A2 a2)
            => new ClaimResult<A0,A1,A2>(identifier, claim, success, message, a0, a1, a2);
    }
}