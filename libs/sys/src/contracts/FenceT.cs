//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public readonly struct Fence<T>
    {
        public readonly T Left;

        public readonly T Right;

        [MethodImpl(Inline)]
        public Fence(T left, T right)
        {
            Left = left;
            Right = right;
        }

        public string Format()
            => string.Format("{0}..{1}", Left, Right);

        public string Format<S>(S content)
            => string.Format("{0}{1}{2}", Left, content, Right);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Fence<T>((T left, T right) src)
            => new Fence<T>(src.left, src.right);

        public static Fence<T> Empty => default;
    }
}