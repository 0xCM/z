//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes operations over a nullary type
    /// </summary>
    /// <typeparam name="T">The unit type</typeparam>
    /// <remarks>
    /// It is tempting to subclass Additive here, but there are cases where
    /// it makes sense for something have a zero element and yet not be
    /// additive, e.g. a string can be empty, and they can be added (via concatentation)
    /// but consider the set of singleton/atomic strings over some alphabet. In
    /// this case, there can be no (closed) concatenation operation and yet
    /// the concept of nothingness (the empty string) is still meaningful
    /// </remarks>
    [Free]
    public interface INullaryOps<T>
    {
        T Zero {get;}
    }

    [Free]
    public interface INullary : INullity
    {
        bool IsZero => false;

        bool IsNonZero => !IsZero;

        bool INullity.IsEmpty
            => IsZero;

        bool INullity.IsNonEmpty
            => IsNonZero;
    }

    /// <summary>
    /// Characterizes an additive structure S for which there exists a distinguished
    /// element 0:S such that for every s:S, s + 0 = s
    /// </summary>
    /// <typeparam name="T">The zero value type</typeparam>
    [Free]
    public interface INullary<T> : INullary
        where T : new()
    {
        /// <summary>
        /// Specifies the zero value
        /// </summary>
        T Zero => new T();
    }

    [Free]
    public interface INullary<F,T> : INullary<F>, INullity
        where F : INullary<F,T>, new()
    {
        F INullary<F>.Zero
            => new F();

        bool INullity.IsEmpty
            => this.Equals(Zero);
    }
}