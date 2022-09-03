//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IMultiplicative<T>
    {
        T Mul(T rhs);
    }

    /// <summary>
    /// Characterizes structural multiplication
    /// </summary>
    /// <typeparam name="S">The structure type</typeparam>
    /// <typeparam name="T">The individual type</typeparam>
    public interface IMultiplicative<F,T> : IMultiplicative<F>
        where F : IMultiplicative<F,T>, new()
    {
        
    }    
}