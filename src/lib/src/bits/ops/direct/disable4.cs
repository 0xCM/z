//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
     partial class bits
     {
          /// <summary>
          /// Disables a sequence of 4 source bits starting at a specified offset
          /// </summary>
          /// <param name="src">The bit source</param>
          /// <param name="offset">The offset at which to begin clearing bits</param>
          [MethodImpl(Inline), Disable]
          public static byte disable4(byte src, byte offset)
          {
               var mask = ulong.MaxValue ^ ((ulong)uint4.MaxValue << offset);
               return (byte)(mask & src);
          }

          /// <summary>
          /// Disables a sequence of 4 source bits starting at a specified offset
          /// </summary>
          /// <param name="src">The bit source</param>
          /// <param name="offset">The offset at which to begin clearing bits</param>
          [MethodImpl(Inline), Disable]
          public static ushort disable4(ushort src, byte offset)
          {
               var mask = ulong.MaxValue ^ ((ulong)uint4.MaxValue << offset);
               return (ushort)(mask & src);
          }

          /// <summary>
          /// Disables a sequence of 4 source bits starting at a specified offset
          /// </summary>
          /// <param name="src">The bit source</param>
          /// <param name="offset">The offset at which to begin clearing bits</param>
          [MethodImpl(Inline), Disable]
          public static uint disable4(uint src, byte offset)
          {
               var mask = ulong.MaxValue ^ ((ulong)uint4.MaxValue << offset);
               return (uint)(mask & src);
          }

          /// <summary>
          /// Disables a sequence of 4 source bits starting at a specified offset
          /// </summary>
          /// <param name="src">The bit source</param>
          /// <param name="offset">The offset at which to begin clearing bits</param>
          [MethodImpl(Inline), Disable]
          public static ulong disable4(ulong src, byte offset)
          {
               var mask = ulong.MaxValue ^ ((ulong)uint4.MaxValue << offset);
               return (ulong)(mask & src);
          }

          /// <summary>
          /// Disables a sequence of 4 source bits starting at a specified offset
          /// </summary>
          /// <param name="src">The bit source</param>
          /// <param name="offset">The offset at which to begin clearing bits</param>
          [MethodImpl(Inline), Disable]
          public static byte disable(N4 n, byte src, byte offset)
          {
               var mask = ulong.MaxValue ^ ((ulong)uint4.MaxValue << offset);
               return (byte)(mask & src);
          }

          /// <summary>
          /// Disables a sequence of 4 source bits starting at a specified offset
          /// </summary>
          /// <param name="src">The bit source</param>
          /// <param name="offset">The offset at which to begin clearing bits</param>
          [MethodImpl(Inline), Disable]
          public static ushort disable(N4 n, ushort src, byte offset)
          {
               var mask = ulong.MaxValue ^ ((ulong)uint4.MaxValue << offset);
               return (ushort)(mask & src);
          }

          /// <summary>
          /// Disables a sequence of 4 source bits starting at a specified offset
          /// </summary>
          /// <param name="src">The bit source</param>
          /// <param name="offset">The offset at which to begin clearing bits</param>
          [MethodImpl(Inline), Disable]
          public static uint disable(N4 n, uint src, byte offset)
          {
               var mask = ulong.MaxValue ^ ((ulong)uint4.MaxValue << offset);
               return (uint)(mask & src);
          }

          /// <summary>
          /// Disables a sequence of 4 source bits starting at a specified offset
          /// </summary>
          /// <param name="src">The bit source</param>
          /// <param name="offset">The offset at which to begin clearing bits</param>
          [MethodImpl(Inline), Disable]
          public static ulong disable(N4 n,ulong src, byte offset)
          {
               var mask = ulong.MaxValue ^ ((ulong)uint4.MaxValue << offset);
               return (ulong)(mask & src);
          }

     }
}