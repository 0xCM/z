//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct CharFence
    {
        readonly Fence<char> Fence;

        [MethodImpl(Inline)]
        public CharFence(Fence<char> src)
        {
            Fence = src;
        }

        [MethodImpl(Inline)]
        public CharFence(char left, char right)
        {
            Fence = (left,right);
        }

        public char Left
        {
            [MethodImpl(Inline)]
            get => Fence.Left;
        }

        public char Right
        {
            [MethodImpl(Inline)]
            get => Fence.Right;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Left == 0 || Right == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Left != 0 && Right != 0;
        }

        public static CharFence Empty => ((char)0, (char)0);

        [MethodImpl(Inline)]
        public static implicit operator CharFence(Fence<char> src)
            => new CharFence(src);

        [MethodImpl(Inline)]
        public static implicit operator CharFence((char left, char right) src)
            => new CharFence(src.left, src.right);

        [MethodImpl(Inline)]
        public static implicit operator Fence<char>(CharFence src)
            => src.Fence;

        [MethodImpl(Inline)]
        public static Fence<char> define(char left, char right)
            => (left,right);
    }
}