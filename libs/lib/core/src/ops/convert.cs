//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct core
    {
        /// <summary>
        /// If possible, applies the conversion sbyte -> T
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The target type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static T convert<T>(sbyte src)
            => Numeric.force<T>(src);

        /// <summary>
        /// If possible, applies the conversion byte -> T
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The target type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static T convert<T>(byte src)
            => Numeric.force<T>(src);

        /// <summary>
        /// If possible, applies the conversion ushort -> T
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The target type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static T convert<T>(ushort src)
            => Numeric.force<T>(src);

        /// <summary>
        /// If possible, applies the conversion short -> T
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The target type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static T convert<T>(short src)
            => Numeric.force<T>(src);

        /// <summary>
        /// If possible, applies the conversion int -> T
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The target type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static T convert<T>(int src)
            => Numeric.force<T>(src);

        /// <summary>
        /// If possible, applies the conversion uint -> T
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The target type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static T convert<T>(uint src)
            => Numeric.force<T>(src);

        /// <summary>
        /// If possible, applies the conversion long -> T
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The target type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static T convert<T>(long src)
            => Numeric.force<T>(src);

        /// <summary>
        /// If possible, applies the conversion ulong -> T
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The target type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static T convert<T>(ulong src)
            => Numeric.force<T>(src);

        /// <summary>
        /// If possible, applies the conversion float -> T
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The target type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static T convert<T>(float src)
            => Numeric.force<T>(src);

        /// <summary>
        /// If possible, applies the conversion double -> T
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The target type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static T convert<T>(double src)
            => Numeric.force<T>(src);

        /// <summary>
        /// If possible, applies the conversion char -> T
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The target type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static T convert<T>(char src)
            => Numeric.force<T>(src);

        /// <summary>
        /// If possible, applies the conversion S -> T
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="S">The source type</typeparam>
        /// <typeparam name="T">The target type</typeparam>
        [MethodImpl(Inline)]
        public static T convert<S,T>(S src)
            => Numeric.force<S,T>(src);
    }
}