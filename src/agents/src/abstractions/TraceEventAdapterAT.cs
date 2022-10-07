//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class TraceEventAdapter<A,T> : TraceEventAdapter<A>
        where A : TraceEventAdapter<A,T>, new()
        where T : unmanaged
    {
        public virtual ref readonly T Body
            => ref core.@as<T>(Subject.Payload<byte[]>("Body").ToSpan());
    }
}