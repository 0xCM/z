//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct vblocks
    {
        /// <summary>
        /// Returns the index of the block, if any that contains a cell that is equal to a specified match value
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="match">The value to match</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static int cellmatch(SpanBlock128<byte> src, byte match)
        {
            var ones = vgcpu.vones<byte>(w128);
            for(var i=0; i<src.BlockCount; i++)
            {
                var a = vload(src,i);
                var b = vcpu.vbroadcast(w128, match);
                var c = vcpu.veq(a,b);
                var d = vcpu.vtestz(c,ones);
                if(!d)
                    return i;
            }

            return NotFound;
        }

        /// <summary>
        /// Returns the inded of the block, if any that contains a cell that is equal to a specified match value
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="match">The value to match</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static int cellmatch<T>(SpanBlock128<T> src, T match)
            where T : unmanaged
        {
            var w = w128;
            var ones = vgcpu.vones<T>(w);
            for(var i=0; i<src.BlockCount; i++)
            {
                var a = SpanBlocks.vload(src,i);
                var b = vgcpu.vbroadcast(w, match);
                var c = vgcpu.veq(a,b);
                var d = vgcpu.vtestz(c, ones);
                if(!d)
                    return i;
            }

            return NotFound;
        }

        /// <summary>
        /// Returns the inded of the block, if any that contains a cell that is equal to a specified match value
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="match">The value to match</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static int cellmatch<T>(SpanBlock256<T> src, T match)
            where T : unmanaged
        {
            var w = w256;
            var ones = vgcpu.vones<T>(w);
            for(var i=0; i<src.BlockCount; i++)
            {
                var a = SpanBlocks.vload(src,i);
                var b = vgcpu.vbroadcast(w, match);
                var c = vgcpu.veq(a,b);
                var d = vgcpu.vtestz(c, ones);
                if(!d)
                    return i;
            }

            return NotFound;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void cellmatch<T>(SpanBlock128<T> src, T match, out BlockSearch128<T> result)
            where T : unmanaged
        {
            result.Searched = src;
            result.Target = match;
            result.MatchingBlock = cellmatch(src,match);
            result.Found = result.MatchingBlock != NotFound;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void cellmatch<T>(SpanBlock256<T> src, T match, out BlockSearch256<T> result)
            where T : unmanaged
        {
            result.Searched = src;
            result.Target = match;
            result.MatchingBlock = cellmatch(src,match);
            result.Found = result.MatchingBlock != NotFound;
        }

        public ref struct BlockSearch128<T>
            where T : unmanaged
        {
            public SpanBlock128<T> Searched;

            public T Target;

            public bit Found;

            public int MatchingBlock;
        }

       public ref struct BlockSearch256<T>
            where T : unmanaged
        {
            public SpanBlock256<T> Searched;

            public T Target;

            public bit Found;

            public int MatchingBlock;
        }
    }
}