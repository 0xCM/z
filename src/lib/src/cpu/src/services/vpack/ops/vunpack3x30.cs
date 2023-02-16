//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static BitMaskLiterals;
    using static vcpu;

    partial struct vpack
    {
        /// <summary>
        /// Partitions the first 30 bits of a 32-bit source into 30 bytes, each with an effective width of 3
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="dst">A target span of sufficient length</param>
        [MethodImpl(Inline), Op]
        public static Vector256<byte> vunpack3x30(uint src)
        {
            var a = src & uint.MaxValue >> 2;
            var lo = (ushort)(Lsb16x16x15 & a);
            var hi = (ushort)(Lsb16x16x15 & (a >> 15));
            var m = vsplit30x8x3Mask(src);
            var shifts = vparts(0, 3, 6, 9, 12, 0, 0, 0);
            var q = vbroadcast(w256, (uint)(lo | hi << 16));
            var r = v16u(vsrlv(vand(q,m), shifts));
            var s = vsplit30x8x3Assemble(r);
            return v8u(s);
        }

        // The goal is to partition the first 30 bits of a 32-bit source into 30 bytes, each with an effective width of 3
        // The pattern repeats every 32 bits
        // Each 32-bit segment can be cut into 2 16-bit parts where both parts
        // exhibit a common pattern of 3-bit segments: [0_111_111_1 11_111_111]
        // 0 | [0_111_111_1 11_111_111 0_111_111_1 11_111_111] -> [0_000_000_0 00_000_111 0_000_000_0 00_000_111] {0,5}
        // 1 | [0_111_111_1 11_111_111 0_111_111_1 11_111_111] -> [0_000_000_0 00_111_000 0_000_000_0 00_111_000] {1,6} -->(3) [000___111 | 000___111]
        // 2 | [0_111_111_1 11_111_111 0_111_111_1 11_111_111] -> [0_000_000_1 11_000_000 0_000_000_1 11_000_000] {2,7} -->(6) [...]
        // 3 | [0_111_111_1 11_111_111 0_111_111_1 11_111_111] -> [0_000_111_0 00_000_000 0_000_111_0 00_000_000] {3,8} -->(9)
        // 4 | [0_111_111_1 11_111_111 0_111_111_1 11_111_111] -> [0_111_000_0 00_000_000 0_111_000_0 00_000_000] {4,9} -->(12)
        const uint m0 = Lsb32x16x3;

        const uint m1 = Lsb32x16x3 << 3;

        const uint m2 = Lsb32x16x3 << 6;

        const uint m3 = Lsb32x16x3 << 9;

        const uint m4 = Lsb32x16x3 << 12;

        [MethodImpl(Inline)]
        static Vector256<uint> vsplit30x8x3Mask(uint src)
            => cpu.vparts(m0, m1, m2, m3, m4, 0, 0, 0);

        // The components are now in the following order, from lo to hi:
        // 0, 5, 1, 6, 2, 7, 3, 8, 4, 9
        // 0, 1, 2, 3, 4, 5, 6, 7, 8, 9
        // Permuting would be cheaper but, in any case...
        [MethodImpl(Inline)]
        static Vector256<ushort> vsplit30x8x3Assemble(Vector256<ushort> y)
            => cpu.vparts(w256,
                vcell(y,0), // 0
                vcell(y,2), // 1
                vcell(y,4), // 2
                vcell(y,6), // 3
                vcell(y,8), // 4
                vcell(y,1), // 5
                vcell(y,3), // 6
                vcell(y,5), // 7
                vcell(y,7), // 8
                vcell(y,9), // 9
                0,0,0,0,0,0);
    }
}