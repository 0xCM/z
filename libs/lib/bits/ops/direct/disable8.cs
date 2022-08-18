//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
     partial class bits
     {
          /// <summary>
          /// Disables a sequence of 8 source bits starting at a specified offset
          /// </summary>
          /// <param name="src">The bit source</param>
          /// <param name="offset">The offset at which to begin clearing bits</param>
          [MethodImpl(Inline), Disable]
          public static ushort disable8(ushort src, byte offset)
          {
               var mask = uint.MaxValue ^ ((uint)byte.MaxValue << offset);
               return (ushort)(mask & src);
          }

          /// <summary>
          /// Disables a sequence of 8 source bits starting at a specified offset
          /// </summary>
          /// <param name="src">The bit source</param>
          /// <param name="offset">The offset at which to begin clearing bits</param>
          [MethodImpl(Inline), Disable]
          public static uint disable8(uint src, byte offset)
          {
               var mask = uint.MaxValue ^ ((uint)byte.MaxValue << offset);
               return mask & src;
          }

          /// <summary>
          /// Disables a sequence of 8 source bits starting at a specified offset
          /// </summary>
          /// <param name="src">The bit source</param>
          /// <param name="offset">The offset at which to begin clearing bits</param>
          [MethodImpl(Inline), Disable]
          public static ulong disable8(ulong src, byte offset)
          {
               var mask = ulong.MaxValue ^ ((ulong)byte.MaxValue << offset);
               return mask & src;
          }

          /// <summary>
          /// Disables a sequence of 8 source bits starting at a specified offset
          /// </summary>
          /// <param name="src">The bit source</param>
          /// <param name="offset">The offset at which to begin clearing bits</param>
          [MethodImpl(Inline), Disable]
          public static ushort disable(N8 n, ushort src, byte offset)
          {
               var mask = ulong.MaxValue ^ ((ulong)uint8b.MaxValue << offset);
               return (ushort)(mask & src);
          }

          /// <summary>
          /// Disables a sequence of 8 source bits starting at a specified offset
          /// </summary>
          /// <param name="src">The bit source</param>
          /// <param name="offset">The offset at which to begin clearing bits</param>
          [MethodImpl(Inline), Disable]
          public static uint disable(N8 n, uint src, byte offset)
          {
               var mask = ulong.MaxValue ^ ((ulong)uint8b.MaxValue << offset);
               return (uint)(mask & src);
          }

          /// <summary>
          /// Disables a sequence of 8 source bits starting at a specified offset
          /// </summary>
          /// <param name="src">The bit source</param>
          /// <param name="offset">The offset at which to begin clearing bits</param>
          [MethodImpl(Inline), Disable]
          public static ulong disable(N8 n,ulong src, byte offset)
          {
               var mask = ulong.MaxValue ^ ((ulong)uint8b.MaxValue << offset);
               return (ulong)(mask & src);
          }
     }
}