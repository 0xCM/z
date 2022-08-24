//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public readonly ref struct Block256<N,T>
        where N : unmanaged, ITypeNat
        where T : unmanaged
    {
        public readonly SpanBlock256<T> Data;

        [MethodImpl(Inline)]
        public static Block256<N,T> Load(Span<T> src)
            => new Block256<N,T>(src);

        [MethodImpl(Inline)]
        public static Block256<N,T> Load(SpanBlock256<T> src)
            => new Block256<N,T>(src);

        /// <summary>
        /// Specifies the length of the vector, i.e. its component count
        /// </summary>
        public static int Length => (int)nat64u<N>();

        [MethodImpl(Inline)]
        Block256(Span<T> src)
        {
            Data = SpanBlocks.safeload(n256, src);
        }

        [MethodImpl(Inline)]
        Block256(SpanBlock256<T> src)
        {
            Require.invariant(src.CellCount >= Length, () => "no");
            Data = src;
        }

        [MethodImpl(Inline)]
        Block256(NatSpan<N,T> src)
        {
            Data = RowVectors.safeload(n256,src);
        }

        public ref T this[int index]
            => ref Data[index];

        public Span<T> Unsized
        {
            [MethodImpl(Inline)]
            get => Data.Storage;
        }

        [MethodImpl(Inline)]
        public Block256<N,U> As<U>()
            where U : unmanaged
                => new Block256<N,U>(MemoryMarshal.Cast<T,U>(Unsized));

        public bool Equals(Block256<N,T> rhs)
        {
            var lhsData = Unsized;
            var rhsData = rhs.Unsized;
            for(var i = 0; i<lhsData.Length; i++)
                if(gmath.neq(lhsData[i], rhsData[i]))
                    return false;
            return true;
        }

        [MethodImpl(Inline)]
        public ref Block256<N,T> CopyTo(ref Block256<N,T> dst)
        {
            Unsized.CopyTo(dst.Unsized);
            return ref dst;
        }

        /// <summary>
        /// Projects the source vector onto a target vector of the same length
        /// via a supplied transformation
        /// </summary>
        /// <param name="f">The transformation function</param>
        /// <typeparam name="U">The target vector element type</typeparam>
        [MethodImpl(Inline)]
        public Block256<N,U> Map<U>(Func<T,U> f)
            where U:unmanaged
        {
            var dst = RowVectors.blockalloc<N,U>();
            return Map(f, ref dst);
        }

        /// <summary>
        /// Projects the source vector onto a caller-supplied target vector of the same length
        /// via a supplied transformation
        /// </summary>
        /// <param name="f">The transformation function</param>
        /// <typeparam name="U">The target vector element type</typeparam>
        public ref Block256<N,U> Map<U>(Func<T,U> f, ref Block256<N,U> dst)
            where U:unmanaged
        {
            for(var i=0; i < Length; i++)
                dst[i] = f(Data[i]);
            return ref dst;
        }

        [MethodImpl(Inline)]
        public Block256<N,U> Convert<U>()
            where U : unmanaged
               => new Block256<N,U>(SpanBlocks.force<T,U>(Data));

        [MethodImpl(Inline)]
        public string Format()
            => Data.Format();

        public Block256<N,T> Replicate()
            => new Block256<N,T>(Data.Replicate());

        public RowVector256<T> Denaturalize()
            => Data;

        public override bool Equals(object other)
            => throw new NotSupportedException();

        public override int GetHashCode()
            => throw new NotSupportedException();

        public override string ToString()
            => Format();

        /// <summary>
        /// Vec => Slice
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="N">The natural length</typeparam>
        /// <typeparam name="T">THe component type</typeparam>
        [MethodImpl(Inline)]
        public static implicit operator NatSpan<N,T>(Block256<N,T> src)
            => RowVectors.natspan<N,T>(src.Data);

        /// <summary>
        /// Slice => Vec
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="N">The natural length</typeparam>
        /// <typeparam name="T">THe component type</typeparam>
        [MethodImpl(Inline)]
        public static implicit operator Block256<N,T>(NatSpan<N,T> src)
            => new Block256<N,T>(src);

        [MethodImpl(Inline)]
        public static implicit operator SpanBlock256<T>(Block256<N,T> src)
            => src.Data;

        [MethodImpl(Inline)]
        public static implicit operator RowVector256<T>(Block256<N,T> src)
            => src.Denaturalize();

        [MethodImpl(Inline)]
        public static implicit operator Block256<N,T>(T[] src)
            => new Block256<N,T>(src);

        [MethodImpl(Inline)]
        public static bool operator == (Block256<N,T> a, in Block256<N,T> b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator != (Block256<N,T> lhs, in Block256<N,T> rhs)
            => !lhs.Equals(rhs);

        [MethodImpl(Inline)]
        public static T operator *(Block256<N,T> lhs, in Block256<N,T> rhs)
            => gmath.dot<T>(lhs.Unsized, rhs.Unsized);
    }
}