//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.Intrinsics;

    using static core;
    using static Root;
    using static cpu;
    using static HexConst;

    public class t_vconvert : t_inx<t_vconvert>
    {
        VClaims VClaims => default;

        public void check_duplicates()
        {
            var n = w256;
            var width = w32;

            var x0 = vparts(n, 0,1,2,3,4,5,6,(uint)7);
            var y0 = vduplicate(n0,width,x0);
            var z0 = vduplicate(n1,width,x0);
            VClaims.veq(y0, vparts(n, 0,0,2,2,4,4,6,(uint)6));
            VClaims.veq(z0, vparts(n, 1,1,3,3,5,5,7,(uint)7));

            var x1 = vparts(n,0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F);
            var y1 = vduplicate(n0,width,x1);
            var z1 = vduplicate(n1,width,x1);
            VClaims.veq(y1, vparts(n,0,1, 0,1, 4,5, 4,5, 8,9, 8,9, C,D, C,D));
            VClaims.veq(z1, vparts(n,2,3, 2,3, 6,7, 6,7, A,B, A,B, E,F, E,F));

            var x2 = vparts(n,
                ulong.MaxValue & 0x55555555AAAAAAAA,
                ulong.MaxValue & 0xCCCCCCCC88888888,
                ulong.MaxValue & 0x3333333377777777,
                ulong.MaxValue & 0x2222222244444444);
            var y2 = vduplicate(n0, w64, x2);
            var z2 = vduplicate(n1, w64, x2);
        }

        public void check_covers()
        {
            var x1 = vparts(4,8);
            var y1 = vparts(w128,4,4,4,4, 4,4,4,4, 8,8,8,8, 8,8,8,8);
            var z1 = vcover(x1, out Vector128<byte> _);
            VClaims.veq(y1,z1);

            var x2 = vparts(w128, 4u,5,6,7);
            var y2 = vparts(w128, 4, 4, 4, 4,5,5,5,5, 6,6,6,6, 7,7,7,7);
            var z2 = vcover(x2, out Vector128<byte> _);
            VClaims.veq(y2, z2);

            var x3 = vparts(w128,4,5,6,7);
            var y3 = vparts(w128,4,4, 5,5, 6,6, 7,7);
            var z3 = vcover(x3, out Vector128<ushort> _);
            VClaims.veq(y3, z3);

            var x4 = vparts(4,5);
            var y4 = vparts(w128,4,4, 5,5);
            var z4 = vcover(x4, out Vector128<uint> _);
            VClaims.veq(y4,z4);

            var x5 =vparts(w256, 0ul,1,2,3);
            var y5 = vparts(w256,
                 0, 0, 0, 0, 0, 0, 0, 0,
                 1, 1, 1, 1, 1, 1, 1, 1,
                 2, 2, 2, 2, 2, 2, 2, 2,
                 3, 3, 3, 3, 3, 3, 3, 3);
            vcover(x5, out Vector256<byte> z5);
            VClaims.veq(y5, z5);

            var x6 = vparts(1,2,3,4,5,6,7,8);
            var y6 = vparts(w256,
                 1, 1, 1, 1, 2, 2, 2, 2,
                 3, 3, 3, 3, 4, 4, 4, 4,
                 5, 5, 5, 5, 6, 6, 6, 6,
                 7, 7, 7, 7, 8, 8, 8, 8);
            vcover(x6, out Vector256<byte> z6);
            VClaims.veq(y6, z6);
        }

        public void block_32x8u_to_128x32u()
        {
            var blockA = SpanBlocks.parts<byte>(n32,1,2,3,4);
            var x = cpu.vparts(n128,1,2,3,4);
            var blockB = x.ToBlock();
            var y = vblocks.vinflate128x32u(blockA,0);
            var blockC = y.ToBlock();
            Claim.eq(x,y);
            Claim.eq(blockB,blockC);
        }

        public void block_64x8u_to_2x128x32u()
        {
            var block = SpanBlocks.parts<byte>(n64,1,2,3,4,5,6,7,8);
            var xE = cpu.vparts(n128,1,2,3,4);
            var yE = cpu.vparts(n128,5,6,7,8);
            var z = vblocks.vinflate256x32u(block,0);
            Claim.eq(xE, cpu.vlo(z));
            Claim.eq(yE, cpu.vhi(z));
        }

        public void block_32x8u_to_2x128x64u()
        {
            var block = SpanBlocks.parts<byte>(n32,1,2,3,4);
            var xE = cpu.vparts(1,2);
            var yE = cpu.vparts(3,4);

            var z = vpack.vinflate256x64u(block,0);
            Claim.eq(xE, cpu.vlo(z));
            Claim.eq(yE, cpu.vhi(z));
        }

        public void block_128x8u_to_2x128x16u()
        {
            var block = SpanBlocks.parts<byte>(n128,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16);
            var xE = cpu.vparts(n128,1,2,3,4,5,6,7,8);
            var yE = cpu.vparts(n128,9,10,11,12,13,14,15,16);
            var z = vpack.vinflate256x16u(block,0);

            Claim.eq(xE, cpu.vlo(z));
            Claim.eq(yE, cpu.vhi(z));
        }

        public void v128x8u_v128x16u()
        {
            var x = cpu.vparts(w128,0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F);
            var y = vpack.vlo128x16u(x);
            var z = cpu.vparts(w128,0,1,2,3,4,5,6,7);
            Claim.eq(y,z);
        }

        public void m64x8u_v128x16u()
        {
            var x = SpanBlocks.parts<byte>(w64,0,1,2,3,4,5,6,7);
            var y = vblocks.vinflate128x16u(x,0);
            var z = cpu.vparts(w128,0,1,2,3,4,5,6,7);

            Claim.eq(y,z);
        }

        public void blockspan_128x8u_v128x16u()
        {
            var x = SpanBlocks.parts<byte>(w128,0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F);
            var q = vpack.vinflate256x16u(x,0);
            var z0 = x.LoBlock(0);
            var z1 = x.HiBlock(0);
            var y0s = cpu.vlo(q).ToSpan();
            var y1s = cpu.vhi(q).ToSpan();

            for(var i=0; i <8; i++)
            {
                Claim.eq(z0[i], (byte)y0s[i]);
                Claim.eq(z1[i], (byte)y1s[i]);
            }
        }

        public void vconvert_128x8u_1x256x16u()
        {
            var sw = n128;
            var st = z8;

            var tw = n256;
            var tt = z16;

            var tbc = 1;

            var sb = SpanBlocks.single<byte>(sw);
            var tb = SpanBlocks.alloc<ushort>(tw,tbc);

            for(var sample = 0; sample < RepCount; sample++)
            {
                var sv = Random.CpuVector(sw, st);
                var tv = vpack.vinflate256x16u(sv);

                sv.StoreTo(sb);
                tv.StoreTo(tb);

                var i = 0;
                for(var block = 0; block<tb.BlockCount; block++)
                for(var j = 0; j < tb.BlockLength; j++, i++)
                {
                    var m  = tb[block,j];
                    var x = Numeric.force<byte>(m);
                    Claim.eq(sb[i], x);
                }
            }
        }

        public void vconvert_128x8u_2x128x16u()
        {
            var sw = n128;
            var st = z8;

            var tw = n128;
            var tt = z16;

            var tbc = 2;

            var sb = SpanBlocks.single<byte>(sw);
            var tb = SpanBlocks.alloc<ushort>(tw,tbc);

            for(var sample = 0; sample < RepCount; sample++)
            {
                var sv = Random.CpuVector(sw,st);
                var tv = vpack.vinflate256x16u(sv);
                var tvLo = cpu.vlo(tv);
                var tvHi = cpu.vhi(tv);

                sv.StoreTo(sb);
                tvLo.StoreTo(tb,0);
                tvHi.StoreTo(tb,1);

                var i = 0;
                for(var block = 0; block < tbc; block++)
                for(var j = 0; j < tb.BlockLength; j++, i++)
                    Claim.eq(sb[i], Numeric.force<byte>(tb[block,j]));
            }
        }
    }
}