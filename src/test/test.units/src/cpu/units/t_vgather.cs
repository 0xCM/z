//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.Intrinsics;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;
    using static cpu;

    public class t_vgather : t_inx<t_vgather>
    {
        const int BufferSize = 1024*8;

        VClaims VClaims => default;

        public override bool Enabled
            => true;

        [MethodImpl(Inline)]
        static Interval<T> bounds<T>(uint n)
            where T : unmanaged
                => (zero<T>(), Numeric.force<T>(n));

        public void vgather_check()
        {
            vgather_check(w128);
            vgather_check(w256);
        }

        void vgather_check(W128 w)
        {
            vgather_check(w, z8);
            vgather_check(w, z8i);
            vgather_check(w, z16);
            vgather_check(w, z16i);
            vgather_check(w, z32);
            vgather_check(w, z32i);
            vgather_check(w, z64);
            vgather_check(w, z64i);
        }

        void vgather_check(W256 w)
        {
            vgather_check(w, z8);
            vgather_check(w, z8i);
            vgather_check(w, z16);
            vgather_check(w, z16i);
            vgather_check(w, z32);
            vgather_check(w, z32i);
            vgather_check(w, z64);
            vgather_check(w, z64i);
        }

        void vgather_check<T>(W128 w)
            where T : unmanaged
        {
            var cells = BufferSize/size<T>();
            var domain = bounds<T>(cells);

            var data = gcalc.increments(span<T>(cells));
            ref readonly var src = ref first(data);

            for(var i = 0; i<RepCount; i++)
            {
                var vidx = Random.CpuVector(w,domain);
                var x = gcpu.vgather(src, vidx);
                Claim.veq(vidx,x);
            }
        }

        void vgather_check<T>(W256 w)
            where T : unmanaged
        {
            var count = BufferSize/size<T>();
            var domain = bounds<T>(count);

            var data = gcalc.increments(span<T>(count));
            ref readonly var src = ref first(data);

            for(var i = 0; i<RepCount; i++)
            {
                var vidx = Random.CpuVector(w,domain);
                var x = gcpu.vgather(src, vidx);
                Claim.veq(vidx,x);
            }
        }

        void vgather_check<T>(W128 w, T t)
            where T : unmanaged
                => CheckAction(() => vgather_check<T>(w), CaseName("vgather", w, t));

        void vgather_check<T>(W256 w, T t)
            where T : unmanaged
                => CheckAction(() => vgather_check<T>(w), CaseName("vgather", w, t));

        public void vgather_128()
        {
            const int count = Pow2.T09;

            Span<uint> data32 = new uint[count];
            for(var i=0; i<data32.Length; i++)
                data32[i] = (uint)i;

            Span<ulong> data64 = new ulong[count];
            for(var i=0; i<data64.Length; i++)
                data64[i] = (ulong)i;

            ref var src32 = ref first(data32);
            ref var src64 = ref first(data64);

            var v256Actual = vgather(w128, in src32, VGather4x64uIndex);
            var v256Expect = vparts(w128,0, 63, 127, 255);
            VClaims.veq(v256Expect,v256Actual);

            //[0,127,255,511]
            var v512idx = v64u(Vector256.Create(Pow2.T00 - 1, Pow2.T07 - 1, Pow2.T08 - 1, Pow2.T09 - 1));
            var v512Actual = vgather(w128, in src32, v512idx);
            var v512Expect = vparts(w128,0, 127, 255, 511);
            VClaims.veq(v512Expect,v512Actual);

            // Each claim below asserts that each gather operation is an identity function
            // with respect to the defined indexes (ignoring the type of the underlying data)

            var i2x8 = vparts(w128, 8, 16);
            var v2x8 = vgather(w128, in src64, i2x8);
            VClaims.veq(i2x8, v2x8);

            var i2x64 = vparts(w128, 64, 128);
            var v2x64 = vgather(w128, in src64, i2x64);
            VClaims.veq(i2x64, v2x64);

            var i2x250 = vparts(w128, 250, 500);
            var v2x250 = vgather(w128, in src64, i2x250);
            VClaims.veq(i2x250, v2x250);

            var i2x2 = vparts(w256, 2, 4, 8, 16);
            var v2x2 = vgather(w128, in src32, i2x2);
            VClaims.veq(vpack.vpack128x32u(i2x2), v2x2);

            var i3x3 = vparts(w256, 3, 6, 12, 24);
            var v3x3 = vgather(w128, in src32, i3x3);
            VClaims.veq(vpack.vpack128x32u(i3x3), v3x3);

            var i3_3 = vparts(w256, 3, 6, 9, 12);
            var v3_3 = vgather(w128, in src32, i3_3);
            VClaims.veq(vpack.vpack128x32u(i3_3), v3_3);

            var i4x2 = vparts(w256, 4, 8, 16, 32);
            var v4x2 = vgather(w128, in src32, i4x2);
            VClaims.veq(vpack.vpack128x32u(i4x2), v4x2);

            var i5_5 =vparts(w256, 5, 10, 15, 20);
            var v5_5 = vgather(w128, in src32, i5_5);
            VClaims.veq(vpack.vpack128x32u(i5_5), v5_5);

            var i9_9 = vparts(w256, 9, 18, 27, 36);
            var v9_9 = vgather(w128, in src32, i9_9);
            VClaims.veq(vpack.vpack128x32u(i9_9), v9_9);

            var i10_10 = vparts(w256, 10, 20, 30, 40);
            var v10_10 = vgather(w128, in src32, i10_10);
            VClaims.veq(vpack.vpack128x32u(i10_10), v10_10);

            var i16x2 = vparts(w256, 16, 32, 64, 128);
            var v16x2 = vgather(w128, in src32, i16x2);
            VClaims.veq(vpack.vpack128x32u(i16x2), v16x2);

            var i20_5 = vparts(w256, 20, 25, 30, 35);
            var v20_5 = vgather(w128, in src32, i20_5);
            VClaims.veq(vpack.vpack128x32u(i20_5), v20_5);

            var i40_3 = vparts(w256, 40, 43, 46, 49);
            var v40_3 = vgather(w128, in src32, i40_3);
            VClaims.veq(vpack.vpack128x32u(i40_3), v40_3);

            var i4x128 = vparts(w256i, 0, 128 - 1, 128*2 - 1, 128*4 - 1);
            var v4x128 = vgather(w128, in src32, v512idx);
            VClaims.veq(vpack.vpack128x32i(i4x128), v32i(v4x128));
        }

        public void vgather_256()
        {
            Span<uint> data = new uint[Pow2.T09];
            for(var i=0; i<data.Length; i++)
                data[i] = (uint)i;
            ref var src = ref first(data);

            //[0,3,7,15,31,63,127,255]
            var v256idx = vparts(w256,Pow2.T00 - 1, Pow2.T02 - 1, Pow2.T03 - 1, Pow2.T04 - 1, Pow2.T05 - 1, Pow2.T06 - 1, Pow2.T07 - 1, Pow2.T08 - 1);
            var v256Expect = vparts(w256, 0, Pow2.T02 - 1, Pow2.T03 - 1, Pow2.T04 - 1, Pow2.T05 - 1, Pow2.T06 - 1, Pow2.T07 - 1, Pow2.T08 - 1);
            var v256Actual = vgather(w256, in src, v256idx);
            VClaims.veq(v256Expect,v256Actual);

            var v512Expect = vparts(w256, 0, Pow2.T03 - 1, Pow2.T04 - 1, Pow2.T05 - 1, Pow2.T06 - 1, Pow2.T07 - 1, Pow2.T08 - 1, Pow2.T09 - 1);
            var v512Actual = vgather(w256, in src, VGather256x32x512Index);
            VClaims.veq(v512Expect, v512Actual);
        }

        public void vgather_blocks()
        {
            const int BlockLength = 4;
            const int CellCount = 512;
            const int BlockCount = CellCount / BlockLength;

            var w = w128;
            var t = z32;
            var A = SpanBlocks.alloc<uint>(w,BlockCount);
            var B = SpanBlocks.alloc<uint>(w,BlockCount);

            var pattern0 = vmask.vlsb<uint>(w, n2, n1);
            var pattern1 = vmask.vmsb<uint>(w, n2, n1);

            for(var block = 0; block<BlockCount; block++)
            {
                var target = A.CellBlock(block);
                var source = gmath.even(block) ? pattern0 : pattern1;
                source.StoreTo(target);
            }

            var a0 = vgather(w, in A.First, vparts(w,4*12, 4*24, 4*48, 4*64));
            VClaims.veq(a0, pattern0);

            for(var block = 0; block < BlockCount; block++)
            {
                uint i0 = (uint)(block*BlockLength);
                var i1 = i0 + 1;
                var i2 = i1 + 1;
                var i3 = i2 + 1;

                var indices = vparts(w,i0,i1,i2,i3);
                var result = vgather(w, in A.First, indices);
                var expect = gmath.even(block) ? pattern0 : pattern1;
                VClaims.veq(result,expect);
            }
        }

        //[0, 63, 127, 255]
        static Vector256<ulong> VGather4x64uIndex
        {
            [MethodImpl(Inline)]
            get => vload(w256, in first64u(VGather256x64x256IndexData));
        }

        //[0, 63, 127, 255]
        static Vector256<long> VGather4x64iIndex
        {
            [MethodImpl(Inline)]
            get => vload(w256, in first64i(VGather256x64x256IndexData));
        }

        //[0, 7, 15, 31, 63, 127, 255, 511]
        static Vector256<uint> VGather256x32x512Index
        {
            [MethodImpl(Inline)]
            get => gcpu.vload<uint>(w256, in first32u(VGather256x32x512IndexData));
        }

        //[0, 63, 127, 255]
        static ReadOnlySpan<byte> VGather256x64x256IndexData => new byte[]{
            0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
            0x3f,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
            0x7f,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
            0xff,0x00,0x00,0x00,0x00,0x00,0x00,0x00
        };

        //[0, 7, 15, 31, 63, 127, 255, 511]
        static ReadOnlySpan<byte> VGather256x32x512IndexData => new byte[]{
            0x00,0x00,0x00,0x00,
            0x07,0x00,0x00,0x00,
            0x0f,0x00,0x00,0x00,
            0x1f,0x00,0x00,0x00,
            0x3f,0x00,0x00,0x00,
            0x7f,0x00,0x00,0x00,
            0xff,0x00,0x00,0x00,
            0xff,0x01,0x00,0x00
        };

        //[0, 4, 8, 12, 16, 20, 24, 28]
        static ReadOnlySpan<byte> VGather256x32x4IndexData => new byte[]{
            0,0x00,0x00,0x00,
            4,0x00,0x00,0x00,
            8,0x00,0x00,0x00,
            12,0x00,0x00,0x00,
            16,0x00,0x00,0x00,
            20,0x00,0x00,0x00,
            24,0x00,0x00,0x00,
            28,0x01,0x00,0x00
        };

    }
}