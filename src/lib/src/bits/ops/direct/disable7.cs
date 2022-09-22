//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
     partial class bits
     {
          /// <summary>
          /// Disables a sequence of 7 source bits starting at a specified offset
          /// </summary>
          /// <param name="src">The bit source</param>
          /// <param name="offset">The offset at which to begin clearing bits</param>
          [MethodImpl(Inline), Disable]
          public static byte disable7(byte src, byte offset)
          {
               var mask = ulong.MaxValue ^ ((ulong)LimitValues.Max7u << offset);
               return (byte)(mask & src);
          }

          /// <summary>
          /// Disables a sequence of 7 source bits starting at a specified offset
          /// </summary>
          /// <param name="src">The bit source</param>
          /// <param name="offset">The offset at which to begin clearing bits</param>
          [MethodImpl(Inline), Disable]
          public static ushort disable7(ushort src, byte offset)
          {
               var mask = ulong.MaxValue ^ ((ulong)LimitValues.Max7u << offset);
               return (ushort)(mask & src);
          }

          /// <summary>
          /// Disables a sequence of 7 source bits starting at a specified offset
          /// </summary>
          /// <param name="src">The bit source</param>
          /// <param name="offset">The offset at which to begin clearing bits</param>
          [MethodImpl(Inline), Disable]
          public static uint disable7(uint src, byte offset)
          {
               var mask = ulong.MaxValue ^ ((ulong)LimitValues.Max7u << offset);
               return (uint)(mask & src);
          }

          /// <summary>
          /// Disables a sequence of 7 source bits starting at a specified offset
          /// </summary>
          /// <param name="src">The bit source</param>
          /// <param name="offset">The offset at which to begin clearing bits</param>
          [MethodImpl(Inline), Disable]
          public static ulong disable7(ulong src, byte offset)
          {
               var mask = ulong.MaxValue ^ ((ulong)LimitValues.Max7u << offset);
               return (ulong)(mask & src);
          }

          /// <summary>
          /// Disables a sequence of 7 source bits starting at a specified offset
          /// </summary>
          /// <param name="src">The bit source</param>
          /// <param name="offset">The offset at which to begin clearing bits</param>
          [MethodImpl(Inline), Disable]
          public static byte disable(N7 n, byte src, byte offset)
          {
               var mask = ulong.MaxValue ^ ((ulong)LimitValues.Max7u << offset);
               return (byte)(mask & src);
          }

          /// <summary>
          /// Disables a sequence of 7 source bits starting at a specified offset
          /// </summary>
          /// <param name="src">The bit source</param>
          /// <param name="offset">The offset at which to begin clearing bits</param>
          [MethodImpl(Inline), Disable]
          public static ushort disable(N7 n, ushort src, byte offset)
          {
               var mask = ulong.MaxValue ^ ((ulong)LimitValues.Max7u << offset);
               return (ushort)(mask & src);
          }

          /// <summary>
          /// Disables a sequence of 7 source bits starting at a specified offset
          /// </summary>
          /// <param name="src">The bit source</param>
          /// <param name="offset">The offset at which to begin clearing bits</param>
          [MethodImpl(Inline), Disable]
          public static uint disable(N7 n, uint src, byte offset)
          {
               var mask = ulong.MaxValue ^ ((ulong)LimitValues.Max7u << offset);
               return (uint)(mask & src);
          }

          /// <summary>
          /// Disables a sequence of 7 source bits starting at a specified offset
          /// </summary>
          /// <param name="src">The bit source</param>
          /// <param name="offset">The offset at which to begin clearing bits</param>
          [MethodImpl(Inline), Disable]
          public static ulong disable(N7 n,ulong src, byte offset)
          {
               var mask = ulong.MaxValue ^ ((ulong)LimitValues.Max7u << offset);
               return (ulong)(mask & src);
          }
     }
}