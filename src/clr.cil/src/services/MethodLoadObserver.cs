//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Diagnostics.Tracing;

    using static RuntimeEvents;

    partial class RuntimeObservers
    {
        [MethodImpl(Inline), Op]
        static ref MethodLoadEvent decode(EventWrittenEventArgs src, out MethodLoadEvent dst)
        {
            var data = src.Payload;
            var i=0;
            dst.MethodID = (ulong)data[i++];
            dst.ModuleID = (ulong)data[i++];
            dst.MethodStartAddress = (ulong)data[i++];
            dst.MethodSize = (uint)data[i++];
            dst.MethodToken = (uint)data[i++];
            dst.MethodFlags= (MethodLoadEvent.MethodFlag)(uint)data[i++];
            dst.MethodNameSpace = (string)data[i++];
            dst.MethodName = (string)data[i++];
            dst.MethodSignature = (string)data[i++];
            dst.ClrInstanceID = (ushort)data[i++];
            dst.MethodID = (ulong)data[i++];
            dst.MethodID = (ulong)data[i++];
            dst.MethodID = (ulong)data[i++];
            return ref dst;
        }

        public sealed class MethodLoad : Observer<MethodLoadEvent>
        {
            public static MethodLoad observe(FilePath dst)
                => new MethodLoad(dst);

            public MethodLoad(FilePath log)
                : base(MethodLoadEvent.Keyword, MethodLoadEvent.EventName, Demand.nonempty(log))
            {

            }

            protected override MethodLoadEvent Decode(EventWrittenEventArgs src)
                => decode(src, out MethodLoadEvent e);
        }
    }
}