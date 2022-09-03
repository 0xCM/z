//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static Root;
    using static core;

    public class t_bitspan_ops : t_bits<t_bitspan_ops>
    {
        public override bool Enabled => true;

        public void bitspan_scalar32_bench()
        {
            var clock = counter();
            var last = 0u;
            var ops = 0;

            for(var cycle = 0; cycle<Pow2.T12; cycle++)
            {
                var data = Random.BitSpan32(Pow2.T10);
                clock.Start();
                for(var i=0; i<data.Length; i+= 32, ops++)
                    last = BitSpans32.extract<uint>(data, i);
                clock.Stop();
            }

            ReportBenchmark("bitspan_scalar/32", ops, clock);
        }

        public void bsequals()
        {
            for(var i=0; i<RepCount; i++)
            {
                var a = Random.Next<ulong>().ToBitSpan32();
                var b = Random.Next<ulong>().ToBitSpan32();
                var c = a.Replicate();
                Claim.require(a != b);
                Claim.require(a == c);
            }
        }

        public void bsparse()
        {
            bsparse_check(z8);
            bsparse_check(z16);
            bsparse_check(z32);
            bsparse_check(z64);
        }

        public void bstrim()
        {
            var x0 = 0b_01011000_00001000_11111010_01100101u;
            var x1 = x0.ToBitSpan32();
            var x2 = x1.Extract<uint>();
            Claim.eq(x0,x2);

            var x = 0b10100001100101010001u;
            var bsSrc = "0000010100001100101010001";

            var bs1 = BitSpans32.parse(bsSrc);
            Claim.eq((int)bs1.Length, bsSrc.Length);

            var bs2 = BitSpans32.from(x);
            CheckBitSpans.eq(bs1.Trim(),bs2.Trim());

            var y = bs1.Convert<uint>();
            Claim.eq(x,y);
        }

        public void or_8()
            => bsor_check(z8);

        public void bsor_16()
            => bsor_check(z16);

        public void bsor_32()
            => bsor_check(z32);

        public void bsor_64()
            => bsor_check(z64);

        public void bsxor_8()
            => bsxor_check(z8);
        public void bsxor_16()
            => bsxor_check(z16);

        public void bsxor_32()
            => bsxor_check(z32);

        public void bsxor_64()
            => bsxor_check(z64);

        public void bsbitload_check()
        {
            var bytecount = RepCount;
            SpanBlock256<uint> unpacked = SpanBlocks.alloc<uint>(n256,bytecount);
            SpanBlock64<byte> buffer = SpanBlocks.single<byte>(n64);
            Span<byte> packed = stackalloc byte[bytecount];

            for(var i=0; i<RepCount; i++)
            {
                Random.Fill(packed);
                gpack.unpack1x32(packed, unpacked);
                var bitspan = BitSpans32.load(unpacked.As<Bit32>());
                bitspan_check(packed,bitspan);
            }
        }

        public void bsformat_8()
            => bsformat_check(z8);

        public void bsformat_16()
            => bsformat_check(z16);

        public void bsformat_32()
            => bsformat_check(z32);

        public void bsformat_64()
            => bsformat_check(z64);

        public void bsload_scalars_8()
            => bsload_scalars_check(z8);

        public void bsload_scalars_16()
            => bsload_scalars_check(z16);

        public void bsload_scalars_32()
            => bsload_scalars_check(z32);

        public void bsload_scalars_64()
            => bsload_scalars_check(z64);

        public void bitslice_32()
        {
            var x = BitMaskLiterals.Even32x2;
            var y = x.ToBitSpan32();
            var t = z32;

            var z0 = y[0,2,t];
            Claim.eq(0b11,z0);
            var z1 = y[2,2,t];
            Claim.eq(0b00,z1);
            var z2 = y[4,2,t];
            Claim.eq(0b11,z2);
            var z3 = y[6,2,t];
            Claim.eq(0b00,z3);
        }

        public void bitpack_bench()
        {
            bitpack_bench(z8);
            bitpack_bench(z16);
            bitpack_bench(z32);
            bitpack_bench(z64);
        }

        void bitpack_bench<T>(T t = default)
            where T : unmanaged
        {
            var n = width<T>(w32);
            var ops = 0;
            var composite = default(T);
            var clock = counter();
            var packed = Random.Span<T>(RepCount);

            for(var cycle = 0; cycle < CycleCount; cycle++)
            {
                clock.Start();
                var bs =  BitSpans32.load(packed);
                for(var j=0u; j < bs.Length; j+= n, ops++)
                    gmath.or(composite, BitSpans32.extract<T>(bs,(int)j));
                clock.Stop();

                Random.Fill(packed);
            }

            ReportBenchmark($"bitspan_pack/{n}", ops, clock);
        }

        public void loadscalar()
        {
            bscreate_check(z8);
            bscreate_check(z8i);
            bscreate_check(z16);
            bscreate_check(z16i);
            bscreate_check(z32);
            bscreate_check(z32i);
            bscreate_check(z64);
            bscreate_check(z64i);
        }

        public void extract()
        {
            bsextract_check(z8);
            bsextract_check(z8i);
            bsextract_check(z16);
            bsextract_check(z16i);
            bsextract_check(z32);
            bsextract_check(z32i);
            bsextract_check(z64);
            bsextract_check(z64i);
        }

        void bsor_check<T>(T t = default)
            where T : unmanaged
        {
            var n = width<T>();

            for(var rep = 0; rep <= RepCount; rep++)
            {
                var x = Random.BitSpan32(n);
                var y = Random.BitSpan32(n);
                var z = x | y;
                var a = x.Extract(t);
                var b = y.Extract(t);
                var c = gmath.or(a, b);
                Claim.eq(c, z.Extract(t));
            }
        }

        void bsxor_check<T>(T t = default)
            where T : unmanaged
        {
            var n = width<T>();

            for(var rep = 0; rep <= RepCount; rep++)
            {
                var x = Random.BitSpan32(n);
                var y = Random.BitSpan32(n);
                var z = x ^ y;
                var a = x.Extract(t);
                var b = y.Extract(t);
                var c = gmath.xor(a, b);
                Claim.eq(c, z.Extract(t));
            }
        }

        void bsformat_check<T>(T t = default)
            where T : unmanaged
        {
            var length = width<T>();
            var src = BitMasks.even(n2, n1, t);
            var bitspan = BitSpans32.from<T>(src);
            var format = bitspan.Format();

            Claim.eq(length, bitspan.Length);
            for(uint i=0, j = length - 1; i< length; i++, j--)
            {
                if(gmath.even(i))
                {
                    Claim.require(bitspan[i]);
                    ClaimPrimalSeq.eq(Bit32.One, format[(int)j]);
                }
                else
                {
                    Claim.nea(bitspan[i]);
                    ClaimPrimalSeq.eq(Bit32.Zero, format[(int)j]);
                }
            }
        }

        void bsload_scalars_check<T>(T t = default)
            where T : unmanaged
        {
            var length = 64;
            Span<T> buffer = stackalloc T[length];

            for(var i=0; i<RepCount; i++)
            {
                Random.Fill(buffer);
                var bitspan = BitSpans32.load(buffer);
                bitspan_check(buffer.Bytes(),bitspan);
            }
        }

        void bscreate_check<T>(T t = default)
            where T : unmanaged
        {
            void check()
            {
                Span<byte> bytes = stackalloc byte[(int)size(t)];
                for(var i=0; i < RepCount; i++)
                {
                    var src = Random.Next<T>();
                    var bitspan = BitSpans32.from(src);
                    core.deposit(src, bytes);
                    bitspan_check(bytes, bitspan);
                }
            }

            CheckAction(check, CaseName<T>("bscreate"));
        }

        void bsextract_check<T>(T t = default)
            where T : unmanaged
        {
            void check()
            {
                for(var i=0; i< RepCount; i++)
                {
                    var a = Random.Next<T>();
                    var b = BitSpans32.from(a);
                    var c = BitSpans32.extract<T>(b);
                    Claim.eq(a,c);
                }
            }

            CheckAction(check, CaseName<T>("bsextract"));
        }

        void bsparse_check<T>(T t = default)
            where T : unmanaged
        {
            void check()
            {
                for(var i=0; i<RepCount; i++)
                {
                    var x0 = Random.Next<T>();
                    var x1 = BitSpans32.from(x0);
                    var x2 = x1.Format();
                    var x3 = BitSpans32.parse(x2);
                    var x4 = x3.Convert<T>();
                    Claim.eq(x0,x4);
                }
            }

            CheckAction(check,CaseName(SFxIdentity.identity<T>("bsparse")));
        }

        void bitspan_check(Span<byte> packed, BitSpan32 bitspan)
        {
            var bitcount = bitspan.Length;
            for(int i=0, k = 0; i < packed.Length; i++, k += 8)
            for(var j=0; j < 8; j++)
                PrimalClaims.eq((byte)Bit32.test(packed[i], j), bitspan[k + j]);
        }
    }
}