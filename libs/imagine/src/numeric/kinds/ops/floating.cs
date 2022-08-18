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
        /// Determines whether a numeric kind designates a floating-point type
        /// </summary>
        /// <param name="T">The type to test</param>
        [MethodImpl(Inline), Op]
        public static bool float32(NumericKind src)
            => (src & NK.Float) != 0;

        [MethodImpl(Inline), Op]
        public static bool float64(NumericKind src)
            => (src & NK.F64) != 0;

        /// <summary>
        /// Returns true if a parametric type is of floating-point numeric type, false otherwise
        /// </summary>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static bool fractional<T>()
            where T : unmanaged
                => typeof(T) == typeof(float)
                || typeof(T) == typeof(double);

        /// <summary>
        /// Returns true if the source type is a primal floating point type, false otherwise
        /// </summary>
        [MethodImpl(Inline), Op]
        public static bool fractional(Type t)
            => t == typeof(float) || t == typeof(double);

        /// <summary>
        /// Returns true if a value is of floating-point numeric type, false otherwise
        /// </summary>
        [MethodImpl(Inline), Op]
        public static bool fractional(object value)
            => value is float || value is double;
    }
}