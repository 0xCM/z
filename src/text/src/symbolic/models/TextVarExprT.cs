//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines the root <see cref='ITextVarExpr'/> abstraction
    /// </summary>
    /// <typeparam name="T">The concrete expression type</typeparam>
    public abstract class TextVarExpr<T> : ITextVarExpr
        where T : TextVarExpr<T>
    {
        /// <summary>
        /// Specifies the variable fence, if any
        /// </summary>
        public virtual Fence<char> Fence => Fence<char>.Empty;

        /// <summary>
        /// Specifies the varible prefix, if any
        /// </summary>
        public virtual char Prefix => '\0';

        /// <summary>
        /// Indicates whether the variable is prefixed
        /// </summary>
        public virtual bool IsPrefixed => Prefix != '\0';

        /// <summary>
        /// Indicates whether the variable is fenced
        /// </summary>
        public virtual bool IsFenced => Fence.Left != '\0' && Fence.Right != '\0';

        public TextVarClass Class  => TextExpr.@class(this);
    }
}