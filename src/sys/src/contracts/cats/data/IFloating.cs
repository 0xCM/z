//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IFloating<S> :
        IRealNumeric<S>,
        IFractional<S>,
        ISubtractive<S>,
        ITrigonmetric<S>
            where S : IFloating<S>, new()
    {
        S Sqrt();
    }

    /// <summary>
    /// Characterizes a structure for a floating point number
    /// </summary>
    /// <typeparam name="T">The underlying numeric type</typeparam>
    public interface IFloating<S,T> : IFloating<S>
        where S : IFloating<S,T>, new()
    {

    }
}