//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;

    using static Root;
    using static cpu;
    using static core;

    public class t_vperm : t_inx<t_vperm>
    {
        VClaims VClaims => default;

        public void vperm4_reverse()
        {
            const Perm4L  p = Perm4L.DCBA;
            const string pbs_expect = "00011011";
            const string pformat_epect = "[00 01 10 11]: ABCD -> DCBA";

            var pbs_actual = BitStrings.scalar((byte)p);
            Claim.eq(pbs_expect, pbs_actual);

            var p_assembled = Permute.assemble(Perm4L.D, Perm4L.C, Perm4L.B, Perm4L.A);
            Claim.eq(p, p_assembled);

            var pformat_actual = PermSymbolic.bitmap(p);
            Claim.eq(pformat_epect, pformat_actual);

            var vIn = cpu.vparts(w128, 0,1,2,3);
            var vExpect = cpu.vparts(w128, 3,2,1,0);
            var vActual = cpu.vperm4x32(vIn,p);
            Claim.veq(vExpect, vActual);
        }

        public void perm_symbols()
        {
            Claim.eq($"{Perm4L.ABDC}", Perm4L.ABDC.Format());
            Claim.eq($"{Perm4L.DCBA}", Perm4L.DCBA.Format());
            Claim.eq($"ABCDEFGH", PermLits.Perm8Identity.Format());
            Claim.eq($"HGFEDCBA", PermLits.Perm8Reversed.Format());
            Claim.eq($"0123456789ABCDEF", PermLits.Perm16Identity.Format());
        }

        public void perm4_digits()
        {
            const byte A = 0b00;
            const byte B = 0b01;
            const byte C = 0b10;
            const byte D = 0b11;

            var dABCD = Perm4L.ABCD.ToDigits();
            Claim.eq(NatSpans.parts(n4, A, B, C, D).Edit, dABCD);

            var dDCBA = Perm4L.DCBA.ToDigits();
            Claim.eq(NatSpans.parts(n4, D, C, B, A).Edit, dDCBA);

            var dACBD = Perm4L.ACBD.ToDigits();
            Claim.eq(NatSpans.parts(n4, A, C, B, D).Edit, dACBD);

            var dCBDA = Perm4L.CBDA.ToDigits();
            Claim.eq(NatSpans.parts(n4, C, B, D, A).Edit, dCBDA);
        }

        public void vpermlo_4x16_outline()
        {
            const byte A = 0b00;
            const byte B = 0b01;
            const byte C = 0b10;
            const byte D = 0b11;

            var x = gcpu.vinc<ushort>(n128);
            var xs = x.ToSpan();
            Claim.veq(Vector128.Create(xs[A], xs[B], xs[C], xs[D], xs[A + 4], xs[B + 4], xs[C + 4], xs[D + 4]), x);

            var xABCD = cpu.vpermlo4x16(x, Perm4L.ABCD);
            Claim.veq(xABCD, Vector128.Create(xs[A], xs[B], xs[C], xs[D], xs[A + 4], xs[B + 4], xs[C + 4], xs[D + 4]));

            var xDCBA = cpu.vpermlo4x16(x, Perm4L.DCBA);
            Claim.veq(xDCBA, Vector128.Create(xs[D], xs[C], xs[B], xs[A], xs[A + 4], xs[B + 4], xs[C + 4], xs[D + 4]));

            var xACBD = cpu.vpermlo4x16(x, Perm4L.ACBD);
            Claim.veq(xACBD, Vector128.Create(xs[A], xs[C], xs[B], xs[D], xs[A + 4], xs[B + 4], xs[C + 4], xs[D + 4]));

            Claim.veq(cpu.vpermlo4x16(cpu.vparts(w128, 0,1,2,3,6,7,8,9), Perm4L.ADCB), cpu.vparts(w128, 0,3,2,1,6,7,8,9));
        }

        public void vpermhi_4x16_outline()
        {
            const byte A = 0b00;
            const byte B = 0b01;
            const byte C = 0b10;
            const byte D = 0b11;

            var x = gcpu.vinc<ushort>(n128);
            var xs = x.ToSpan();
            Claim.veq(Vector128.Create(xs[A], xs[B], xs[C], xs[D], xs[A+4], xs[B+ 4], xs[C + 4], xs[D + 4]), x);

            var xABCD = cpu.vpermhi4x16(x, Perm4L.ABCD);
            Claim.veq(xABCD, Vector128.Create(xs[A], xs[B], xs[C], xs[D], xs[A + 4], xs[B + 4], xs[C + 4], xs[D + 4]));

            var xDCBA = cpu.vpermhi4x16(x, Perm4L.DCBA);
            Claim.veq(xDCBA, Vector128.Create(xs[A], xs[B], xs[C], xs[D], xs[D + 4], xs[C + 4], xs[B + 4], xs[A + 4]));

            var xACBD = cpu.vpermhi4x16(x, Perm4L.ACBD);
            Claim.veq(xACBD, Vector128.Create(xs[A], xs[B], xs[C], xs[D], xs[A + 4], xs[C + 4], xs[B + 4], xs[D + 4]));

            Claim.veq(cpu.vpermhi4x16(cpu.vparts(w128, 0,1,2,3,6,7,8,9), Perm4L.ADCB), cpu.vparts(n128,0,1,2,3,6,9,8,7));
        }

        public void vperm4x32_128x32u_outline()
        {
            var n = n128;

            var u = gcpu.vinc<uint>(n);
            Claim.veq(cpu.vparts(n,0,1,2,3), u);

            var v = gcpu.vdec<uint>(n);
            Claim.veq(cpu.vparts(n,3,2,1,0),v);

            Claim.veq(v, cpu.vperm4x32(u, Perm4L.DCBA));
            Claim.veq(u, cpu.vperm4x32(v, Perm4L.DCBA));
        }

        public void vperm_4x16_outline()
        {
            var w = W128.W;
            var x = cpu.vparts(w,0,1,2,3,4,5,6,7);

            var a0 = cpu.vpermlo4x16(x, Perm4L.DCBA);
            var a1 = cpu.vparts(w,3,2,1,0,4,5,6,7);
            Claim.veq(a0,a1);

            var b0 = cpu.vpermhi4x16(x, Perm4L.DCBA);
            var b1 = cpu.vparts(w,0,1,2,3,7,6,5,4);
            Claim.veq(b0,b1);

            var c0 = cpu.vperm4x16(x,Perm4L.DCBA,Perm4L.DCBA);
            var c1 = cpu.vparts(w,3,2,1,0,7,6,5,4);
            Claim.veq(c0,c1);

            var d0 = cpu.vpermlo4x16(x, Perm4L.BADC);
            var d1 = cpu.vparts(w,1,0,3,2,4,5,6,7);
            Claim.veq(d0,d1);

            var e0 = cpu.vpermhi4x16(x, Perm4L.BADC);
            var e1 = cpu.vparts(w,0,1,2,3,5,4,7,6);
            Claim.veq(e0,e1);

            var f0 = cpu.vperm4x16(x, Perm4L.BADC, Perm4L.BADC);
            var f1 = cpu.vparts(w,1,0,3,2,5,4,7,6);
            Claim.veq(f0,f1);
        }

        public void vperm_4x64_outline()
        {

            var n = n256;
            var x = cpu.vparts(n,0,1,2,3);

            Claim.veq(cpu.vparts(n,0,1,2,3), cpu.vperm4x64(x, Perm4L.ABCD));
            Claim.veq(cpu.vparts(n,0,1,3,2), cpu.vperm4x64(x, Perm4L.ABDC));
            Claim.veq(cpu.vparts(n,0,2,1,3), cpu.vperm4x64(x, Perm4L.ACBD));
            Claim.veq(cpu.vparts(n,0,2,3,1), cpu.vperm4x64(x, Perm4L.ACDB));
            Claim.veq(cpu.vparts(n,0,3,1,2), cpu.vperm4x64(x, Perm4L.ADBC));
            Claim.veq(cpu.vparts(n,0,3,2,1), cpu.vperm4x64(x, Perm4L.ADCB));

            Claim.veq(cpu.vparts(n,1,0,2,3), cpu.vperm4x64(x, Perm4L.BACD));
            Claim.veq(cpu.vparts(n,1,0,3,2), cpu.vperm4x64(x, Perm4L.BADC));
            Claim.veq(cpu.vparts(n,1,2,0,3), cpu.vperm4x64(x, Perm4L.BCAD));
            Claim.veq(cpu.vparts(n,1,2,3,0), cpu.vperm4x64(x, Perm4L.BCDA));
            Claim.veq(cpu.vparts(n,1,3,0,2), cpu.vperm4x64(x, Perm4L.BDAC));
            Claim.veq(cpu.vparts(n,1,3,2,0), cpu.vperm4x64(x, Perm4L.BDCA));
        }

        public void perm4_symbols()
        {
            perm4_symbol_check(Perm4L.ABCD, A,B,C,D);
            perm4_symbol_check(Perm4L.ABDC, A,B,D,C);
            perm4_symbol_check(Perm4L.ACBD, A,C,B,D);
            perm4_symbol_check(Perm4L.ACDB, A,C,D,B);
            perm4_symbol_check(Perm4L.ADBC, A,D,B,C);
            perm4_symbol_check(Perm4L.ADCB, A,D,C,B);

            perm4_symbol_check(Perm4L.BACD, B,A,C,D);
            perm4_symbol_check(Perm4L.BADC, B,A,D,C);
            perm4_symbol_check(Perm4L.BCAD, B,C,A,D);
            perm4_symbol_check(Perm4L.BCDA, B,C,D,A);
            perm4_symbol_check(Perm4L.BDAC, B,D,A,C);
            perm4_symbol_check(Perm4L.BDCA, B,D,C,A);
        }

        static Vector128<T> vswapspec<T>(N128 n, params Swap[] swaps)
            where T : unmanaged
        {
            var src = gcpu.vinc<T>(n).ToSpan();
            var dst = src.Swap(swaps);
            return gcpu.vload(n, in first(src));
        }

        [MethodImpl(Inline)]
        public static Vector128<byte> vswap(Vector128<byte> src, params Swap[] swaps)
            => cpu.vshuf16x8(src, vswapspec<byte>(w128, swaps));

        public void perm_swaps()
        {

            var src = gcpu.vinc<byte>(w128);

            Swap s = (0,1);
            var x1 = vswap(src, s);
            var x2 = vswap(x1, s);
            Claim.veq(x2, src);

            //Shuffle the first element all the way through to the last element
            var chain = Swaps.chain((0,1), 15);
            var x3 = vswap(src, chain).ToSpan();
            Claim.eq(x3[15],(byte)0);
        }

        public void perm4_symbols_random()
        {
            var perms = Random.EnumValues(A, B, C, D);
            var all = Enums.literals<Perm4L>().ToSet();
            for(var i=0; i<RepCount; i++)
            {
                var perm = perms.First();
                Claim.contains(all,perm);
                var symbols = Permute.symbols(perm);
                Claim.eq(4, symbols.Length);
            }
        }

        // void perm4x64_mapformat()
        // {
        //     var symbols = Permute.symbols(n4);
        //     root.iter(symbols, m => Trace(m.perm.ToString(), m.format));
        // }

        public void vperm_2x128_outline()
        {
            var n = n256;
            var x = cpu.vparts(n, 0, 1, 2, 3);
            var y = cpu.vparts(n, 4, 5, 6, 7);

            Claim.veq(cpu.vparts(n, 0, 1, 4, 5), gcpu.vperm2x128(x,y, Perm2x4.AC));
            Claim.veq(cpu.vparts(n, 4, 5, 0, 1), gcpu.vperm2x128(x,y, Perm2x4.CA));

            Claim.veq(cpu.vparts(n, 0, 1, 6, 7), gcpu.vperm2x128(x,y, Perm2x4.AD));
            Claim.veq(cpu.vparts(n, 6, 7, 0, 1), gcpu.vperm2x128(x,y, Perm2x4.DA));

            Claim.veq(cpu.vparts(n, 2, 3, 4, 5), gcpu.vperm2x128(x,y, Perm2x4.BC));
            Claim.veq(cpu.vparts(n, 4, 5, 2, 3), gcpu.vperm2x128(x,y, Perm2x4.CB));

            Claim.veq(cpu.vparts(n, 2, 3, 6, 7), gcpu.vperm2x128(x,y, Perm2x4.BD));
            Claim.veq(cpu.vparts(n, 6, 7, 2, 3), gcpu.vperm2x128(x,y, Perm2x4.DB));
        }

        /// <summary>
        /// Swaps hi/lo 128-bit lanes
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline)]
        public static Vector256<byte> vswaphl(Vector256<byte> x)
        {
            Vector256<byte> y = default;
            y = cpu.vinsert(cpu.vhi(x), y, LaneIndex.L0);
            y = cpu.vinsert(cpu.vlo(x), y, LaneIndex.L1);
            return y;
        }

        public void swaphl_2x128()
        {
            for(var i=0; i < RepCount; i++)
            {
                var x = Random.CpuVector<byte>(n256);
                var y = vswaphl(x);
                var _z = cpu.vswaphl(x);
                Claim.veq(y,_z);
            }
        }

        public void vperm4x64_256x64u_randomized()
        {
            for(var i=0; i<RepCount; i++)
            {
                var src = gcpu.vinc<ulong>(n256);
                var x = cpu.vperm4x64(src, Perm4L.BADC);
                var srcs = src.ToSpan();
                var y = Vector256.Create(srcs[1], srcs[0], srcs[3], srcs[2]);
                Claim.veq(x,y);
            }
        }

        public void vperm_256u8_outline()
        {
            var a = gcpu.vinc<byte>(n256);
            var b = gcpu.vdec<byte>(n256);
            var c = cpu.vreverse(cpu.vshuf32x8(a,b));
            Claim.veq(a,c);
        }


        public void e_vperm4x16()
        {
            var id = vparts(w128,0,1,2,3,6,7,8,9);
            VClaims.veq(vperm4x16(vparts(w128,0,1,2,3,6,7,8,9), Perm4L.ADCB, Perm4L.ADCB), vparts(w128,0,3,2,1,6,9,8,7));
        }

        public void e_vperm4x32_128x32u_A()
        {
            var trace = false;
            var pSrc = Random.EnumValues<Perm4L>(x => (byte)x > 5);

            for(var i=0; i<CycleCount; i++)
            {
                var v1 = Random.CpuVector<uint>(n128);
                var v1s = v1.ToSpan();
                var p = pSrc.First();

                // Disassemble the spec
                var p0 = bits.gather((byte)p, (byte)0b11);
                var p1 = bits.gather((byte)p, (byte)0b1100);
                var p2 = bits.gather((byte)p, (byte)0b110000);
                var p3 = bits.gather((byte)p, (byte)0b11000000);

                // Reassemble the spec
                Perm4L q = (Perm4L)(p0 | p1 << 2 | p2 << 4 | p3 << 6);

                // Same?
                Claim.eq(p,q);

                // Permute vector via api
                var v2 = vperm4x32(v1,p);

                // Permute vector manually
                var v3 = vparts(w128, v1s[p0],v1s[p1],v1s[p2],v1s[p3]);

                // Same?
                VClaims.veq(v3,v2);

                if(trace)
                {
                    base.Trace("v1", v1.FormatHex());
                    base.Trace("p", p.Format());
                    base.Trace("perm(v1,p)", v2.FormatHex());
                }
            }
        }

        public void e_vperm4x32_128x32u_B()
        {
            var n = n128;
            var src = vparts(w128, 1,2,3,4);
            var spec = Perm4L.ABCD;
            var y = vparts(w128, 4,3,2,1);
            var x = vperm4x32(src, Perm4L.ABCD);
            VClaims.veq(x, src);

            y = vparts(w128,4,3,2,1);
            spec = Perm4L.DCBA;
            x = vperm4x32(src,spec);
            VClaims.veq(x, y);

            y = vparts(w128,4u,3u,2u,1u);
            spec = Perm4L.DCBA;
            x = vperm4x32(src,spec);
            VClaims.veq(x, y);

            VClaims.veq(vperm4x32(vparts(w128, 0,1,2,3), Perm4L.ADCB), vparts(w128, 0,3,2,1));
            VClaims.veq(vperm4x32(vparts(w128, 0,1,2,3), Perm4L.DBCA), vparts(w128, 3,1,2,0));
        }

        void perm4_symbol_check(Perm4L perm, params Perm4L[] expect)
        {
            Claim.eq(4, expect.Length);
            var symbol = default(SymVal<Perm4L>);
            for(var i=0; i<expect.Length; i++)
            {
                base.Claim.require(Permute.symbol(perm, i, out symbol));
                Claim.eq(expect[i], symbol.Value);
            }
        }

        const Perm4L A = Perm4L.A;

        const Perm4L B = Perm4L.B;

        const Perm4L C = Perm4L.C;

        const Perm4L D = Perm4L.D;
    }
}