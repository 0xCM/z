//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{    
    /// <summary>
    /// Characterizes a natural k such that e:E => k = 2^e
    /// </summary>
    /// <typeparam name="B">The base type</typeparam>
    /// <typeparam name="E">The exponent type</typeparam>
    public interface INatPow2<E> : INatPow<N2,E>, INatEven<E>
        where E : unmanaged, ITypeNat
    {
     
    }
}