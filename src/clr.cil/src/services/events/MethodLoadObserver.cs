//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Diagnostics.Tracing;

    public sealed class MethodLoadObserver : TraceEventObserver<MethodLoadEvent>
    {
        public static MethodLoadObserver observe(FilePath dst)
            => new MethodLoadObserver(dst);

        public MethodLoadObserver(FilePath log)
            : base(MethodLoadEvent.Keyword, MethodLoadEvent.EventName, Demand.nonempty(log))
        {

        }

        protected override MethodLoadEvent Decode(EventWrittenEventArgs src)
            => RuntimeEvents.decode(src, out MethodLoadEvent e);
    }    
}