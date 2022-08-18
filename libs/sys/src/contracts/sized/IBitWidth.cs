//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines an aspect that specifies a bit width
    /// </summary>
    public interface IBitWidth
    {
        uint BitWidth {get;}
    }

    /// <summary>
    /// Characterizes a structural type with an advertized bit-width
    /// </summary>
    /// <typeparam name="W">The defining type</typeparam>
    public interface IBitWidth<W> : IBitWidth
        where W : struct, IBitWidth<W>
    {

    }

    public interface IBitWidth<W,T> : IBitWidth<W>
        where W : struct, IBitWidth<W,T>
        where T : unmanaged
    {

    }
}