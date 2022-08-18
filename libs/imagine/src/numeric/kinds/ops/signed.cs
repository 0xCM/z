//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using NK = NumericKind;

    partial class NumericKinds
    {
        /// <summary>
        /// Determines whether a numeric kind designates a signed integral type
        /// </summary>
        /// <param name="src">The source kind</typeparam>
        [MethodImpl(Inline), Op]
        public static bool signed(NumericKind src)
            => (src & NK.Signed) != 0;

        /// <summary>
        /// Returns true if a parametric type is of signed numeric type, false otherwise
        /// </summary>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static bool signed<T>()
            where T : unmanaged
                => typeof(T) == typeof(sbyte)
                || typeof(T) == typeof(short)
                || typeof(T) == typeof(int)
                || typeof(T) == typeof(long);

        /// <summary>
        /// Returns true if the source type is a primal signed type, false otherwise
        /// </summary>
        /// <param name="src">The source type</param>
        [MethodImpl(Inline), Op]
        public static bool signed(Type src)
            => src == typeof(sbyte)
            || src == typeof(short)
            || src == typeof(int)
            || src == typeof(long);

        /// <summary>
        /// Returns true if a value is of signed numeric type, false otherwise
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static bool signed(object src)
            => src is sbyte || src is short || src is int || src is long;
    }
}