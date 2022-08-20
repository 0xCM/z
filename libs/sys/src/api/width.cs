//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.CompilerServices.Unsafe;

    partial class sys
    {
        /// <summary>
        /// Computes the bit-width of a parametrically-identified type
        /// </summary>
        /// <typeparam name="T">The source type</typeparam>
        public static ulong width<T>()
            => ((ulong)SizeOf<T>())*8ul;
    }
}