//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct MultiDiviner : IMultiDiviner
    {
        public static IMultiDiviner Service => default(MultiDiviner);

        [MethodImpl(Inline)]
        public TypeIdentity DivineIdentity(Type src)
            => ApiIdentity.identify(src);

        [MethodImpl(Inline)]
        public _OpIdentity DivineIdentity(MethodInfo src)
            => ApiIdentity.identify(src);

        public _OpIdentity DivineIdentity(Delegate src)
            => ApiIdentity.identify(src);

        [MethodImpl(Inline)]
        public OpIdentityG GenericIdentity(MethodInfo src)
            => ApiIdentity.generic(src);
    }
}