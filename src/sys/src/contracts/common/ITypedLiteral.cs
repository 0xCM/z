//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes type classifiers predicated on enumerations
    /// </summary>
    /// <typeparam name="E">The enum type that defines the classifier superset</typeparam>
    public interface ITypedLiteral<E>
        where E : unmanaged
    {
        E Class {get;}

        string Name
            => Class.ToString().ToLower();
    }

    /// <summary>
    /// Characterizes parametric typed literals
    /// </summary>
    /// <typeparam name="E">The enum type that defines the classifier superset</typeparam>
    /// <typeparam name="T">The numeric type refined by the enum</typeparam>
    public interface ITypedLiteral<E,T> : ITypedLiteral<E>
        where E : unmanaged
        where T : unmanaged
    {
        T Value {get;}
    }

    /// <summary>
    /// Characterizes F-bound polymorphic numeric-parametric typed literals
    /// </summary>
    /// <typeparam name="F">The reification type</typeparam>
    /// <typeparam name="E">The enum type that defines the classifier superset</typeparam>
    /// <typeparam name="T">The numeric type refined by the enum</typeparam>
    public interface ITypedLiteral<F,E,T> : ITypedLiteral<E,T>
        where F : struct, ITypedLiteral<F,E,T>
        where E : unmanaged
        where T : unmanaged
    {

    }
}