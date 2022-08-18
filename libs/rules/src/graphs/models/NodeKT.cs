//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a vertex to which data may be attached
    /// </summary>
    /// <typeparam name="K">The vertex index type</typeparam>
    /// <typeparam name="T">The payload type</typeparam>
    public readonly struct Node<K,T> : INode<K,T>
        where K : unmanaged
    {
        /// <summary>
        /// The index of the vertex that uniquely identifies it within a graph
        /// </summary>
        public readonly K Index;

        /// <summary>
        /// The vertex payload
        /// </summary>
        public readonly T Payload;

        [MethodImpl(Inline)]
        public Node(K index, T content)
        {
            Index = index;
            Payload = content;
        }

        K INode<K,T>.Index
            => Index;

        T INode<T>.Payload
            => Payload;

        public string Format()
            => string.Format("({0},{1})", Index, Payload);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static Arrow<K> operator +(in Node<K,T> src, in Node<K,T> dst)
            => new Arrow<K>(src.Index, dst.Index);

        /// <summary>
        /// Sheds the associated data to form a payload-free vertex
        /// </summary>
        /// <param name="src">The source vertex</param>
        [MethodImpl(Inline)]
        public static implicit operator Node<T>(in Node<K,T> src)
            => new Node<T>(core.bw32(src.Index), src.Payload);
    }
}