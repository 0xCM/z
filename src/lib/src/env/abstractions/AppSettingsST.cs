//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract record class AppSettings<S,T>
        where S : AppSettings<S,T>, new()
        where T : IEquatable<T>, IComparable<T>, new()
    {
        
    }
}