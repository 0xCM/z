//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    /// <summary>
    /// Identifies a class that classifies operations
    /// </summary>
    [Free]
    public interface IOperationClass : IApiClass
    {

    }

    /// <summary>
    /// Characterizes a class-parametric operation class
    /// </summary>
    /// <typeparam name="E">The class type</typeparam>
    [Free]
    public interface IOperationClass<E> : IOperationClass, IApiClass<E>
        where E : unmanaged, Enum
    {
        E IApiClass<E>.Kind
            => Kind;

        string Name
            => Kind.ToString().ToLower();

        string ITextual.Format()
            => Name;
    }

    /// <summary>
    /// Characterizes an operation class that both operand and class parametric
    /// </summary>
    /// <typeparam name="T">The operand type</typeparam>
    /// <typeparam name="E">The class type</typeparam>
    [Free]
    public interface IOperationClass<E,T> : IOperationClass<E>
        where E : unmanaged, Enum
    {

    }

    [Free]
    public interface IOperationClass<K,E,T> : IOperationClass<E,T>
        where E : unmanaged, Enum
        where K : IOperationClass<E>, new()
    {
    }
}