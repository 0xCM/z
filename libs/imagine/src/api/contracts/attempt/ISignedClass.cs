//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a type-level sign classifier
    /// </summary>
    public interface ISignedClass
    {
        /// <summary>
        /// Specifies the literal classifier the type-level classifier represents
        /// </summary>
        PolarityKind Kind {get;}
    }

    /// <summary>
    /// Characterizes an F-bound polymorphic type-level sign classifier reification
    /// </summary>
    /// <typeparam name="F">The reifying type</typeparam>
    public interface ISignedClass<F> : ISignedClass
        where F : unmanaged, ISignedClass
    {

    }

    /// <summary>
    /// Characterizes an F-bound polymorphic and S-parametric sign classifier reification
    /// </summary>
    /// <typeparam name="F">The reifying type</typeparam>
    /// <typeparam name="S">The sign classifier type</typeparam>
    public interface ISignedClass<F,S> : ISignedClass<S>
        where S : unmanaged, ISignedClass
        where F : unmanaged, ISignedClass<F,S>
    {

    }

    /// <summary>
    /// Characterizes an F-bound polymorphic S/T-parametric sign classifier reification
    /// </summary>
    /// <typeparam name="F">The reifying type</typeparam>
    /// <typeparam name="S">The sign classifier type</typeparam>
    /// <typeparam name="T">The T-carrier, of any sort</typeparam>
    public interface ISignedClass<F,S,T> : ISignedClass<F,S>
        where S : unmanaged, ISignedClass
        where F : unmanaged, ISignedClass<F,S,T>
    {
        /// <summary>
        /// Reveals the singleton instance of the T-parametric classifier
        /// </summary>
        S SignType
            => default;

        /// <summary>
        /// Default implementation of <see cref="ISignedClass.Kind"/>
        /// </summary>
        PolarityKind ISignedClass.Kind
            => SignType.Kind;
    }
}