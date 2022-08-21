//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a type for which a well-defined Count() function can be implemented
    /// such types will be referred to as "countable" although this terminology unfortunately conflicts
    /// with mathematical countability which only requires the existence of a bijection with
    /// the subject and the natural numbers which does imply that the cardinality is finite
    /// </summary>
    [Free]
    public interface IFinite
    {
        /// <summary>
        /// Counts the finite things
        /// </summary>
        uint Count();
    }
}