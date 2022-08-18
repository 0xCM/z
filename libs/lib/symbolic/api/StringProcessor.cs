//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public abstract class StringProcessor<P,S,T>
        where P : StringProcessor<P,S,T>, new()
        where S : unmanaged, IEquatable<S>, IComparable<S>, IString<S>
    {
        public abstract bool Process(ref S src, out T dst);
    }
}