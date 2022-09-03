//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    /// <summary>
    /// Encodes a finite, ordered sequence of symbols over some alphabet A
    /// In the literature, a 'word' in this context is often referred to as a
    /// 'string' - the usage of which is avoided here, for obvious reasons.
    /// </summary>
    public readonly struct Word<S>
        where S : unmanaged, IEquatable<S>
    {
        /// <summary>
        /// The symbols that comprise the word
        /// </summary>
        public Index<SymVal<S>> Symbols {get;}

        [MethodImpl(Inline)]
        public Word(params Word<S>[] src)
        {
            var len = src.Sum(s => s.Length);
            Symbols = new SymVal<S>[len];
            var symidx = 0;
            for(var i=0; i< src.Length; i++)
            {
                var word = src[i];
                for(var j = 0; j< word.Length; j++)
                    Symbols[symidx++] = word.Symbols[j];
            }
        }

        [MethodImpl(Inline)]
        public Word(params SymVal<S>[] src)
        {
            if(src.Length == 1 && src[0].Value.Equals(SymVal<S>.Empty))
                Symbols = new SymVal<S>[]{};
            else
                Symbols = src;
        }

        /// <summary>
        /// The empty word containing no symbols
        /// </summary>
        public Word<S> Zero
            => Empty;

        /// <summary>
        /// Specifies the number of symbols that comprise the word
        /// </summary>
        public int Length
            => Symbols.Length;

        public SymVal<S> this[int index]
        {
            [MethodImpl(Inline)]
            get => Symbols[index];
        }

        public bool IsEmpty
            => Symbols.Length == 0;

        public ReadOnlySpan<char> Content
            => string.Join(string.Empty, Symbols);

        /// <summary>
        /// Formats the word as a string
        /// </summary>
        public string Format()
            => string.Join(string.Empty, Symbols);

        [MethodImpl(Inline)]
        public bool Equals(Word<S> rhs)
        {
            if(Length != rhs.Length)
                return false;

            for(var i=0; i< rhs.Symbols.Length; i++)
                if(!Symbols[i].Equals(rhs.Symbols[i]))
                    return false;
            return true;
        }

        public override int GetHashCode()
            => Format().GetHashCode();

        public override string ToString()
            => Format();

        public override bool Equals(Object rhs)
            => rhs is Word<S> ? Equals((Word<S>)rhs) : false;

        /// <summary>
        /// Concatenates this word w1 with another word w2 to form a new word w1w2
        /// </summary>
        /// <param name="w2">The word to concatenate with the current word</param>
        public Word<S> Concat(Word<S> w2)
            => new Word<S>(this,w2);

        /// <summary>
        /// Determines whether two words are equivalent
        /// </summary>
        /// <param name="lhs">The first word</param>
        /// <param name="rhs">The second word</param>
        public static bool operator == (Word<S> lhs, Word<S> rhs)
            => lhs.Symbols.View.SequenceEqual(rhs.Symbols.View);

        /// <summary>
        /// Determines whether two words are unequal
        /// </summary>
        /// <param name="lhs">The first word</param>
        /// <param name="rhs">The second word</param>
        public static bool operator != (Word<S> lhs, Word<S> rhs)
            => lhs != rhs;

        /// <summary>
        /// Converts the word to a string via a canonical format
        /// </summary>
        /// <param name="src">The source word</param>
        public static implicit operator string(Word<S> src)
            => src.Format();

        /// <summary>
        /// Encloses an array of symbols by a word
        /// </summary>
        /// <param name="src">The source symbols</param>
        /// <typeparam name="A">The alphabet</typeparam>
        public static implicit operator Word<S>(SymVal<S>[] src)
            => new Word<S>(src);

        /// <summary>
        /// Converts a word to its equivalent symbolic representation
        /// </summary>
        /// <param name="src">The source word</param>
        public static implicit operator SymVal<S>[](Word<S> src)
            => src.Symbols;

        /// <summary>
        /// Concatenates a word w1 with a word w2 to form a word w' = w1w2
        /// </summary>
        /// <param name="w1">The first word</param>
        /// <param name="w2">The second word</param>
        public static Word<S> operator +(Word<S> w1, Word<S> w2)
            => new Word<S>(w1,w2);

        /// <summary>
        /// Represents the empty word, with an invariant length of 0
        /// </summary>
        /// <typeparam name="A">The alphabet type</typeparam>
        public static Word<S> Empty => new Word<S>(SymVal<S>.Empty);
    }
}