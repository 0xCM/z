//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
     partial class bits
     {
          /// <summary>
          /// Disables a sequence of 5 source bits starting at a specified offset
          /// </summary>
          /// <param name="src">The bit source</param>
          /// <param name="offset">The offset at which to begin clearing bits</param>
          [MethodImpl(Inline), Disable]
          public static byte disable5(byte src, byte offset)
          {
               var mask = ulong.MaxValue ^ ((ulong)LimitValues.Max5u << offset);
               return (byte)(mask & src);
          }

          /// <summary>
          /// Disables a sequence of 5 source bits starting at a specified offset
          /// </summary>
          /// <param name="src">The bit source</param>
          /// <param name="offset">The offset at which to begin clearing bits</param>
          [MethodImpl(Inline), Disable]
          public static ushort disable5(ushort src, byte offset)
          {
               var mask = ulong.MaxValue ^ ((ulong)LimitValues.Max5u << offset);
               return (ushort)(mask & src);
          }

          /// <summary>
          /// Disables a sequence of 5 source bits starting at a specified offset
          /// </summary>
          /// <param name="src">The bit source</param>
          /// <param name="offset">The offset at which to begin clearing bits</param>
          [MethodImpl(Inline), Disable]
          public static uint disable5(uint src, byte offset)
          {
               var mask = ulong.MaxValue ^ ((ulong)LimitValues.Max5u << offset);
               return (uint)(mask & src);
          }

          /// <summary>
          /// Disables a sequence of 5 source bits starting at a specified offset
          /// </summary>
          /// <param name="src">The bit source</param>
          /// <param name="offset">The offset at which to begin clearing bits</param>
          [MethodImpl(Inline), Disable]
          public static ulong disable5(ulong src, byte offset)
          {
               var mask = ulong.MaxValue ^ ((ulong)LimitValues.Max5u << offset);
               return (ulong)(mask & src);
          }

          /// <summary>
          /// Disables a sequence of 5 source bits starting at a specified offset
          /// </summary>
          /// <param name="src">The bit source</param>
          /// <param name="offset">The offset at which to begin clearing bits</param>
          [MethodImpl(Inline), Disable]
          public static byte disable(N5 n, byte src, byte offset)
          {
               var mask = ulong.MaxValue ^ ((ulong)LimitValues.Max5u << offset);
               return (byte)(mask & src);
          }

          /// <summary>
          /// Disables a sequence of 5 source bits starting at a specified offset
          /// </summary>
          /// <param name="src">The bit source</param>
          /// <param name="offset">The offset at which to begin clearing bits</param>
          [MethodImpl(Inline), Disable]
          public static ushort disable(N5 n, ushort src, byte offset)
          {
               var mask = ulong.MaxValue ^ ((ulong)LimitValues.Max5u << offset);
               return (ushort)(mask & src);
          }

          /// <summary>
          /// Disables a sequence of 5 source bits starting at a specified offset
          /// </summary>
          /// <param name="src">The bit source</param>
          /// <param name="offset">The offset at which to begin clearing bits</param>
          [MethodImpl(Inline), Disable]
          public static uint disable(N5 n, uint src, byte offset)
          {
               var mask = ulong.MaxValue ^ ((ulong)LimitValues.Max5u << offset);
               return (uint)(mask & src);
          }

          /// <summary>
          /// Disables a sequence of 5 source bits starting at a specified offset
          /// </summary>
          /// <param name="src">The bit source</param>
          /// <param name="offset">The offset at which to begin clearing bits</param>
          [MethodImpl(Inline), Disable]
          public static ulong disable(N5 n,ulong src, byte offset)
          {
               var mask = ulong.MaxValue ^ ((ulong)LimitValues.Max5u << offset);
               return (ulong)(mask & src);
          }
     }
}