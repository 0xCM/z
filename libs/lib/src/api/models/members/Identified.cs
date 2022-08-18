//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct Identified
    {
        [MethodImpl(Inline)]
        public static int compare<T>(in T a, in T b)
            where T : IIdentified
                => (a.IdentityText ?? EmptyString).CompareTo(b.IdentityText);

        [MethodImpl(Inline)]
        public static bool equals<T>(in T a, object b)
            where T : IIdentified
                => string.Equals(a.IdentityText, b is T x ? x.IdentityText : EmptyString, NoCase);

        [MethodImpl(Inline)]
        public static bool equals<T>(in T a, in T b)
            where T : IIdentified
                => string.Equals(a.IdentityText, b.IdentityText, NoCase);

        [MethodImpl(Inline)]
        public static int hash<T>(in T src)
            where T : IIdentified
                => (src.IdentityText ?? EmptyString).GetHashCode();
    }
}