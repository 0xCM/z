//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static LimitValues;
    using static BitMasks;

    partial class bits
    {
          /// <summary>
          /// Disables a sequence of bits starting at a specified index
          /// </summary>
          /// <param name="src">The bit source</param>
          /// <param name="offset">The index at which to begin clearing bits</param>
          /// <param name="count">The number of bits to clear</param>
          [MethodImpl(Inline), Op]
          public static byte trim(byte src, byte offset, byte count)
          {
               var mask = (uint)Max16u ^ ((uint)lo64(count - 1) << offset);
               return (byte)(mask & src);
          }

          /// <summary>
          /// Disables a sequence of bits starting at a specified index
          /// </summary>
          /// <param name="src">The bit source</param>
          /// <param name="offset">The index at which to begin clearing bits</param>
          /// <param name="count">The number of bits to clear</param>
          [MethodImpl(Inline), Op]
          public static sbyte trim(sbyte src, byte offset, byte count)
          {
               var mask = (int)Max16u ^ ((int)lo64(count - 1) << offset);
               return (sbyte)(mask & (int)src);
          }

          /// <summary>
          /// Disables a sequence of bits starting at a specified index
          /// </summary>
          /// <param name="src">The bit source</param>
          /// <param name="offset">The index at which to begin clearing bits</param>
          /// <param name="count">The number of bits to clear</param>
          [MethodImpl(Inline), Op]
          public static ushort trim(ushort src, byte offset, byte count)
          {
               var mask = (uint)Max16u ^ ((uint)lo64(count - 1) << offset);
               return (ushort)(mask & src);
          }

          /// <summary>
          /// Disables a sequence of bits starting at a specified index
          /// </summary>
          /// <param name="src">The bit source</param>
          /// <param name="offset">The index at which to begin clearing bits</param>
          /// <param name="count">The number of bits to clear</param>
          [MethodImpl(Inline), Op]
          public static short trim(short src, byte offset, byte count)
          {
               var mask = (int)Max16u ^ ((int)lo64(count - 1) << offset);
               return (short)(mask & src);
          }

          /// <summary>
          /// Disables a sequence of bits starting at a specified index
          /// </summary>
          /// <param name="src">The bit source</param>
          /// <param name="offset">The index at which to begin clearing bits</param>
          /// <param name="count">The number of bits to clear</param>
          [MethodImpl(Inline), Op]
          public static uint trim(uint src, byte offset, byte count)
          {
               var mask = Max32u ^ ((uint)lo64(count - 1) << offset);
               return mask & src;
          }

          /// <summary>
          /// Disables a sequence of bits starting at a specified index
          /// </summary>
          /// <param name="src">The bit source</param>
          /// <param name="offset">The index at which to begin clearing bits</param>
          /// <param name="count">The number of bits to clear</param>
          [MethodImpl(Inline), Op]
          public static int trim(int src, byte offset, byte count)
               => (int)trim((uint)src,offset,count);

          /// <summary>
          /// Disables a sequence of bits starting at a specified index
          /// </summary>
          /// <param name="src">The bit source</param>
          /// <param name="offset">The index at which to begin clearing bits</param>
          /// <param name="count">The number of bits to clear</param>
          [MethodImpl(Inline), Op]
          public static long trim(long src, byte offset, byte count)
               => (long)trim((ulong)src, offset, count);

          /// <summary>
          /// Disables a sequence of bits starting at a specified index
          /// </summary>
          /// <param name="src">The bit source</param>
          /// <param name="offset">The index at which to begin clearing bits</param>
          /// <param name="count">The number of bits to clear</param>
          [MethodImpl(Inline), Op]
          public static ulong trim(ulong src, byte offset, byte count)
          {
               var mask = Max64u ^ (lo64(count - 1) << offset);
               return mask & src;
          }
    }
}