//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public readonly struct Node<T> : INode<T>
    {
        public readonly uint Index;

        public readonly T Payload;

        [MethodImpl(Inline)]
        public Node(uint id, T content)
        {
            Index = id;
            Payload = content;
        }

        T INode<T>.Payload
            => Payload;

        uint INode.Index
            => Index;

        public static Node<T> Empty => default;
    }
}