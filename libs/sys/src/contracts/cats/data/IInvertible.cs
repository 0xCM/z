//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IInvertible<F>
        where F : IInvertible<F>, new()
    {
        /// <summary>
        /// Unary structural negation
        /// </summary>
        F Invert();
    }
}