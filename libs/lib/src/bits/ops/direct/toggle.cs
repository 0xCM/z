//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
     partial class bits
     {
          [MethodImpl(Inline), Toggle]
          public static sbyte toggle(sbyte src, int pos)
               => src ^= (sbyte)(1 << pos);

          [MethodImpl(Inline), Toggle]
          public static byte toggle(byte src, int pos)
               => src ^= (byte)(1 << pos);

          [MethodImpl(Inline), Toggle]
          public static short toggle(short src, int pos)
               => src ^= (short)(1 << pos);

          [MethodImpl(Inline), Toggle]
          public static ushort toggle(ushort src, int pos)
               => src ^= (ushort)(1 << pos);

          [MethodImpl(Inline), Toggle]
          public static int toggle(int src, int pos)
               => src ^= (1 << pos);

          [MethodImpl(Inline), Toggle]
          public static uint toggle(uint src, int pos)
               => src ^= (1u << pos);

          [MethodImpl(Inline), Toggle]
          public static long toggle(long src, int pos)
               => src ^= (1L << pos);

          [MethodImpl(Inline), Toggle]
          public static ulong toggle(ulong src, int pos)
               => src ^= (1ul << pos);

          /// <summary>
          /// Flips an identified source bit
          /// </summary>
          /// <param name="src">The bit source</param>
          /// <param name="pos">The position of the bit to toggle</param>
          [MethodImpl(Inline), Toggle]
          public static float toggle(float src, int pos)
          {
               ref var bits = ref Unsafe.As<float,int>(ref src);
               bits ^= (1 << pos);
               return src;
          }

          /// <summary>
          /// Flips an identified source bit
          /// </summary>
          /// <param name="src">The bit source</param>
          /// <param name="pos">The position of the bit to toggle</param>
          [MethodImpl(Inline), Toggle]
          public static double toggle(double src, int pos)
          {
               ref var bits = ref Unsafe.As<double,long>(ref src);
               bits ^= (1L << pos);
               return src;
          }
     }
}