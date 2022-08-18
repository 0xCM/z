//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    /// <summary>
    /// Asserts the equality of a computed expression and a reference expression
    /// </summary>
    [Free]
    public interface IEqualityClaim : IClaim
    {
        /// <summary>
        /// The computed expression
        /// </summary>
        dynamic Actual {get;}

        /// <summary>
        /// The reference expression
        /// </summary>
        dynamic Expect {get;}
    }

    [Free]
    public interface IEqualityClaim<T> : IEqualityClaim
        where T : IEquatable<T>
    {
        new T Actual {get;}

        new T Expect {get;}

        dynamic IEqualityClaim.Actual
            => Actual;

        dynamic IEqualityClaim.Expect
            => Actual;
    }
}