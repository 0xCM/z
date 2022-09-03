//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a structural number in the C adaptation context
    /// </summary>
    /// <typeparam name="S">The reifying type</typeparam>
    public interface ICNumber<S>
        :
            IAdditive<S>,
            ISubtractive<S>,
            IMultiplicative<S>,
            IDivisive<S>,
            IUnital<S>,
            INullary<S>,
            INaturallyPowered<S>
        where S : ICNumber<S>, new()
    {
        /// <summary>
        /// Specifies the (fixed) number of bits required to represent the numeric value
        /// </summary>
        int BitSize {get;}
    }

    /// <summary>
    /// Characterizes a structural number reification in the C adaptation context
    /// </summary>
    /// <typeparam name="S">The reifying type</typeparam>
    public interface ICNumber<S,T> : ICNumber<S>
        where S : ICNumber<S,T>, new()
    {
        S Revalue(T src);

        /// <summary>
        /// Elevates a primitive to a structure
        /// </summary>
        /// <param name="src">The primitive source</param>
        IEnumerable<S> Wrap(IEnumerable<T> src);

        /// <summary>
        /// Unwraps a lifted primitivie
        /// </summary>
        /// <param name="src">The lifted source</param>
        IEnumerable<T> Unwrap(IEnumerable<S> src);
    }
}