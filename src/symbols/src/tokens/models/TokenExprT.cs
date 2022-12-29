//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct TokenExpr<T>
        where T : unmanaged, ICharBlock
    {
        public readonly uint Id;

        public readonly T Content;

        public readonly int Length;

        [MethodImpl(Inline)]
        public TokenExpr(uint id, T src)
        {
            Content = src;
            Id = id;
            Length = src.Length;
        }

        public string Format()
            => Content.Format();

        public override string ToString()
            => Format();
    }
}