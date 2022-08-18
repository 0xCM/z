//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Widths
    {
        /// <summary>
        /// Computes the number of bits occupied by an instance of a parametrically-identified type
        /// </summary>
        /// <typeparam name="T">The measurable type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static uint bits<T>()
            where T : struct
                => bytes<T>()*8;
    }
}