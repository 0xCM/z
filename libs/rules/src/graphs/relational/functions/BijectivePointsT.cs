//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Represents a bijective correspondence between two sequences of homogenous type
    /// </summary>
    public readonly struct BijectivePoints<T>
    {
        /// <summary>
        /// Defines a bijective correspondence between members of source/target sequences of common length over a common domain
        /// </summary>
        /// <param name="src">The source sequence</param>
        /// <param name="dst">The target sequence</param>
        /// <typeparam name="T">The domain type</typeparam>
        [MethodImpl(Inline)]
        public static BijectivePoints<T> bijection(Index<T> src, Index<T> dst)
        {
            if(src.Length != dst.Length)
                Errors.ThrowWithOrigin(string.Format("{0} != {1}", src.Length, dst.Length));
            return new BijectivePoints<T>(src, dst);
        }

        public readonly Index<T> Source;

        public readonly Index<T> Target;

        [MethodImpl(Inline)]
        public BijectivePoints(Index<T> src, Index<T> dst)
        {
            Source = src;
            Target = dst;
        }

        public Pair<T> this[uint i]
        {
            [MethodImpl(Inline)]
            get => (Source[i], Target[i]);
        }
    }
}