//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a type for which nullity can be adjudicated
    /// </summary>
    [Free]
    public interface INullity
    {
        bool IsEmpty {get;}

        bool IsNonEmpty => !IsEmpty;
    }

    [Free]
    public interface INullity<T> : INullity
        where T : INullity<T>
    {

    }
}