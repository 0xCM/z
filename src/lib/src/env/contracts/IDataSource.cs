//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public interface IDataSource
    {


    }
    
    public interface IDataSource<T> : IDataSource
        where T : IEquatable<T>, IComparable<T>, new()
    {


    }
}