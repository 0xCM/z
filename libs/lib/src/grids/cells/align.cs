//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct CellCalcs
    {
        [MethodImpl(Inline), Op, Closures(Integers8x64k)]
        public static bool align<T>(W16 w, uint count, out uint rem)
            where T : unmanaged
        {
            rem = count % (uint)blocklength<T>(w);
            return rem == 0;
        }

        [MethodImpl(Inline), Op, Closures(Integers8x64k)]
        public static bool align<T>(W32 w, uint count, out uint rem)
            where T : unmanaged
        {
            rem = count % (uint)blocklength<T>(w);
            return rem == 0;
        }

        [MethodImpl(Inline), Op, Closures(Integers8x64k)]
        public static bool align<T>(W64 w, uint count, out uint rem)
            where T : unmanaged
        {
            rem = count % (uint)blocklength<T>(w);
            return rem == 0;
        }

        [MethodImpl(Inline), Op, Closures(Integers8x64k)]
        public static bool align<T>(W128 w, uint count, out uint rem)
            where T : unmanaged
        {
            rem = count % (uint)blocklength<T>(w);
            return rem == 0;
        }

        [MethodImpl(Inline), Op, Closures(Integers8x64k)]
        public static bool align<T>(W256 w, uint count, out uint rem)
            where T : unmanaged
        {
            rem = count % (uint)blocklength<T>(w);
            return rem == 0;
        }
    }
}