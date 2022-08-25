//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using A = CharText;
    using C = AsciCharSym;

    using static LimitValues;

    [LiteralProvider]
    public readonly struct NumericIndicators
    {
        [Indicator(C.i)]
        public const string i = A.i;

        [Indicator(C.u)]
        public const string u = A.u;

        [Indicator(C.f)]
        public const string f = A.f;

        [Indicator(t8u, Min8u, Max8u)]
        public const string t8u = "8" + u;

        [Indicator(t8i, Min8i, Max8i)]
        public const string t8i = "8" + i;

        [Indicator(t16u, Min16u, Max16u)]
        public const string t16u = "16" + u;

        [Indicator(t16i, Min16i, Max16i)]
        public const string t16i = "16" + i;

        [Indicator(t32u, Min32u, Max32u)]
        public const string t32u = "32" + u;

        [Indicator(t32i, Min32i, Max32i)]
        public const string t32i = "32" + i;

        [Indicator(t64u, Min64u, Max64u)]
        public const string t64u = "64" + u;

        [Indicator(t64i, Min64i, Max64i)]
        public const string t64i = "64" + i;

        [Indicator(t64i, Min32f, Max32f)]
        public const string t32f = "32" + f;

        [Indicator(t64f, Min64f, Max64f)]
        public const string t64f = "64" + f;

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static string indicator<T>()
            where T : unmanaged
                => indicator_u<T>();

        [MethodImpl(Inline)]
        static string indicator_u<T>()
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return t8u;
            else if(typeof(T) == typeof(ushort))
                return t16u;
            else if(typeof(T) == typeof(uint))
                return t32u;
            else if(typeof(T) == typeof(ulong))
                return t64u;
            else
                return indicator_i<T>();
        }

        [MethodImpl(Inline)]
        static string indicator_i<T>()
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return t8i;
            else if(typeof(T) == typeof(short))
                return t16i;
            else if(typeof(T) == typeof(int))
                return t32i;
            else if(typeof(T) == typeof(long))
                return t64i;
            else
                return indicator_f<T>();
        }

        [MethodImpl(Inline)]
        static string indicator_f<T>()
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return t32f;
            else if(typeof(T) == typeof(double))
                return t64f;
            else
                throw no<T>();
        }
    }
}