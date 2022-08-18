//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    using static System.Runtime.CompilerServices.Unsafe;

    partial struct core
    {
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static HashSet<T> hashset<T>()
            => new HashSet<T>();

        /// <summary>
        /// Transforms a <see cref='char'/> value into a <see cref='T'/> value
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The target value type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static T generic<T>(char src)
            => As<char,T>(ref src);

        /// <summary>
        /// Transforms a <see cref='bool'/> value into a <see cref='T'/> value
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The target value type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static T generic<T>(bool src)
            => As<bool,T>(ref src);

        /// <summary>
        /// Transforms a <see cref='sbyte'/> value into a <see cref='T'/> value
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The target value type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static T generic<T>(sbyte src)
            => As<sbyte,T>(ref src);

        /// <summary>
        /// Transforms a <see cref='byte'/> value into a <see cref='T'/> value
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The target value type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static T generic<T>(byte src)
            => As<byte,T>(ref src);

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref T generic<T>(ref byte src)
            => ref As<byte,T>(ref src);

        /// <summary>
        /// Transforms a <see cref='short'/> value into a <see cref='T'/> value
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The target value type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static T generic<T>(short src)
            => As<short,T>(ref src);

        /// <summary>
        /// Transforms a <see cref='ushort'/> value into a <see cref='T'/> value
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The target value type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static T generic<T>(ushort src)
            => As<ushort,T>(ref src);

        /// <summary>
        /// Transforms a <see cref='int'/> value into a <see cref='T'/> value
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The target value type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static T generic<T>(int src)
            => As<int,T>(ref src);

        /// <summary>
        /// Transforms a <see cref='uint'/> value into a <see cref='T'/> value
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The target value type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static T generic<T>(uint src)
            => As<uint,T>(ref src);

        /// <summary>
        /// Transforms a <see cref='long'/> value into a <see cref='T'/> value
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The target value type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static T generic<T>(long src)
            => As<long,T>(ref src);

        /// <summary>
        /// Transforms a <see cref='ulong'/> value into a <see cref='T'/> value
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The target value type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static T generic<T>(ulong src)
            => As<ulong,T>(ref src);

        /// <summary>
        /// Transforms a <see cref='float'/> value into a <see cref='T'/> value
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The target value type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static T generic<T>(float src)
            => As<float,T>(ref src);

        /// <summary>
        /// Transforms a <see cref='double'/> value into a <see cref='T'/> value
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The target value type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static T generic<T>(double src)
            => As<double,T>(ref src);

        /// <summary>
        /// Transforms a <see cref='decimal'/> value into a <see cref='T'/> value
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The target value type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static T generic<T>(decimal src)
            => As<decimal,T>(ref src);

        [MethodImpl(Inline)]
        public static T generic<T>(string src)
            => As<string,T>(ref src);

        [MethodImpl(Inline)]
        public static T generic<T>(Type src)
            => As<Type,T>(ref src);
    }
}