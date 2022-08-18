//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class LogicOps
    {
        /// <summary>
        /// Defines two potential choices
        /// </summary>
        public readonly struct Xor<T> : IExpr
            where T : IExpr
        {
            public T Left {get;}

            public T Right {get;}

            [MethodImpl(Inline)]
            public Xor(T left, T right)
            {
                Left = left;
                Right = right;
            }

            [MethodImpl(Inline)]
            public Xor(Pair<T> src)
            {
                Left = src.Left;
                Right = src.Right;
            }

            public bool IsEmpty
                => Left.IsEmpty || Right.IsEmpty;

            public string Name
                => "xor<{0}>";

            public string Format()
                => OpFormatters.format(this);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator Xor<T>(Pair<T> src)
                => new Xor<T>(src);

            [MethodImpl(Inline)]
            public static implicit operator Xor<T>((T left, T right) src)
                => new Xor<T>(src);
        }
    }
}