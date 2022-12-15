//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct EnvExpr : IExpr
    {
        public readonly @string Content;

        public EnvExpr(@string content)
        {
            Content = content;
        }

        public bool IsEmpty 
        {
            [MethodImpl(Inline)]
            get => Content.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Content.IsEmpty;
        }

        public string Format()
            => Content.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator EnvExpr(string src)
            => new EnvExpr(src);

        public static EnvExpr Empty => new EnvExpr(EmptyString);
    }
}