//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a literal value which, by definition, is a named constant
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct Literal<T> : ILiteralExpr<T>
    {
        public readonly string Name;

        public readonly Constant<T> Value;

        [MethodImpl(Inline)]
        public Literal(string name, Constant<T> value)
        {
            Name = name;
            Value = value;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Value.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Value.IsEmpty;
        }

        Identifier ILiteralExpr<T>.Name
            => Name;

        Constant<T> ILiteralExpr<T>.Value
            => Value;

        public string Format()
            => string.Format("{0} = {1}", Name, Value.Format());

        public override string ToString()
            => Format();
    }
}