//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class vcpu
    {
        /// <summary>
        /// Creates a 128-bit vector with all bits enabled
        /// </summary>
        /// <param name="w">The vector width selector</param>
        /// <typeparam name="T">The primal component type</typeparam>
        [MethodImpl(Inline), Ones, Closures(AllNumeric)]
        public static Vector128<T> vones<T>(W128 w)
            where T : unmanaged
                => vgcpu.veq(default(Vector128<T>), default(Vector128<T>));

        /// <summary>
        /// Creates a 256-bit vector with all bits enabled
        /// </summary>
        /// <param name="w">The vector width selector</param>
        /// <typeparam name="T">The primal component type</typeparam>
        [MethodImpl(Inline), Ones, Closures(AllNumeric)]
        public static Vector256<T> vones<T>(W256 w)
            where T : unmanaged
                => vgcpu.veq(default(Vector256<T>), default(Vector256<T>));

        // /// <summary>
        // /// Creates a 512-bit vector with all bits enabled
        // /// </summary>
        // /// <param name="w">The vector width selector</param>
        // /// <typeparam name="T">The primal component type</typeparam>
        // [MethodImpl(Inline), Ones, Closures(AllNumeric)]
        // public static Vector512<T> vones<T>(W512 w)
        //     where T : unmanaged
        //         => vgcpu.veq(default(Vector512<T>), default(Vector512<T>));
    }
}