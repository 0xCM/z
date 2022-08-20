//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ILoadedSource : ISourceCode, IMemoryString
    {

    }

    public interface ILoadedSource<F,T> : ISourceCode<F,T>, ILoadedSource, IMemoryString<F,T>
        where F : ILoadedSource<F,T>, new()
        where T : unmanaged, IComparable<T>, IEquatable<T>
    {

    }
}