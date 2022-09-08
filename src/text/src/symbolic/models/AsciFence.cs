//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct AsciFence : IDataType<AsciFence>
    {
        public readonly AsciSymbol Left;

        public readonly AsciSymbol Right;

        [MethodImpl(Inline)]
        public AsciFence(AsciSymbol left, AsciSymbol right)
        {
            Left = left;
            Right = right;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Left.IsNull || Right.IsNull;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Left.IsNonNull && Right.IsNonNull;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Left.Hash | Right.Hash;
        }

        [MethodImpl(Inline)]
        public int CompareTo(AsciFence src)
        {
            var result = Left.CompareTo(src.Left);
            if(result == 0)
                result = Right.CompareTo(src.Right);
            return result;
        }

        [MethodImpl(Inline)]
        public bool Equals(AsciFence src)
            => Left == src.Left && Right == src.Right;

        public string Format()
            => string.Format("{0}..{1}", Left, Right);

        public string Format<S>(S content)
            => string.Format("{0}{1}{2}", Left, content, Right);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator AsciFence((AsciSymbol left, AsciSymbol right) src)
            => new AsciFence(src.left, src.right);

        [MethodImpl(Inline)]
        public static implicit operator Fence<AsciSymbol>(AsciFence src)
            => new (src.Left,src.Right);

        public static AsciFence Empty => default;
    }
}