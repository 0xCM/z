//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct SeqTerm<T>
    {
        /// <summary>
        /// The integer that maps to the term value
        /// </summary>
        public uint Index {get;}

        /// <summary>
        /// The term's value
        /// </summary>
        public T Value {get;}

        [MethodImpl(Inline)]
        public SeqTerm(uint index, T value)
        {
            Index = index;
            Value = value;
        }

        public string Format()
            => string.Format("({0},{1})", Index, Value);

        public override string ToString()
            => Format();

        /// <summary>
        /// Specifies whether the term is empty
        /// </summary>
        public bool IsEmpty
            => Value == null ||  (Index == 0 && Value.Equals(default));

        public static SeqTerm<T> Empty => default;

        [MethodImpl(Inline)]
        public static implicit operator (uint i, T t)(SeqTerm<T> src)
            => (src.Index, src.Value);

        [MethodImpl(Inline)]
        public static implicit operator T(SeqTerm<T> src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator SeqTerm<T>((uint i, T t) src)
            => new SeqTerm<T>(src.i, src.t);
    }
}