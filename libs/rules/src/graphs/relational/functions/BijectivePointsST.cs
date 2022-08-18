//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Represents a bijective correspondence between two sequences
    /// </summary>
    public class BijectivePoints<S,T>
    {
        [MethodImpl(Inline)]
        public static BijectivePoints<S,T> bijection(Index<S> src, Index<T> dst)
        {
            if(src.Length != dst.Length)
                Errors.ThrowWithOrigin(string.Format("{0} != {1}", src.Length, dst.Length));
            return new BijectivePoints<S,T>(src, dst);
        }

        public readonly Index<S> Source;

        public readonly Index<T> Target;

        [MethodImpl(Inline)]
        public BijectivePoints(Index<S> src, Index<T> dst)
        {
            Source = src;
            Target = dst;
        }

        public Paired<S,T> this[uint i]
        {
            [MethodImpl(Inline)]
            get => (Source[i], Target[i]);
        }
    }
}