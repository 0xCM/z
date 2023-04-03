//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
   using System;
   using System.Runtime.CompilerServices;

   using static Root;

    partial class XBitSpans
    {
         [MethodImpl(Inline), Op]
         public static BitSpan32 ToBitSpan32(this byte src)
            => BitSpans32.from<byte>(src);

         [MethodImpl(Inline), Op]
         public static BitSpan32 ToBitSpan32(this uint src)
            => BitSpans32.from<uint>(src);

         [MethodImpl(Inline), Op]
         public static BitSpan32 ToBitSpan32(this ulong src)
            => BitSpans32.from<ulong>(src);

        /// <summary>
        /// Loads a bitspan from a packed span of scalars
        /// </summary>
        /// <param name="src">The packed source</param>
        [MethodImpl(Inline), Op]
        public static BitSpan32 ToBitSpan32(this Span<byte> src)
            => BitSpans32.load(src);
   }
}