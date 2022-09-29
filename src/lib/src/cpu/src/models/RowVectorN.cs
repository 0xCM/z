//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public struct RowVector<N,T>
        where N : unmanaged, ITypeNat
        where T : unmanaged
    {
         Index<T> Data;

        /// <summary>
        /// The vector's dimension
        /// </summary>
        public static int Dim
            => (int)nat64u<N>();

        /// <summary>
        /// The zero vector
        /// </summary>
        public static RowVector<N,T> Zero
            => new RowVector<N,T>(new T[Dim]);

        /// <summary>
        /// Initializes a vector with an array
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline)]
        public RowVector(T[] src)
        {
            Require.invariant(src.Length >= Dim, () => $"{src.Length} < {Dim}");
            Data = src;
        }

        /// <summary>
        /// Queries/manipulates component values
        /// </summary>
        public ref T this[int index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        /// <summary>
        /// The vector data
        /// </summary>
        public T[] Storage
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        /// <summary>
        /// The count of vector components, otherwise known as its dimension
        /// </summary>
        public int Length
        {
            [MethodImpl(Inline)]
            get => Dim;
        }

        /// <summary>
        /// Projects the source vector onto a target vector of the same length
        /// via a supplied transformation
        /// </summary>
        /// <param name="f">The transformation function</param>
        /// <typeparam name="U">The target vector element type</typeparam>
        [MethodImpl(Inline)]
        public RowVector<N,U> Map<U>(Func<T,U> f)
            where U:unmanaged
        {
            var dst = RowVectors.alloc<N,U>();
            return Map(f, ref dst);
        }

        /// <summary>
        /// Projects the source vector onto a caller-supplied target vector of the same length
        /// via a supplied transformation
        /// </summary>
        /// <param name="f">The transformation function</param>
        /// <typeparam name="U">The target vector element type</typeparam>
        public ref RowVector<N,U> Map<U>(Func<T,U> f, ref RowVector<N,U> dst)
            where U:unmanaged
        {
            for(var i=0; i < Length; i++)
                dst[i] = f(Data[i]);
            return ref dst;
        }

        [MethodImpl(Inline)]
        public RowVector<N,U> Convert<U>()
            where U : unmanaged
               => new RowVector<N,U>(Numeric.force<T,U>(Data));

        public bool Equals(RowVector<N,T> rhs)
        {
            for(var i = 0; i<Dim; i++)
                if(gmath.neq(Data[i], rhs.Data[i]))
                    return false;
            return true;
        }

        [MethodImpl(Inline)]
        public string Format()
            => Data.Storage.FormatList();

        public override bool Equals(object rhs)
            => rhs is RowVector<N,T> x && Equals(x);

        public override int GetHashCode()
            => Data.GetHashCode();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator RowVector<T>(RowVector<N,T> src)
            => new RowVector<T>(src.Data);

        [MethodImpl(Inline)]
        public static implicit operator ReadOnlySpan<T>(RowVector<N,T> src)
            => src.Data;

        [MethodImpl(Inline)]
        public static implicit operator RowVector<N,T>(T[] src)
            => new RowVector<N,T>(src);

        [MethodImpl(Inline)]
        public static implicit operator RowVector<N,T>(RowVector<T> src)
            => new RowVector<N,T>(src.Storage);

        [MethodImpl(Inline)]
        public static bool operator == (RowVector<N,T> lhs, RowVector<N,T> rhs)
            => lhs.Equals(rhs);

        [MethodImpl(Inline)]
        public static bool operator != (RowVector<N,T> lhs, RowVector<N,T> rhs)
            => !lhs.Equals(rhs);

        [MethodImpl(Inline)]
        public static T operator *(RowVector<N,T> lhs, RowVector<N,T> rhs)
            => gmath.dot<T>(lhs.Storage, rhs.Storage);
    }
}