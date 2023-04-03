//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines an untyped literal logic expression
    /// </summary>
    public readonly struct LiteralLogicExpr : ILogicLiteralExpr
    {
        /// <summary>
        /// The literal value
        /// </summary>
        public bool Value {get;}

        [MethodImpl(Inline)]
        public LiteralLogicExpr(bool src)
            => Value= src;

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => false;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => true;
        }

        public string Format()
            => Format(false);

        public string Format(bool digit)
            => digit ? Value.ToString() : Value ? "T" : "F";

        public override string ToString()
            => Format();

        /// <summary>
        /// Implicitly converts a literal expression to the underlying value
        /// </summary>
        /// <param name="src">The source expression</param>
        [MethodImpl(Inline)]
        public static implicit operator bool(LiteralLogicExpr src)
            => src.Value;

        /// <summary>
        /// Implicitly converts a value to a literal expression
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline)]
        public static implicit operator LiteralLogicExpr(bool src)
            => new LiteralLogicExpr(src);
    }
}