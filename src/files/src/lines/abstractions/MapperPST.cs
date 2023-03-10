//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class Mapper<P,S,T> : IMapper<S,T>
        where P : Mapper<P,S,T>, new()
    {
        public abstract T Map(S src);
    }
}