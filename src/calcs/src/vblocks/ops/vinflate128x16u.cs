//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;

    using static System.Runtime.Intrinsics.X86.Sse41;
    using static Root;
    using static core;
    using static cpu;

    partial struct vblocks
    {
        /// <summary>
        /// PMOVZXBW xmm, m64
        /// 8x8u -> 8x16u
        /// </summary>
        /// <param name="src">The blocked memory source</param>
        [MethodImpl(Inline), Op(inflate)]
        public static unsafe Vector128<ushort> vinflate128x16u(in SpanBlock64<byte> src, uint offset)
            => v16u(ConvertToVector128Int16(gptr(src[offset])));
    }
}