//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public readonly struct ValueNode<T> : IValueNode<uint,T>
    {
        public readonly uint Index;

        public readonly T Payload;

        [MethodImpl(Inline)]
        public ValueNode(uint id, T content)
        {
            Index = id;
            Payload = content;
        }

        T IValueNode<T>.Value
            => Payload;


        public static ValueNode<T> Empty => default;

        uint IValueNode<uint, T>.Index 
            => Index;
    }
}