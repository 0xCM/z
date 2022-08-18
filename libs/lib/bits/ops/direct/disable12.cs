//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
     partial class bits
     {
          /// <summary>
          /// Disables a sequence of 12 source bits starting at a specified offset
          /// </summary>
          /// <param name="src">The bit source</param>
          /// <param name="offset">The offset at which to begin clearing bits</param>
          [MethodImpl(Inline), Disable]
          public static byte disable12(byte src, byte offset)
          {
               var mask = ulong.MaxValue ^ ((ulong)Hex12.MaxValue << offset);
               return (byte)(mask & src);
          }

          /// <summary>
          /// Disables a sequence of 12 source bits starting at a specified offset
          /// </summary>
          /// <param name="src">The bit source</param>
          /// <param name="offset">The offset at which to begin clearing bits</param>
          [MethodImpl(Inline), Disable]
          public static ushort disable12(ushort src, byte offset)
          {
               var mask = ulong.MaxValue ^ ((ulong)Hex12.MaxValue << offset);
               return (ushort)(mask & src);
          }

          /// <summary>
          /// Disables a sequence of 12 source bits starting at a specified offset
          /// </summary>
          /// <param name="src">The bit source</param>
          /// <param name="offset">The offset at which to begin clearing bits</param>
          [MethodImpl(Inline), Disable]
          public static uint disable12(uint src, byte offset)
          {
               var mask = ulong.MaxValue ^ ((ulong)Hex12.MaxValue << offset);
               return (uint)(mask & src);
          }

          /// <summary>
          /// Disables a sequence of 12 source bits starting at a specified offset
          /// </summary>
          /// <param name="src">The bit source</param>
          /// <param name="offset">The offset at which to begin clearing bits</param>
          [MethodImpl(Inline), Disable]
          public static ulong disable12(ulong src, byte offset)
          {
               var mask = ulong.MaxValue ^ ((ulong)Hex12.MaxValue << offset);
               return (ulong)(mask & src);
          }

          /// <summary>
          /// Disables a sequence of 12 source bits starting at a specified offset
          /// </summary>
          /// <param name="src">The bit source</param>
          /// <param name="offset">The offset at which to begin clearing bits</param>
          [MethodImpl(Inline), Disable]
          public static byte disable(N12 n, byte src, byte offset)
          {
               var mask = ulong.MaxValue ^ ((ulong)Hex12.MaxValue << offset);
               return (byte)(mask & src);
          }

          /// <summary>
          /// Disables a sequence of 12 source bits starting at a specified offset
          /// </summary>
          /// <param name="src">The bit source</param>
          /// <param name="offset">The offset at which to begin clearing bits</param>
          [MethodImpl(Inline), Disable]
          public static ushort disable(N12 n, ushort src, byte offset)
          {
               var mask = ulong.MaxValue ^ ((ulong)Hex12.MaxValue << offset);
               return (ushort)(mask & src);
          }

          /// <summary>
          /// Disables a sequence of 12 source bits starting at a specified offset
          /// </summary>
          /// <param name="src">The bit source</param>
          /// <param name="offset">The offset at which to begin clearing bits</param>
          [MethodImpl(Inline), Disable]
          public static uint disable(N12 n, uint src, byte offset)
          {
               var mask = ulong.MaxValue ^ ((ulong)Hex12.MaxValue << offset);
               return (uint)(mask & src);
          }

          /// <summary>
          /// Disables a sequence of 12 source bits starting at a specified offset
          /// </summary>
          /// <param name="src">The bit source</param>
          /// <param name="offset">The offset at which to begin clearing bits</param>
          [MethodImpl(Inline), Disable]
          public static ulong disable(N12 n,ulong src, byte offset)
          {
               var mask = ulong.MaxValue ^ ((ulong)Hex12.MaxValue << offset);
               return (ulong)(mask & src);
          }
     }
}