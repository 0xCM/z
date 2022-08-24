//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        public static T[] Resequence<T>(this T[] src)
            where T : ISequential<T>
                => sys.resequence(src);

        public static Index<T> Resequence<T>(this Index<T> src)
            where T : ISequential<T>
                => sys.resequence(src);

        public static Span<T> Resequence<T>(this Span<T> src)
            where T : ISequential<T>
                => sys.resequence(src);

        public static Seq<T> Resequence<T>(this Seq<T> src)
            where T : ISequential<T>
                => sys.resequence(src);
    }
}