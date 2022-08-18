//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitSpans32
    {
        /// <summary>
        /// Obliterates all bitspan content
        /// </summary>
        /// <param name="src">The source bits</param>
        [MethodImpl(Inline), Op]
        public static ref readonly BitSpan32 clear(in BitSpan32 src)
        {
            src.Data.Clear();
            return ref src;
        }

        /// <summary>
        /// Obliterates bitspan content higher than a specified maximum
        /// </summary>
        /// <param name="src">The source bits</param>
        [MethodImpl(Inline), Op]
        public ref readonly BitSpan32 clear(in BitSpan32 src, int maxbits)
        {
            if(src.Length <= maxbits)
                return ref src;

            src.Edit.Slice(maxbits).Clear();

            return ref src;
        }

        /// <summary>
        /// Clears a contiguous sequence of bits between two indices
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <param name="i0">The index of the first bit to clear</param>
        /// <param name="i1">The index of the last bit to clear</param>
        [MethodImpl(Inline), Op]
        public static ref readonly BitSpan32 clear(in BitSpan32 src, int i0, int i1)
        {
            src.Data.Slice(i0, i0 - i1 + 1).Clear();
            return ref src;
        }
    }
}