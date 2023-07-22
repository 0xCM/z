//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static vcpu;
    
    partial class vgcpu
    {
        /// <summary>
        /// Returns 1 if the left vector is identical to the right vector and 0 otherwise
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <typeparam name="T">The component type</typeparam>
        [MethodImpl(Inline), Same, Closures(AllNumeric)]
        public static bit vsame<T>(Vector128<T> x, Vector128<T> y)
            where T : unmanaged
                => vtestc(veq(x,y));

        /// <summary>
        /// Returns 1 if the left vector is identical to the right vector and 0 otherwise
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <typeparam name="T">The component type</typeparam>
        [MethodImpl(Inline), Same, Closures(AllNumeric)]
        public static bit vsame<T>(Vector256<T> x, Vector256<T> y)
            where T : unmanaged
                => vtestc(veq(x,y));

        // /// <summary>
        // /// Returns 1 if the left vector is identical to the right vector and 0 otherwise
        // /// </summary>
        // /// <param name="x">The left vector</param>
        // /// <param name="y">The right vector</param>
        // /// <typeparam name="T">The component type</typeparam>
        // [MethodImpl(Inline), Same, Closures(AllNumeric)]
        // public static bit vsame<T>(in Vector512<T> x, in Vector512<T> y)
        //     where T : unmanaged
        //         => vtestc(veq(x,y));
    }
}