//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a finite thing that yields a count value that does not require computation/enumeration
    /// to reveal; in other words, the count function for counted things is free, as evinced by
    /// the default implementation
    /// </summary>
    [Free]
    public interface ICounted : IFinite, INullity
    {
        /// <summary>
        /// The count value
        /// </summary>
        new uint Count {get;}

        uint IFinite.Count()
            => Count;

        bool INullity.IsEmpty
            => Count == 0;
    }
}