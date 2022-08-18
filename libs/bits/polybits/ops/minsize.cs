//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class PolyBits
    {
        [MethodImpl(Inline), Op]
        public static DataSize minsize<K>(ReadOnlySpan<BfSegModel<K>> src)
            where K : unmanaged
        {
            var count = src.Length;
            var packed = 0u;
            for(var i=0; i<count; i++)
                packed += skip(src,i).Width;
            return new (packed, Sized.align(packed,1));
        }

        [MethodImpl(Inline), Op]
        public static DataSize minsize<T>(in BfModel<T> src)
            where T : unmanaged
        {
            var packed = 0u;
            var count = src.SegCount;
            var segments = src.Segments;
            for(byte i=0; i<count; i++)
                packed += skip(segments, i).Width;
            return new (packed, Sized.align(packed,1));
        }

        /// <summary>
        /// Computes the aggregate width of the segments that comprise the bitfield
        /// </summary>
        /// <param name="src">The bitfield spec</param>
        [MethodImpl(Inline), Op]
        public static DataSize minsize(in BfModel src)
            => minsize(src.Segments);

        [MethodImpl(Inline), Op]
        public static DataSize minsize(ReadOnlySpan<BfSegModel> src)
        {
            var count = src.Length;
            var packed = 0u;
            for(var i=0; i<count; i++)
                packed += skip(src,i).Width;
            return new (packed, Sized.align(packed,1));
        }
    }
}