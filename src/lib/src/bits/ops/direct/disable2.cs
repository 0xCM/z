//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
     partial class bits
     {
          /// <summary>
          /// Disables a sequence of 2 source bits starting at a specified offset
          /// </summary>
          /// <param name="src">The bit source</param>
          /// <param name="offset">The offset at which to begin clearing bits</param>
          [MethodImpl(Inline), Disable]
          public static byte disable2(byte src, byte offset)
          {
               var mask = ulong.MaxValue ^ ((ulong)LimitValues.Max2u << offset);
               return (byte)(mask & src);
          }

          /// <summary>
          /// Disables a sequence of 2 source bits starting at a specified offset
          /// </summary>
          /// <param name="src">The bit source</param>
          /// <param name="offset">The offset at which to begin clearing bits</param>
          [MethodImpl(Inline), Disable]
          public static ushort disable2(ushort src, byte offset)
          {
               var mask = ulong.MaxValue ^ ((ulong)LimitValues.Max2u << offset);
               return (ushort)(mask & src);
          }

          /// <summary>
          /// Disables a sequence of 2 source bits starting at a specified offset
          /// </summary>
          /// <param name="src">The bit source</param>
          /// <param name="offset">The offset at which to begin clearing bits</param>
          [MethodImpl(Inline), Disable]
          public static uint disable2(uint src, byte offset)
          {
               var mask = ulong.MaxValue ^ ((ulong)LimitValues.Max2u << offset);
               return (uint)(mask & src);
          }

          /// <summary>
          /// Disables a sequence of 2 source bits starting at a specified offset
          /// </summary>
          /// <param name="src">The bit source</param>
          /// <param name="offset">The offset at which to begin clearing bits</param>
          [MethodImpl(Inline), Disable]
          public static ulong disable2(ulong src, byte offset)
          {
               var mask = ulong.MaxValue ^ ((ulong)LimitValues.Max2u << offset);
               return (ulong)(mask & src);
          }

          /// <summary>
          /// Disables a sequence of 2 source bits starting at a specified offset
          /// </summary>
          /// <param name="src">The bit source</param>
          /// <param name="offset">The offset at which to begin clearing bits</param>
          [MethodImpl(Inline), Disable]
          public static byte disable(N2 n, byte src, byte offset)
          {
               var mask = ulong.MaxValue ^ ((ulong)LimitValues.Max2u << offset);
               return (byte)(mask & src);
          }

          /// <summary>
          /// Disables a sequence of 2 source bits starting at a specified offset
          /// </summary>
          /// <param name="src">The bit source</param>
          /// <param name="offset">The offset at which to begin clearing bits</param>
          [MethodImpl(Inline), Disable]
          public static ushort disable(N2 n, ushort src, byte offset)
          {
               var mask = ulong.MaxValue ^ ((ulong)LimitValues.Max2u << offset);
               return (ushort)(mask & src);
          }

          /// <summary>
          /// Disables a sequence of 2 source bits starting at a specified offset
          /// </summary>
          /// <param name="src">The bit source</param>
          /// <param name="offset">The offset at which to begin clearing bits</param>
          [MethodImpl(Inline), Disable]
          public static uint disable(N2 n, uint src, byte offset)
          {
               var mask = ulong.MaxValue ^ ((ulong)LimitValues.Max2u << offset);
               return (uint)(mask & src);
          }

          /// <summary>
          /// Disables a sequence of 2 source bits starting at a specified offset
          /// </summary>
          /// <param name="src">The bit source</param>
          /// <param name="offset">The offset at which to begin clearing bits</param>
          [MethodImpl(Inline), Disable]
          public static ulong disable(N2 n,ulong src, byte offset)
          {
               var mask = ulong.MaxValue ^ ((ulong)LimitValues.Max2u << offset);
               return (ulong)(mask & src);
          }
     }
}