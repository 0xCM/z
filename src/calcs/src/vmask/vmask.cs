//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.Vector128;
    using static System.Runtime.Intrinsics.Vector256;

    [ApiHost]
    public readonly partial struct vmask
    {
        /// <summary>
        /// Defines a 128-bit vector by explicit component specification, from least -> most significant
        /// </summary>
        /// <param name="w">The vector width selector</param>
        [MethodImpl(Inline),Op]
        public static Vector128<byte> v128x8(
            byte x0 = default, byte x1 = default, byte x2 = default, byte x3 = default,
            byte x4 = default, byte x5 = default, byte x6 = default, byte x7 = default,
            byte x8 = default, byte x9 = default, byte xa = default, byte xb = default,
            byte xc = default, byte xd = default, byte xe = default, byte xf = default
            ) => Create(x0,x1, x2, x3, x4, x5, x6, x7, x8, x9, xa, xb, xc, xd, xe, xf);

        /// <summary>
        /// Defines a 256-bit vector by explicit component specification, from least -> most significant
        /// </summary>
        /// <param name="w">The vector width selector</param>
        [MethodImpl(Inline),Op]
        public static Vector256<byte> v256x8(
            byte x0, byte x1, byte x2, byte x3, byte x4, byte x5, byte x6, byte x7,
            byte x8, byte x9, byte xa, byte xb, byte xc, byte xd, byte xe, byte xf,
            byte x10, byte x11, byte x12, byte x13, byte x14, byte x15, byte x16, byte x17,
            byte x18, byte x19, byte x1a, byte x1b, byte x1c, byte x1d, byte x1e, byte x1f
            ) => Create(
                x0,x1,x2,x3,x4,x5,x6, x7,x8,x9,xa,xb,xc,xd,xe,xf,
                x10,x11,x12,x13,x14,x15, x16,x17,x18,x19,x1a,x1b,x1c,x1d,x1e,x1f
                );

        const NumericKind Closure = UnsignedInts;

        /// <summary>
        /// Defines a mask that disables a sequence of bits
        /// </summary>
        /// <param name="start">The index at which to begin</param>
        /// <param name="count">The number of bits to disable</param>
        /// <typeparam name="T">The primal type over which the mask is defined</typeparam>
        [MethodImpl(Inline), Op, Closures(Integers)]
        public static T eraser<T>(byte start, byte count)
            where T : unmanaged
                => gmath.xor(Limits.maxval<T>(), gmath.sll(BitMasks.lo<T>((byte)(count - 1)), start));
    }
}