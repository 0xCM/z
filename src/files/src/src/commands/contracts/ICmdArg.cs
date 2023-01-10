//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ICmdArg  
    {
        @string Name {get;}        
    }

    public interface ICmdArg<T> : ICmdArg
        where T : IEquatable<T>, IComparable<T>
    {
        T Value {get;}        
    }
}