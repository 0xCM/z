//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static core;

    public class t_gpack : t_bits<t_gpack>
    {
        public override bool Enabled
            => true;

        public void gpack_unpack_8x8()
            => unpack_check<byte,byte>();

        public void gpack_unpack_16x8()
            => unpack_check<ushort,byte>();

        public void gpack_unpack_16x16()
            => unpack_check<ushort,ushort>();

        public void gpack_unpack_32x8()
            => unpack_check<uint,byte>();

        public void gpack_unpack_32x32()
            => unpack_check<uint,uint>();

        public void gpack_unpack_32x16()
            => unpack_check<uint,ushort>();

        public void gpack_unpack_64x8()
            => unpack_check<ulong,byte>();

        public void gpack_unpack_64x16()
            => unpack_check<ulong,ushort>();

        public void gpack_unpack_64x32()
            => unpack_check<ulong,uint>();

        public void gpack_unpack_64x64()
            => unpack_check<ulong,ulong>();

        void unpack_8x8_bench()
            => unpack_bench<byte,byte>();

        void unpack_16x8_bench()
            => unpack_bench<ushort,byte>();

        void unpack_16x16_bench()
            => unpack_bench<ushort,ushort>();

        void unpack_32x8_bench()
            => unpack_bench<uint,byte>();

        void unpack_32x32_bench()
            => unpack_bench<uint,uint>();

        void unpack_32x16_bench()
            => unpack_bench<uint,ushort>();

        void unpack_64x8_bench()
            => unpack_bench<ulong,byte>();

        void unpack_64x64_bench()
            => unpack_bench<ulong,ulong>();

        void unpack_check<S,T>()
            where S : unmanaged
            where T : unmanaged
        {
            for(var j=0; j<RepCount; j++)
            {
                var src = Random.Next<S>();
                Span<T> dst = new T[width<S>()];
                BitPack.unpack(src,dst);
                var bs = BitStrings.scalar(src);
                for(var i = 0; i< bs.Length; i++)
                {
                    var expect = bs[i] ? one<T>() : zero<T>();
                    var actual = dst[i];
                    NumericClaims.eq(expect, actual);
                }
            }

            var x = Random.Span<S>(RepCount);
            Span<T> y1 = new T[x.Length * width<S>()];
            gpack.unpack32(x,y1);
            var y2 = BitStrings.scalars(x);
            for(var i=0; i< y1.Length; i++)
            {
                var expect = y2[i] ? one<T>() : zero<T>();
                var actual = y1[i];
                NumericClaims.eq(expect,actual);
            }
        }

        void unpack_bench<S,T>(SystemCounter counter = default)
            where S : unmanaged
            where T : unmanaged
        {
            var opcount = RoundCount * CycleCount;
            var srcSign = NumericKinds.signed<S>() ? "i" : string.Empty;
            var dstSign = NumericKinds.signed<T>() ? "i" : string.Empty;
            var opname = $"unpack_{width<S>()}{srcSign}x{width<T>()}{dstSign}";

            Span<T> dst = new T[width<S>()];

            for(var i=0; i<opcount; i++)
            {
                var src = Random.Next<S>();
                counter.Start();
                BitPack.unpack(src, dst);
                counter.Stop();
            }

            ReportBenchmark(opname,opcount,counter);
        }
    }
}