//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a structure that represents a complex number
    /// </summary>
    /// <typeparam name="S">The structure type</typeparam>
    /// <typeparam name="T">The underlying numeric component type</typeparam>
    /// <typeparam name="C">The complex number type</typeparam>
    public interface IComplex<S,T,C> : IRational<S>
        where S : unmanaged, IComplex<S,T,C>
    {
        /// <summary>
        /// The real part
        /// </summary>
        T Re {get;}

        /// <summary>
        /// The imaginary part
        /// </summary>
        T Im {get;}
    }
}