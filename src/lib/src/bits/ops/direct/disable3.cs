//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 3030
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
     partial class bits
     {
          /// <summary>
          /// Disables a sequence of 3 source bits starting at a specified offset
          /// </summary>
          /// <param name="src">The bit source</param>
          /// <param name="offset">The offset at which to begin clearing bits</param>
          [MethodImpl(Inline), Disable]
          public static byte disable3(byte src, byte offset)
          {
               var mask = ulong.MaxValue ^ ((ulong)LimitValues.Max3u << offset);
               return (byte)(mask & src);
          }

          /// <summary>
          /// Disables a sequence of 3 source bits starting at a specified offset
          /// </summary>
          /// <param name="src">The bit source</param>
          /// <param name="offset">The offset at which to begin clearing bits</param>
          [MethodImpl(Inline), Disable]
          public static ushort disable3(ushort src, byte offset)
          {
               var mask = ulong.MaxValue ^ ((ulong)LimitValues.Max3u << offset);
               return (ushort)(mask & src);
          }

          /// <summary>
          /// Disables a sequence of 3 source bits starting at a specified offset
          /// </summary>
          /// <param name="src">The bit source</param>
          /// <param name="offset">The offset at which to begin clearing bits</param>
          [MethodImpl(Inline), Disable]
          public static uint disable3(uint src, byte offset)
          {
               var mask = ulong.MaxValue ^ ((ulong)LimitValues.Max3u << offset);
               return (uint)(mask & src);
          }

          /// <summary>
          /// Disables a sequence of 3 source bits starting at a specified offset
          /// </summary>
          /// <param name="src">The bit source</param>
          /// <param name="offset">The offset at which to begin clearing bits</param>
          [MethodImpl(Inline), Disable]
          public static ulong disable3(ulong src, byte offset)
          {
               var mask = ulong.MaxValue ^ ((ulong)LimitValues.Max3u << offset);
               return (ulong)(mask & src);
          }

          /// <summary>
          /// Disables a sequence of 3 source bits starting at a specified offset
          /// </summary>
          /// <param name="src">The bit source</param>
          /// <param name="offset">The offset at which to begin clearing bits</param>
          [MethodImpl(Inline), Disable]
          public static byte disable(N3 n, byte src, byte offset)
          {
               var mask = ulong.MaxValue ^ ((ulong)LimitValues.Max3u << offset);
               return (byte)(mask & src);
          }

          /// <summary>
          /// Disables a sequence of 3 source bits starting at a specified offset
          /// </summary>
          /// <param name="src">The bit source</param>
          /// <param name="offset">The offset at which to begin clearing bits</param>
          [MethodImpl(Inline), Disable]
          public static ushort disable(N3 n, ushort src, byte offset)
          {
               var mask = ulong.MaxValue ^ ((ulong)LimitValues.Max3u << offset);
               return (ushort)(mask & src);
          }

          /// <summary>
          /// Disables a sequence of 3 source bits starting at a specified offset
          /// </summary>
          /// <param name="src">The bit source</param>
          /// <param name="offset">The offset at which to begin clearing bits</param>
          [MethodImpl(Inline), Disable]
          public static uint disable(N3 n, uint src, byte offset)
          {
               var mask = ulong.MaxValue ^ ((ulong)LimitValues.Max3u << offset);
               return (uint)(mask & src);
          }

          /// <summary>
          /// Disables a sequence of 3 source bits starting at a specified offset
          /// </summary>
          /// <param name="src">The bit source</param>
          /// <param name="offset">The offset at which to begin clearing bits</param>
          [MethodImpl(Inline), Disable]
          public static ulong disable(N3 n,ulong src, byte offset)
          {
               var mask = ulong.MaxValue ^ ((ulong)LimitValues.Max3u << offset);
               return (ulong)(mask & src);
          }
     }
}