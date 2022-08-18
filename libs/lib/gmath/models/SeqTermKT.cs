//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a sequence term
    /// </summary>
    public readonly struct SeqTerm<K,T>
        where K : unmanaged
    {
        /// <summary>
        /// The sequence index
        /// </summary>
        public K Index {get;}

        /// <summary>
        /// The term value
        /// </summary>
        public T Value {get;}

        [MethodImpl(Inline)]
        public SeqTerm(K index, T value)
        {
            Index = index;
            Value = value;
        }

        public string Format()
            => string.Format("{0}: {1}", Index, Value);

        public override string ToString()
            => Format();

        /// <summary>
        /// Specifies whether the term is empty
        /// </summary>
        public bool IsEmpty
            => Value == null ||  (Index.Equals(default) && Value.Equals(default));

        public static SeqTerm<K,T> Empty => default;

        [MethodImpl(Inline)]
        public static implicit operator (K i, T t)(SeqTerm<K,T> src)
            => (src.Index, src.Value);

        [MethodImpl(Inline)]
        public static implicit operator T(SeqTerm<K,T> src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator SeqTerm<K,T>((K i, T t) src)
            => new SeqTerm<K,T>(src.i, src.t);
    }
}