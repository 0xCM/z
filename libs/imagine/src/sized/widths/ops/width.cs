//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Widths
    {
        /// <summary>
        /// Computes the bit-width of a parametrically-identified type, returning the result as a <see cref='BitWidth'/> value
        /// </summary>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        internal static ulong width<T>()
            => (ulong)Unsafe.SizeOf<T>()*8;
    }
}