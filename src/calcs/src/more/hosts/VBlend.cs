//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static SFx;

    partial struct CalcHosts
    {
        [Closures(Integers)]
        public readonly struct VBlend2x64x128<T> : IBinaryImm8Op128<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Vector128<T> Invoke(Vector128<T> x, Vector128<T> y, [Imm] byte spec)
                => gcpu.vblend2x64(x,y,spec);
        }

        [Closures(Integers)]
        public readonly struct VBlend4x64x256<T> : IBinaryImm8Op256<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Vector256<T> Invoke(Vector256<T> x, Vector256<T> y, [Imm] byte spec)
                => gcpu.vblend4x64(x,y,spec);
        }

        [Closures(Integers)]
        public readonly struct VBlend4x32x128<T> : IBinaryImm8Op128<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Vector128<T> Invoke(Vector128<T> x, Vector128<T> y, [Imm] byte spec)
                => gcpu.vblend4x32(x,y,spec);
        }

        [Closures(Integers)]
        public readonly struct VBlend8x32x256<T> : IBinaryImm8Op256<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Vector256<T> Invoke(Vector256<T> x, Vector256<T> y, [Imm] byte spec)
                => gcpu.vblend8x32(x,y,spec);
        }

        [Closures(Integers)]
        public readonly struct VBlend8x16x128<T> : IBinaryImm8Op128<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Vector128<T> Invoke(Vector128<T> x, Vector128<T> y, [Imm] byte spec)
                => gcpu.vblend8x16(x,y,spec);
        }

        [Closures(Integers)]
        public readonly struct VBlend8x16x256<T> : IBinaryImm8Op256<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Vector256<T> Invoke(Vector256<T> x, Vector256<T> y, [Imm] byte spec)
                => gcpu.vblend8x16(x,y,spec);
        }
    }
}