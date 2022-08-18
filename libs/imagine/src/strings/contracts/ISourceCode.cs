//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ISourceCode : IString
    {

    }

    public interface ISourceCode<F,T> : ISourceCode, IString<F,T>
        where F : ISourceCode<F,T>, new()
        where T : unmanaged, IComparable<T>, IEquatable<T>
    {

    }
}