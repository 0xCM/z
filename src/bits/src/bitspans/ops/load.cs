//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class BitSpans
    {
         [MethodImpl(Inline), Op]
         public static BitSpan load(Span<bit> src)
            => new BitSpan(src);

         [Op]
         public static BitSpan load(byte src)
            => BitSpans.scalar(src);

         [Op]
         public static BitSpan load(sbyte src)
            => BitSpans.scalar(src);

         [Op]
         public static BitSpan load(ushort src)
            => BitSpans.scalar(src);

         [Op]
         public static BitSpan load(short src)
            => BitSpans.scalar(src);

         [Op]
         public static BitSpan load(int src)
            => BitSpans.scalar(src);

         [Op]
         public static BitSpan load(uint src)
            => BitSpans.scalar(src);

         [Op]
         public static BitSpan load(long src)
            => BitSpans.scalar(src);

         [Op]
         public static BitSpan load(ulong src)
            => BitSpans.scalar(src);

         [Op]
         public static BitSpan load(float src)
            => BitSpans.scalar(src);

         [Op]
         public static BitSpan load(double src)
            => BitSpans.scalar(src);

         [Op, Closures(Closure)]
         public static BitSpan load<T>(Vector128<T> src, uint? maxbits = null)
            where T : unmanaged
        {
            var bits = BitSpans.create(bytes(src));
            if(maxbits != null)
                return slice(bits.Storage, 0, maxbits.Value);
            else
                return bits;
        }

         [Op, Closures(Closure)]
         public static BitSpan load<T>(Vector256<T> src, uint? maxbits = null)
            where T : unmanaged
        {
            var bits = BitSpans.create(bytes(src));
            if(maxbits != null)
                return slice(bits.Storage, 0, maxbits.Value);
            else
                return bits;
        }

        [Op, Closures(Closure)]
        public static BitSpan load<T>(T src, uint? maxbits = null)
            where T : unmanaged
        {
            var bits = BitSpans.create(bytes(src));
            if(maxbits != null)
                return slice(bits.Storage, 0, maxbits.Value);
            else
                return bits;
        }
    }
}