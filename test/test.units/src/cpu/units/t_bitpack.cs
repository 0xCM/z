//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class t_bitpack : t_inx<t_bitpack>
    {
        void pack_32x4()
        {
            var block = w32;
            var count = n4;
            var mod = n8;
            for(var sample = 0; sample<RepCount; sample++)
            {
                var bs = Random.BitString(count);
                var bitseq = bs.BitSeq.Blocked(block);
                Claim.eq(bitseq.CellCount,n4);

                var packed = BitPack.pack4x8x1(bitseq,0);
                Trace("bitstring", bs, FlairKind.Running);
                Trace("bitseq", bitseq.Format(), FlairKind.Running);

                Claim.eq(bs.TakeScalar<byte>(), packed);
            }
        }

        public void unpack_16()
        {
            for(var sample = 0; sample < RepCount; sample ++)
            {
                var src = Random.Next<ushort>();
                var dst = SpanBlocks.single<byte>(n128);

                BitPack.unpack1x16x8(src, dst, 0);
                unpack_check(src,dst);

                var rebound = BitPack.pack16x8x1(dst);
                Claim.eq(src,rebound);
            }
        }

        public void unpack_32()
        {
            for(var sample=0; sample< RepCount; sample++)
            {
                var src = Random.Next<uint>();
                var dst = SpanBlocks.single<byte>(n256);
                BitPack.unpack1x32x8(src, dst,0);

                unpack_check(src,dst);

                var rebound = BitPack.pack32x8x1(dst);
                Claim.eq(src,rebound);
            }
        }

        public void unpack_64()
        {
            for(var sample=0; sample< RepCount; sample++)
            {
                var src = Random.Next<ulong>();
                var dst = SpanBlocks.single<byte>(n512);
                BitPack.unpack1x64(src, dst,0);

                unpack_check(src,dst.Storage);

                var rebound = BitPack.pack64x8x1(dst,0);

                ClaimPrimal.eq(src,rebound);
            }
        }

        public void pack_32x4_2()
        {
            var block1 = SpanBlocks.alloc<ushort>(w16,1);
            block1[0] = ushort.MaxValue;
            var val1 = block1.BlockLead(0);
            Trace(val1.ToBitString());

            var block2 = SpanBlocks.alloc<uint>(w32,1);
            block2[0] = uint.MaxValue;
            var val2 = block2.BlockLead(0);
            Trace(val2.ToBitString());
        }

        public void unpack_64x32()
        {
            var dst = new uint[64];

            for(var rep = 0; rep < RepCount; rep++)
            {
                var src = Random.Next<ulong>();
                gpack.unpack1x32<ulong>(src, dst);
                // for(byte i=0u; i< dst.Length; i++)
                //     Claim.eq((ulong)bit.test(src,i), dst[i]);
            }
        }

        public void pack_8x1_256()
        {
            var count = n32;
            var block = n256;

            for(var sample = 0; sample<RepCount; sample++)
            {
                var bs = Random.BitString(count);
                var bitseq = bs.BitSeq.Blocked(block);
                uint packed = BitPack.pack32x8x1(bitseq);
                // for(byte i=0u; i< count; i++)
                //     Claim.eq((byte)bs[i], (byte)bit.test(packed, i));
            }
        }

        public void pack_32()
        {
            var n = 32;
            Span<Bit32> buffer = new Bit32[n];
            for(var i=0; i<RepCount; i++)
            {
                var bits = Random.BitStream32().Take(Random.Next<uint>(5,25)).ToSpan();

                var expect = 0u;
                for(var j=0; j<bits.Length; j++)
                    expect |= (uint)bits[j] << j;

                buffer.Clear();
                bits.CopyTo(buffer);
                var result = BitPack32.pack<uint>(buffer);

                Claim.eq(expect, result);

            }
        }

        public void pack_8x1_basecase()
        {
            void case1()
            {
                var src = SpanBlocks.single<byte>(n256);
                gcpu.vones<byte>(n256).StoreTo(src);
                var dst = BitPack.pack32x8x1(src);
                Claim.eq(dst,uint.MaxValue);

            }

            void case2()
            {
                var src = SpanBlocks.single<byte>(n128);
                gcpu.vones<byte>(n128).StoreTo(src);
                var dst = BitPack.pack16x8x1(src);
                Claim.eq(dst,ushort.MaxValue);
            }

            case1();
            case2();
        }

        void unpack_check<T>(T src, in ReadOnlySpan<byte> y)
            where T : unmanaged
        {
            var count = math.min(width<T>(), y.Length);
            for(var i=0; i<count; i++)
                Claim.eq((byte)gbits.test(src, (byte)i), y[i]);

            Claim.eq(BitStrings.load(y.ToArray()).TakeScalar<T>(), src);
        }
    }
}