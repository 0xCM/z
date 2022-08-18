//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes an E-parametric literal that supports T-parametric stratification
    /// </summary>
    /// <typeparam name="E">The classifier type</typeparam>
    /// <typeparam name="T">The stratification type</typeparam>
    public interface ILiteralType<E,T> : ILiteralKind<E>
        where E : unmanaged, Enum
    {

    }

    /// <summary>
    /// Characterizes a T-parametric F-bound polymorphic E-parametric literal reification
    /// </summary>
    /// <typeparam name="F">The reification type</typeparam>
    /// <typeparam name="E">The classifier type</typeparam>
    /// <typeparam name="T">The stratification type</typeparam>
    public interface ILiteralType<F,E,T> : ILiteralKind<F,E>, ILiteralType<E,T>
        where F : ILiteralType<F,E,T>, new()
        where E : unmanaged, Enum
    {

    }
}