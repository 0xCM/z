//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Widths
    {
        /// <summary>
        /// Determines wheter a parametrically-identified type if of bit-width <see cref='W8'/>
        /// </summary>
        /// <param name="w">The width selector</param>
        /// <typeparam name="T">The type to test</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static bool test<T>(W8 w)
            => size<T>() == 1;

        /// <summary>
        /// Determines wheter a parametrically-identified type if of bit-width <see cref='W16'/>
        /// </summary>
        /// <param name="w">The width selector</param>
        /// <typeparam name="T">The type to test</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static bool test<T>(W16 w)
            => size<T>() == 2;

        /// <summary>
        /// Determines wheter a parametrically-identified type if of bit-width <see cref='W32'/>
        /// </summary>
        /// <param name="w">The width selector</param>
        /// <typeparam name="T">The type to test</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static bool test<T>(W32 w)
            => size<T>() == 4;

        /// <summary>
        /// Determines wheter a parametrically-identified type if of bit-width <see cref='W64'/>
        /// </summary>
        /// <param name="w">The width selector</param>
        /// <typeparam name="T">The type to test</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static bool test<T>(W64 w)
            => size<T>() == 8;

        /// <summary>
        /// Determines wheter a parametrically-identified type if of bit-width <see cref='W128'/>
        /// </summary>
        /// <param name="w">The width selector</param>
        /// <typeparam name="T">The type to test</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static bool test<T>(W128 w)
            => size<T>() == 16;

        /// <summary>
        /// Determines wheter a parametrically-identified type if of bit-width <see cref='W256'/>
        /// </summary>
        /// <param name="w">The width selector</param>
        /// <typeparam name="T">The type to test</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static bool test<T>(W256 w)
            => size<T>() == 32;
    }
}