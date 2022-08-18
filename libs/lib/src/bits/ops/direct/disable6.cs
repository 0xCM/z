//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
     partial class bits
     {
          /// <summary>
          /// Disables a sequence of 6 source bits starting at a specified offset
          /// </summary>
          /// <param name="src">The bit source</param>
          /// <param name="offset">The offset at which to begin clearing bits</param>
          [MethodImpl(Inline), Disable]
          public static byte disable6(byte src, byte offset)
          {
               var mask = ulong.MaxValue ^ ((ulong)uint6.MaxValue << offset);
               return (byte)(mask & src);
          }

          /// <summary>
          /// Disables a sequence of 6 source bits starting at a specified offset
          /// </summary>
          /// <param name="src">The bit source</param>
          /// <param name="offset">The offset at which to begin clearing bits</param>
          [MethodImpl(Inline), Disable]
          public static ushort disable6(ushort src, byte offset)
          {
               var mask = ulong.MaxValue ^ ((ulong)uint6.MaxValue << offset);
               return (ushort)(mask & src);
          }

          /// <summary>
          /// Disables a sequence of 6 source bits starting at a specified offset
          /// </summary>
          /// <param name="src">The bit source</param>
          /// <param name="offset">The offset at which to begin clearing bits</param>
          [MethodImpl(Inline), Disable]
          public static uint disable6(uint src, byte offset)
          {
               var mask = ulong.MaxValue ^ ((ulong)uint6.MaxValue << offset);
               return (uint)(mask & src);
          }

          /// <summary>
          /// Disables a sequence of 6 source bits starting at a specified offset
          /// </summary>
          /// <param name="src">The bit source</param>
          /// <param name="offset">The offset at which to begin clearing bits</param>
          [MethodImpl(Inline), Disable]
          public static ulong disable6(ulong src, byte offset)
          {
               var mask = ulong.MaxValue ^ ((ulong)uint6.MaxValue << offset);
               return (ulong)(mask & src);
          }

          /// <summary>
          /// Disables a sequence of 6 source bits starting at a specified offset
          /// </summary>
          /// <param name="src">The bit source</param>
          /// <param name="offset">The offset at which to begin clearing bits</param>
          [MethodImpl(Inline), Disable]
          public static byte disable(N6 n, byte src, byte offset)
          {
               var mask = ulong.MaxValue ^ ((ulong)uint6.MaxValue << offset);
               return (byte)(mask & src);
          }

          /// <summary>
          /// Disables a sequence of 6 source bits starting at a specified offset
          /// </summary>
          /// <param name="src">The bit source</param>
          /// <param name="offset">The offset at which to begin clearing bits</param>
          [MethodImpl(Inline), Disable]
          public static ushort disable(N6 n, ushort src, byte offset)
          {
               var mask = ulong.MaxValue ^ ((ulong)uint6.MaxValue << offset);
               return (ushort)(mask & src);
          }

          /// <summary>
          /// Disables a sequence of 6 source bits starting at a specified offset
          /// </summary>
          /// <param name="src">The bit source</param>
          /// <param name="offset">The offset at which to begin clearing bits</param>
          [MethodImpl(Inline), Disable]
          public static uint disable(N6 n, uint src, byte offset)
          {
               var mask = ulong.MaxValue ^ ((ulong)uint6.MaxValue << offset);
               return (uint)(mask & src);
          }

          /// <summary>
          /// Disables a sequence of 6 source bits starting at a specified offset
          /// </summary>
          /// <param name="src">The bit source</param>
          /// <param name="offset">The offset at which to begin clearing bits</param>
          [MethodImpl(Inline), Disable]
          public static ulong disable(N6 n,ulong src, byte offset)
          {
               var mask = ulong.MaxValue ^ ((ulong)uint6.MaxValue << offset);
               return (ulong)(mask & src);
          }
     }
}