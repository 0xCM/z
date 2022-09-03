//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines nonparametric either attributes
    /// </summary>
    public interface IEither : IMonadic
    {
        /// <summary>
        /// Specifies whether the left alternative exists
        /// </summary>
        bool IsLeft {get;}

        /// <summary>
        /// Specifies whether the right alternative exists
        /// </summary>
        bool IsRight {get;}
    }

    /// <summary>
    /// Characterizes a parametric disjoint union of arity two, where exactly one state
    /// is populated for a given instantitation
    /// </summary>
    /// <typeparam name="L">The left potential value</typeparam>
    /// <typeparam name="R">The right potential value</typeparam>
    public interface IEither<L,R> : IEither
    {
        /// <summary>
        /// If <see cref="IsLeft"/> is true, specifies the value of the left alternative
        /// </summary>
        L Left {get;}

        /// <summary>
        /// If <see cref="IsRight"/> is true, specifies the value of the right alternative
        /// </summary>
        R Right {get;}
    }
}