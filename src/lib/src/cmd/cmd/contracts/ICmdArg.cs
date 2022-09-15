//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ICmdArg : IDataType, IDataString
    {
        uint Index {get;}

        @string Name {get;}
    }

    public interface ICmdArg<T> : ICmdArg
        where T : IEquatable<T>, IComparable<T>
    {
        T Value {get;}
    }

    public interface ICmdArg<A,T> : IDataType<A>, ICmdArg<T>
        where A : ICmdArg<A,T>
        where T : IEquatable<T>, IComparable<T>
    {
    }


}