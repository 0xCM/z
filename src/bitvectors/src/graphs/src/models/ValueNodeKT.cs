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
    public readonly struct ValueNode<K,T> : IValueNode<K,T>
        where K : unmanaged
    {
        /// <summary>
        /// The index of the vertex that uniquely identifies it within a graph
        /// </summary>
        public readonly K Index;

        /// <summary>
        /// The vertex payload
        /// </summary>
        public readonly T Value;

        [MethodImpl(Inline)]
        public ValueNode(K index, T content)
        {
            Index = index;
            Value = content;
        }

        T IValueNode<T>.Value
            => Value;

        K IValueNode<K, T>.Index 
            => Index;

        public string Format()
            => string.Format("({0},{1})", Index, Value);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static Arrow<K> operator +(in ValueNode<K,T> src, in ValueNode<K,T> dst)
            => new (src.Index, dst.Index);

        /// <summary>
        /// Sheds the associated data to form a payload-free vertex
        /// </summary>
        /// <param name="src">The source vertex</param>
        [MethodImpl(Inline)]
        public static implicit operator ValueNode<T>(in ValueNode<K,T> src)
            => new (sys.bw32(src.Index), src.Value);
    }
}