//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    /// <summary>
    /// Characterizes a parametric join of arity 2
    /// </summary>
    /// <typeparam name="L">The left value type</typeparam>
    /// <typeparam name="R">The right value type</typeparam>
    [Free]
    public interface IPaired<L,R>
    {
        /// <summary>
        /// The left value
        /// </summary>
        L Left {get;}

        /// <summary>
        /// The right value
        /// </summary>
        R Right {get;}
    }
}