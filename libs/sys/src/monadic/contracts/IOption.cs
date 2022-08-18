//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    /// <summary>
    /// Characterizes an untyped optional value
    /// </summary>
    public interface IOption : IMonadic
    {
        /// <summary>
        /// True if a value exists, false otherwise
        /// </summary>
        bool IsSome {get;}

        /// <summary>
        /// True if a value does not exist, false otherwise
        /// </summary>
        bool IsNone {get;}
    }

    /// <summary>
    /// Characterizes a parametric option
    /// </summary>
    /// <typeparam name="T">The potential value type</typeparam>
    public interface IOption<T> : IOption
    {
        /// <summary>
        /// If extant, specifies the option value
        /// </summary>
        T Value {get;}
    }

    /// <summary>
    /// Characterizes an F-bound polymorphic option
    /// </summary>
    /// <typeparam name="F">The reification type</typeparam>
    /// <typeparam name="T">The potential value type</typeparam>
    public interface IOption<F,T> : IOption<T>, IEquatable<F>
        where F : struct, IOption<F,T>
    {

    }
}