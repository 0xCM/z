//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ISourceCode : IDataString
    {

    }

    public interface ISourceCode<C> : ISourceCode
        where C : IEquatable<C>, IComparable<C>
    {
        ref readonly C Content {get;}
    }

    public interface ISourceCode<F,T> : ISourceCode
        where F : ISourceCode<F,T>, new()
        where T : unmanaged, IComparable<T>, IEquatable<T>
    {

    }
}