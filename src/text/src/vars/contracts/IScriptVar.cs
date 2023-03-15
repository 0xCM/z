//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IScriptVar : IVar
    {
        /// <summary>
        /// Specifies the varible prefix, if any
        /// </summary>
        AsciSymbol Prefix {get;}

        /// <summary>
        /// Specifies the variable fence, if any
        /// </summary>
        AsciFence Fence {get;}

        /// <summary>
        /// Indicates whether the variable is prefixed
        /// </summary>
        bool IsPrefixed
            => Prefix != 0;

        /// <summary>
        /// Indicates whether the variable is fenced
        /// </summary>
        bool IsFenced
            => Fence.Left != 0 && Fence.Right != 0;

        bool IsPrefixedFence
            => IsPrefixed && IsFenced;
    }

    public interface IScriptVar<T> : IScriptVar, IVar<T>
        where T : IEquatable<T>, INullity, new()    
    {
        
    }
}