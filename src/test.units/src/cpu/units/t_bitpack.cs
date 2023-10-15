//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

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

                var packed = BitPack.pack4x8x1(bs.Scalar<uint>());
                Trace("bitstring", bs, FlairKind.Running);
                Trace("bitseq", bitseq.Format(), FlairKind.Running);

                Claim.eq(bs.TakeScalar<byte>(), packed);
            }
        }



    /// <summary>
    /// Packs 64 1-bit values taken from the least significant bit of each source byte
    /// </summary>
    /// <param name="src">The data source</param>
    [MethodImpl(Inline)]
    public static ulong pack64x8x1<T>(in SpanBlock512<T> src, uint block)
        where T : unmanaged
            => BitPack.pack64x8x1(src.BlockLead((int)block));


        /// <summary>
        /// Distributes each packed source bit to the least significant bit of the corresponding target byte
        /// </summary>
        /// <param name="src">The packed source bits</param>
        /// <param name="dst">The blocked target</param>
        /// <param name="block">The block index</param>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Inline), Op]
        public static SpanBlock512<byte> unpack1x64(ulong src, in SpanBlock512<byte> dst, int block)
        {
            BitPack.unpack1x64x8(src, dst.CellBlock(block));
            return dst;
        }
        public void unpack_64()
        {
            for(var sample=0; sample< RepCount; sample++)
            {
                var src = Random.Next<ulong>();
                var dst = SpanBlocks.alloc<byte>(n512,1);
                unpack1x64(src, dst,0);

                unpack_check(src,dst.Storage);

                var rebound = pack64x8x1(dst,0);

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

        /// <summary>
        /// Pack 16 1-bit values taken from the least significant bit of each source byte
        /// </summary>
        /// <param name="src">The pack source</param>
        [MethodImpl(Inline), Op]
        public static ushort pack16x8x1<T>(SpanBlock128<T> src, uint block = 0)
            where T : unmanaged
                => BitPack.pack16x8x1(src.BlockLead((int)block));

        public void pack_8x1_basecase()
        {
            void case2()
            {
                var src = SpanBlocks.alloc<byte>(n128,1);
                gcpu.vones<byte>(n128).StoreTo(src);
                var dst = pack16x8x1(src);
                Claim.eq(dst,ushort.MaxValue);
            }

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