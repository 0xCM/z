//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract record class AppEnv<S,T>
        where S : AppEnv<S,T>, new()
        where T : IEquatable<T>, IComparable<T>, new()
    {
        
    }
}