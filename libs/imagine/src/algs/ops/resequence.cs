//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Algs
    {
        [MethodImpl(Inline)]
        public static Index<T> resequence<T>(Index<T> src)
            where T : ISequential<T>
        {
            for(var i=0u; i<src.Length; i++)
                src[i].Seq = i;
            return src;
        }

        [MethodImpl(Inline)]
        public static Seq<T> resequence<T>(Seq<T> src)
            where T : ISequential<T>
        {
            for(var i=0u; i<src.Count; i++)
                src[i].Seq = i;
            return src;
        }

        [MethodImpl(Inline)]
        public static T[] resequence<T>(T[] src)
            where T : ISequential<T>
        {
            for(var i=0u; i<src.Length; i++)
                Arrays.seek(src,i).Seq = i;
            return src;
        }

        [MethodImpl(Inline)]
        public static Span<T> resequence<T>(Span<T> src)
            where T : ISequential<T>
        {
            for(var i=0u; i<src.Length; i++)
                Spans.seek(src,i).Seq = i;
            return src;
        }
    }
}