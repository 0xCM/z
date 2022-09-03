//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes structural inversion
    /// </summary>
    /// <typeparam name="T">The type over which the structure is defined</typeparam>
    public interface IInvertive<S>
    {

    }

    /// <summary>
    /// Characterizes structural additive inversion
    /// </summary>
    /// <typeparam name="S">The reification type</typeparam>
    public interface IInvertiveA<S> : IInvertive<S>, IAdditive<S>
        where S : IInvertiveA<S>, new()
    {
        /// <summary>
        /// Effects additive inversion
        /// </summary>
        S InvertA();
    }

    /// <summary>
    /// Characterizes structural multiplicative inversion
    /// </summary>
    /// <typeparam name="S">The reification type</typeparam>
    public interface IInvertiveM<S> : IInvertive<S>, IMultiplicative<S>
        where S : IInvertiveM<S>, new()
    {
        /// <summary>
        /// Effects multiplicative inversion
        /// </summary>
        S InvertM();
    }
}
