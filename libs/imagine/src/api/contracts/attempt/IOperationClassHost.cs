//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    /// <summary>
    /// Characterizes an operation class that is both class-parametric and F-bound polymorphic
    /// </summary>
    /// <typeparam name="F">The reification type</typeparam>
    /// <typeparam name="E">The class type</typeparam>
    [Free]
    public interface IOperationClassHost<F,E> : IOperationClass<E>
        where F : IOperationClassHost<F,E>, new()
        where E : unmanaged, Enum
    {

    }

    /// <summary>
    /// Characterizes an operation class that is operand, class parametric, and F-bound polymorphic
    /// </summary>
    /// <typeparam name="T">The operand type</typeparam>
    /// <typeparam name="E">The class type</typeparam>
    [Free]
    public interface IOperationClassHost<F,E,T> : IOperationClass<E,T>, IOperationClassHost<F,E>
        where F : IOperationClassHost<F,E,T>, new()
        where E : unmanaged, Enum
    {

    }
}