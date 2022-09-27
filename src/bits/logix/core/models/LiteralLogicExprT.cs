//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a typed literal logic expression
    /// </summary>
    public readonly struct LiteralLogicExpr<T> : ILogicLiteralExpr<T>
        where T : unmanaged
    {
        /// <summary>
        /// The literal value
        /// </summary>
        public bool Value {get;}

        [MethodImpl(Inline)]
        public LiteralLogicExpr(bool src)
            => Value = src;

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
            => $"{Value}";

        public override string ToString()
            => Format();
    }
}