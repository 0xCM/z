//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class vgcpu
    {
        /// <summary>
        /// Defines the ternary bitwise select operator over three vectors,
        /// select(x, y, z) := or(and(x, y), and(not(x), z)) = or(and(x,y), notimply(x,z));
        /// </summary>
        /// <param name="x">The first vector</param>
        /// <param name="y">The second vector</param>
        /// <param name="z">The third vector</param>
        /// <typeparam name="T">The primal component type</typeparam>
        [MethodImpl(Inline), Select, Closures(Integers)]
        public static Vector128<T> vselect<T>(Vector128<T> x, Vector128<T> y, Vector128<T> z)
            where T : unmanaged
                => vor(vand(x,y), vnonimpl(x,z));

        /// <summary>
        /// Defines the ternary bitwise select operator over three vectors,
        /// select(x, y, z) := or(and(x, y), and(not(x), z)) = or(and(x,y), notimply(x,z));
        /// </summary>
        /// <param name="x">The first vector</param>
        /// <param name="y">The second vector</param>
        /// <param name="z">The third vector</param>
        /// <typeparam name="T">The primal component type</typeparam>
        [MethodImpl(Inline), Select, Closures(Integers)]
        public static Vector256<T> vselect<T>(Vector256<T> x, Vector256<T> y, Vector256<T> z)
            where T : unmanaged
                => vor(vand(x,y), vnonimpl(x,z));

        // /// <summary>
        // /// Defines the ternary bitwise select operator over three vectors,
        // /// select(x, y, z) := or(and(x, y), and(not(x), z)) = or(and(x,y), notimply(x,z));
        // /// </summary>
        // /// <param name="x">The first vector</param>
        // /// <param name="y">The second vector</param>
        // /// <param name="z">The third vector</param>
        // /// <typeparam name="T">The primal component type</typeparam>
        // [MethodImpl(Inline), Select, Closures(AllNumeric)]
        // public static Vector512<T> vselect<T>(in Vector512<T> x, in Vector512<T> y, in Vector512<T> z)
        //     where T : unmanaged
        //         => (vselect(x.Lo, y.Lo, z.Lo), (vselect(x.Hi, y.Hi, z.Hi)));

    }
}