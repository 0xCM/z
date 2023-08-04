//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public static class TraceEventAdapter
    {
        public static T Payload<T>(this TraceEvent e, string name)
            => (T)e.PayloadByName(name);
    }
}