//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Defines a vector over cells of unmanaged type
    /// </summary>
    public struct RowVector<T>
        where T : unmanaged
    {
        Index<T> Data;

        /// <summary>
        /// Initializes a vector from array content
        /// </summary>
        /// <param name="src">The source array</param>
        [MethodImpl(Inline)]
        public RowVector(T[] src)
            => Data = src;

        /// <summary>
        /// Queries/manipulates component values
        /// </summary>
        public ref T this[int i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        /// <summary>
        /// The data wrapped by the vector
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
            get => Data.Length;
        }

        /// <summary>
        /// The count of vector components, otherwise known as its dimension
        /// </summary>
        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        /// <summary>
        /// Formats components as a list
        /// </summary>
        /// <param name="sep">The component delimiter</param>
        public string Format()
            => Data.Storage.FormatList();

        public RowVector<U> Convert<U>()
            where U : unmanaged
               => new RowVector<U>(Numeric.force<T,U>(Data));


        public bool Equals(RowVector<T> src)
        {
            var count = Data.Length;

            if(count != src.Data.Length)
                return false;

            for(var i = 0; i<count; i++)
                if(gmath.neq(Data[i], src.Data[i]))
                    return false;
            return true;
        }

        public override bool Equals(object src)
            => src is RowVector<T> x && Equals(x);

        public override int GetHashCode()
            => Data.GetHashCode();

        /// <summary>
        /// Implicitly converts an array to a vector
        /// </summary>
        /// <param name="src">The source array</param>
        /// <typeparam name="T">The component type</typeparam>
        [MethodImpl(Inline)]
        public static implicit operator RowVector<T>(T[] src)
            => new RowVector<T>(src);

        /// <summary>
        /// Implicitly reveals a vector's underlying memory span
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The component type</typeparam>
        [MethodImpl(Inline)]
        public static implicit operator Span<T>(RowVector<T> src)
            =>  src.Data;

        /// <summary>
        /// Implicitly provies a readonly-view of a vector's underlying data
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The component type</typeparam>
        [MethodImpl(Inline)]
        public static implicit operator ReadOnlySpan<T>(RowVector<T> src)
            => src.Data;

        /// <summary>
        /// Calculates the scalar product between the operands
        /// </summary>
        /// <param name="a">The left vector</param>
        /// <param name="b">The right vector</param>
        [MethodImpl(Inline)]
        public static T operator &(RowVector<T> a, RowVector<T> b)
            => gmath.dot<T>(a.Data, b.Data);

        [MethodImpl(Inline)]
        public static bool operator == (RowVector<T> a, RowVector<T> b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator != (RowVector<T> a, RowVector<T> b)
            => !a.Equals(b);
    }
}