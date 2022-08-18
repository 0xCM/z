//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines the literal content of a symbol
    /// </summary>
    public readonly record struct SymExpr : IExpr
    {
        [Parser]
        public static Outcome parse(string src, out SymExpr dst)
        {
            dst = src ?? EmptyString;
            return true;
        }

        readonly string Content;

        [MethodImpl(Inline)]
        public SymExpr(string content)
            => Content = content ?? EmptyString;

        public ushort CharCount
        {
            [MethodImpl(Inline)]
            get => (ushort)(Content?.Length ?? 0);
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => CharCount == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => CharCount != 0;
        }

        public string Text
        {
            [MethodImpl(Inline)]
            get => Content ?? EmptyString;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Algs.hash(Data);
        }

        public ReadOnlySpan<char> Data
        {
            [MethodImpl(Inline)]
            get => Text;
        }

        [MethodImpl(Inline)]
        public string Format()
            => Text;

        [MethodImpl(Inline)]
        public override string ToString()
            => Format();

        public override int GetHashCode()
            => Hash;

        public bool Equals(SymExpr src)
            => Text.Equals(src.Text, NoCase);

        public static implicit operator SymExpr(string src)
            => new SymExpr(src);

        public static SymExpr Empty
        {
            [MethodImpl(Inline)]
            get => new SymExpr(EmptyString);
        }
    }
}