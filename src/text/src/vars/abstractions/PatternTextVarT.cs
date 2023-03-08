//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class PatternTextVar<T>
        where T : PatternTextVar<T>
    {
        /// <summary>
        /// Specifies the variable fence, if any
        /// </summary>
        public virtual Fence<char> Fence 
            => Fence<char>.Empty;

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
        public virtual bool IsFenced 
            => Fence.Left != '\0' && Fence.Right != '\0';
    }
}