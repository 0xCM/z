//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Linq;
    using System.Runtime.Intrinsics;

    using static HexConst;
    using static LimitValues;
    using static Root;
    using static cpu;

    using M = BitMaskLiterals;

    public class t_vblend : t_inx<t_vblend>
    {
        public void vblend_256x32f_outline()
        {
            var w = n256;
            var a = cpu.vparts(w,0f, 1f, 2f, 3f, 4f, 5f, 6f, 7f);
            var b = cpu.vparts(w,8f, 9f, 10f, 11f, 12f, 13f, 14f, 15f);
            var spec = cpu.vparts(w,0f,-1,0f,-1,0f,-1,0f,-1);
            var c = cpu.vblendv(a,b,spec);
        }

        public void vblend_256x8u_outline()
        {
            var w = n256;
            var a = gcpu.vinc(w, z8);
            var b = gcpu.vdec(w, Max8u);
            var spec = v8u(cpu.vbroadcast(w, (ushort)((ushort)Pow2.T07 << 8)));
            var c = gcpu.vblend(a,b,spec);
        }

        public void vblend_128x16u_outline()
        {
            var w = n128;
            var alt = (uint)M.Msb16x8x1 << 16;
            cpu.vcover(v16u(cpu.vbroadcast(w,alt)), out Vector128<byte> spec);
            var a = gcpu.vinc(w,z16);
            var b = gcpu.vdec(w,Max16u);
            var c = gcpu.vblend(a,b,spec);
        }

        public void vblend_256x16u_outline()
        {
            var w = n256;
            var altOdd = (uint)M.Msb16x8x1 << 16;
            var altEven = (uint)M.Msb16x8x1;
            cpu.vcover(v16u(gcpu.vbroadcast<uint>(w, altOdd)), out Vector256<byte> spec);
            var a = gcpu.vinc(w,z16);
            var b = gcpu.vdec(w,Max16u);
            var c = gcpu.vblend(a,b,spec);
        }

        public void valignr_examples()
        {
            var sep = Chars.Comma;
            var pad = 2;
            void example1()
            {
                var n = n128;
                var x = cpu.vbroadcast(n, (byte)1);
                var y = cpu.vbroadcast(n, (byte)2);
                Trace($"x{n}", x.Format());
                Trace($"y{n}", y.Format());
                Trace("valignr/3", gcpu.valignr(x,y, 3).Format());
                Trace("valignr/4", gcpu.valignr(x,y, 4).Format());
                Trace("valignr/5", gcpu.valignr(x,y, 5).Format());
                Trace("valignr/6", gcpu.valignr(x,y, 6).Format());
                Trace("valignr/7", gcpu.valignr(x,y, 7).Format());
                Trace("valignr/8", gcpu.valignr(x,y, 8).Format());
            }

            void example2()
            {
                var n = n256;
                var x = cpu.vbroadcast(n, (byte)1);
                var y = cpu.vbroadcast(n, (byte)2);
                Trace($"x{n}", x.FormatLanes());
                Trace($"y{n}", y.FormatLanes());
                Trace("valignr/3", gcpu.valignr(x,y, 3).FormatLanes());
                Trace("valignr/4", gcpu.valignr(x,y, 4).FormatLanes());
                Trace("valignr/5", gcpu.valignr(x,y, 5).FormatLanes());
                Trace("valignr/6", gcpu.valignr(x,y, 6).FormatLanes());
                Trace("valignr/7", gcpu.valignr(x,y, 7).FormatLanes());
                Trace("valignr/8", gcpu.valignr(x,y, 8).FormatLanes());
            }
        }

        public void vblend_8x16_basecases()
        {
            var n = n128;
            var x = cpu.vparts(n, 0,2,4,6,8,A,C,E);
            var y = cpu.vparts(n, 1,3,5,7,9,B,D,F);

            Claim.veq(x, cpu.vblend(x,y, Blend8x16.LLLLLLLL));
            Claim.veq(y, cpu.vblend(x,y, Blend8x16.RRRRRRRR));
            Claim.veq(cpu.vparts(n, 0,2,4,6,9,B,D,F), cpu.vblend(x,y, Blend8x16.LLLLRRRR));
            Claim.veq(cpu.vparts(n, 1,3,5,7,8,A,C,E), cpu.vblend(x,y, Blend8x16.RRRRLLLL));

        }

        public void vblend_4x64_basecases()
        {
            var n = n256;
            var w = w64;
            var left = cpu.vparts(n,0,1,2,3);
            var right = cpu.vparts(n,4,5,6,7);

            Claim.veq(cpu.vparts(n,0,5,2,7), cpu.vblend4x64(left, right, Blend4x64.LRLR));
            Claim.veq(cpu.vparts(n,4,1,6,3), cpu.vblend4x64(left, right, Blend4x64.RLRL));
            Claim.veq(cpu.vparts(n,0,1,2,3), cpu.vblend4x64(left, right, Blend4x64.LLLL));
            Claim.veq(cpu.vparts(n,4,5,6,7), cpu.vblend4x64(left, right, Blend4x64.RRRR));
        }

        public void vblend_2x64_basecases()
        {
            var n = w128;
            var w = w64;
            var left =  cpu.vparts(0,1);
            var right = cpu.vparts(4,5);
            Claim.veq(cpu.vparts(0, 5), cpu.vblend2x64(left, right, Blend2x64.LR));
            Claim.veq(cpu.vparts(4, 1), cpu.vblend2x64(left, right, Blend2x64.RL));
            Claim.veq(cpu.vparts(0, 1), cpu.vblend2x64(left, right, Blend2x64.LL));
            Claim.veq(cpu.vparts(4, 5), cpu.vblend2x64(left, right, Blend2x64.RR));
        }

        public void vblend_4x32_basecases()
        {
            var n = w128;
            var w = w32;
            var left =  cpu.vparts(n,0,1,2,3);
            var right = cpu.vparts(n,4,5,6,7);
            Claim.veq(cpu.vparts(n,0,5,2,7), cpu.vblend4x32(left,right,Blend4x32.LRLR));
            Claim.veq(cpu.vparts(n,4,1,6,3), cpu.vblend4x32(left,right,Blend4x32.RLRL));
            Claim.veq(cpu.vparts(n,0,1,6,7), cpu.vblend4x32(left,right,Blend4x32.LLRR));
            Claim.veq(cpu.vparts(n,4,5,2,3), cpu.vblend4x32(left,right,Blend4x32.RRLL));
        }

        public void vblend_8x32_basecases()
        {
            var n = w256;
            var w = w32;
            var left =  cpu.vparts(0,1,2,3,4,5,6,7);
            var right = cpu.vparts(8,9,A,B,C,D,E,F);
            Claim.veq(cpu.vparts(0,9,2,B,4,D,6,F), cpu.vblend(left,right, Blend8x32.LRLRLRLR));
            Claim.veq(cpu.vparts(8,1,A,3,C,5,E,7), cpu.vblend(left,right, Blend8x32.RLRLRLRL));
            Claim.veq(cpu.vparts(0,1,A,B,4,5,E,F), cpu.vblend(left,right, Blend8x32.LLRRLLRR));
            Claim.veq(cpu.vparts(8,9,2,3,C,D,6,7), cpu.vblend(left,right, Blend8x32.RRLLRRLL));

            var lrpattern = v32u(cpu.vbroadcast(n,((ulong)(uint.MaxValue) << 32)));
            for(byte i=0; i < 8; i++)
                Claim.eq(vcell(lrpattern,i), gmath.even(i) ? 0u : uint.MaxValue);

            var zero = gcpu.vzero<uint>(n);
            var ones = gcpu.vones<uint>(n);
            Claim.veq(lrpattern, cpu.vblend(zero, ones, Blend8x32.LRLRLRLR));
        }

        public void vblend_32x8_256x32u_basecase()
        {
            var n = w256;
            var x = cpu.vparts(0,1,2,3,4,5,6,7);
            var y = cpu.vparts(8,9,A,B,C,D,E,F);
            var e = cpu.vparts(0,9,2,B,4,D,6,F);
            var o = cpu.vparts(8,1,A,3,C,5,E,7);
            var mEven = cpu.vblendspec(n,false,n32);
            var mOdd = cpu.vblendspec(n,true,n32);
            Claim.veq(e, gcpu.vblend(x,y,mEven));
            Claim.veq(o, gcpu.vblend(x,y,mOdd));
        }

        public void vblend_32x8_256x64u_basecase()
        {
            var n = w256;
            var x = cpu.vparts(n,0,1,2,3);
            var y = cpu.vparts(n,4,5,6,7);
            var e = cpu.vparts(n,0,5,2,7);
            var o = cpu.vparts(n,4,1,6,3);
            var mEven = cpu.vblendspec(n,false,n64);
            var mOdd = cpu.vblendspec(n,true,n64);
            Claim.veq(e, gcpu.vblend(x,y,mEven));
            Claim.veq(o, gcpu.vblend(x,y,mOdd));
        }

        public void vblend_32x8_256x64u()
        {
            var n = n256;

            var selectors = Random.BitStream32().Take(RepCount).ToArray();

            for(var sample=0; sample<RepCount; sample++)
            {
                var xs = Random.SpanBlocks<ulong>(n);
                var x = xs.LoadVector();
                Claim.veq(x, cpu.vparts(n, xs[0], xs[1], xs[2], xs[3]));

                var ys = Random.SpanBlocks<ulong>(n);
                var y = ys.LoadVector();
                Claim.veq(y, cpu.vparts(n, ys[0], ys[1], ys[2], ys[3]));

                var m = cpu.vblendspec(n256,false,n64);
                var es = SpanBlocks.single<ulong>(n);
                for(var i=0; i<es.CellCount; i++)
                    es[i] = gmath.odd(i) ? ys[i] : xs[i];
                var expect = es.LoadVector();
                var actual = gcpu.vblend(x,y,m);

                Claim.veq(expect,actual);
            }
        }
    }
}