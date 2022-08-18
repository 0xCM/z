//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IVarExpr
    {
        /// <summary>
        /// Specifies the variable fence, if any
        /// </summary>
        AsciFence Fence {get;}

        /// <summary>
        /// Specifies the varible prefix, if any
        /// </summary>
        AsciSymbol Prefix {get;}

        /// <summary>
        /// Indicates whether the variable is prefixed
        /// </summary>
        bool IsPrefixed
            => Prefix != AsciNull.Literal;

        /// <summary>
        /// Indicates whether the variable is fenced
        /// </summary>
        bool IsFenced
            => Fence.Left != AsciNull.Literal && Fence.Right != AsciNull.Literal;
    }

    public interface IVarExpr<T> : IVarExpr
    {

    }
}