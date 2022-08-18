//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Represents the content of a contiguous interval between comparable lower and upper bounds of the same type
    /// </summary>
    public interface ITimeInterval
    {

    }

    public interface ITimeInterval<out T> : ITimeInterval
    {
        /// <summary>
        /// The inclusive lower bound
        /// </summary>
        T Min {get;}

        /// <summary>
        /// The inclusive upper bound
        /// </summary>
        T Max {get;}
    }
}