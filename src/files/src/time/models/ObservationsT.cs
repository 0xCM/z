//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines an observation sequence
    /// </summary>
    public readonly ref struct Observations<T>
        where T : unmanaged
    {
        public readonly Span<T> Data;

        /// <summary>
        /// The number of observations that comprise the sample
        /// </summary>
        public readonly int Count;

        /// <summary>
        /// The sample dimensionality
        /// </summary>
        public readonly int Dim;

        [MethodImpl(Inline)]
        public Observations(Span<T> src, int dim)
        {
            Dim = dim;
            Count = Math.DivRem(src.Length, dim, out int remainder);
            Require.invariant(remainder == 0, () => "The invariant k := (remainder == 0) failed");
            Data = src;
        }

        [MethodImpl(Inline)]
        public Observations(T[] src, int dim)
        {
            Dim = dim;
            Count = Math.DivRem(src.Length, dim, out int remainder);
            Require.invariant(remainder == 0, () => "The invariant k := (remainder == 0) failed");
            Data = src;
        }

        public ref T this[int ix]
        {
            [MethodImpl(Inline)]
            get => ref Data[ix];
        }

        [MethodImpl(Inline)]
        public ref T Block(int vecix)
            => ref this[vecix*Dim];

        /// <summary>
        /// Retrieves a single index-identified observation vector
        /// </summary>
        /// <param name="vecix">The vector index</param>
        [MethodImpl(Inline)]
        public Observations<T> Observation(int vecix)
        {
            var slice = Data.Slice(vecix * Dim, Dim);
            return new Observations<T>(slice, Dim);
        }

        /// <summary>
        /// Selects a contiguous sequence of observations beginning at a specified offset
        /// </summary>
        /// <param name="offset">The offset</param>
        /// <param name="count">The observation count</param>
        [MethodImpl(Inline)]
        public Observations<T> Slice(int offset, int count)
            => new Observations<T>(sys.slice(Data, offset * Dim, count * Dim), Dim);

        /// <summary>
        /// The data length
        /// </summary>
        public int Length
        {
            [MethodImpl(Inline)]
            get => Data.Length;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsEmpty;
        }

        public string Format()
        {
            var fmt = new StringBuilder();
            for(var i=0; i<Count; i++)
            {
                var v = Observation(i);
                fmt.Append(Chars.Lt);
                for(var j = 0; j< Dim; j++)
                {
                    fmt.Append($"{v[j]}");
                    if(j != Dim - 1)
                        fmt.Append(", ");
                }
                fmt.Append(Chars.Gt);

                if(i != Count - 1)
                    fmt.AppendLine();
            }
            return fmt.ToString();
        }

        public override bool Equals(object rhs)
            => throw new NotSupportedException();

        public override int GetHashCode()
            => throw new NotSupportedException();

        [MethodImpl(Inline)]
        public static implicit operator Span<T>(Observations<T> src)
            => src.Data;

        [MethodImpl(Inline)]
        public static implicit operator ReadOnlySpan<T> (Observations<T> src)
            => src.Data;

        [MethodImpl(Inline)]
        public static bool operator == (Observations<T> lhs, Observations<T> rhs)
            => lhs.Data == rhs.Data;

        [MethodImpl(Inline)]
        public static bool operator != (Observations<T> lhs, Observations<T> rhs)
            => lhs.Data != rhs.Data;

    }
}