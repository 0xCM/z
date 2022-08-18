//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;

    using static Root;
    using static CpuBytes;

    partial struct gcpu
    {
        /// <summary>
        /// Creates a shuffle mask that clears every-other vector component
        /// </summary>
        /// <typeparam name="T">The primal component type</typeparam>
        [MethodImpl(Inline), Op, NumericClosures(NumericKind.U8 | NumericKind.U16)]
        public static Vector256<T> vclearalt<T>(N256 n)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return gcpu.vload<T>(n,ClearAlt256x8u);
            else if(typeof(T) == typeof(ushort))
                return gcpu.vload<T>(n,ClearAlt256x16u);
            else
                return default;
        }
    }
}