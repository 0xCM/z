//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Captures a heterogenous pair sequence
    /// </summary>
    /// <typeparam name="T">The sequence element type</typeparam>
    public readonly struct Pairings<S,T> : IIndex<Paired<S,T>>
    {
        /// <summary>
        /// The captured sequence
        /// </summary>
        readonly Index<Paired<S,T>> Data;

        [MethodImpl(Inline)]
        public Pairings(Paired<S,T>[] data)
            => Data = data;

        public Paired<S,T>[] Storage
        {
            [MethodImpl(Inline)]
            get => Data.Storage;
        }

        /// <summary>
        /// Returns a mutable reference to an index-identified sequence element
        /// </summary>
        /// <param name="index">The zero-based sequence index</param>
        public ref Paired<S,T> this[int index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        /// <summary>
        /// Returns a mutable reference to an index-identified sequence element
        /// </summary>
        /// <param name="index">The zero-based sequence index</param>
        public ref Paired<S,T> this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        /// <summary>
        /// Specifies the number of elements in the sequence
        /// </summary>
        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        [MethodImpl(Inline)]
        public static implicit operator Pairings<S,T>(Paired<S,T>[] src)
            => new Pairings<S,T>(src);

        [MethodImpl(Inline)]
        public static implicit operator Paired<S,T>[](Pairings<S,T> src)
            => src.Storage;

        public static Pairings<S,T> Empty => new Pairings<S,T>(sys.empty<Paired<S,T>>());
    }
}