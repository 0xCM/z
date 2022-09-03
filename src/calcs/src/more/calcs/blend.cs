//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static CalcHosts;

    partial struct Calcs
    {
        [MethodImpl(Inline), Factory, Closures(Closure)]
        public static VBlend4x32x128<T> vblend4x32<T>(W128 w)
            where T : unmanaged
                => default(VBlend4x32x128<T>);

        [MethodImpl(Inline), Factory, Closures(Closure)]
        public static VBlend8x32x256<T> vblend8x32<T>(W256 w)
            where T : unmanaged
                => default(VBlend8x32x256<T>);

        [MethodImpl(Inline), Factory, Closures(Closure)]
        public static VBlend2x64x128<T> vblend2x64<T>(W128 w)
            where T : unmanaged
                => default(VBlend2x64x128<T>);

        [MethodImpl(Inline), Factory, Closures(Closure)]
        public static VBlend4x64x256<T> vblend4x64<T>(W256 w)
            where T : unmanaged
                => default(VBlend4x64x256<T>);

        [MethodImpl(Inline), Factory, Closures(Closure)]
        public static VBlend8x16x128<T> vblend8x16<T>(W128 w)
            where T : unmanaged
                => default(VBlend8x16x128<T>);

        [MethodImpl(Inline), Factory, Closures(Closure)]
        public static VBlend8x16x256<T> vblend8x16<T>(W256 w)
            where T : unmanaged
                => default(VBlend8x16x256<T>);
    }
}