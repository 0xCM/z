//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ILocatedSource : ISourceCode, IMemoryString
    {

    }

    public interface ILocatedSource<F,T> : ISourceCode<F,T>, ILocatedSource, IMemoryString<F,T>
        where F : ILocatedSource<F,T>, new()
        where T : unmanaged, IComparable<T>, IEquatable<T>
    {

    }
}