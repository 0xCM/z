//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Microsoft.SymbolStore;

    readonly struct SymbolTracer : ITracer
    {
        readonly IWfChannel Channel;

        [MethodImpl(Inline)]
        public SymbolTracer(IWfChannel wf)
            => Channel = wf;

        [MethodImpl(Inline), Op]
        public void Error(string message)
            => Channel.Error(message);

        [MethodImpl(Inline), Op]
        public void Error(string format, params object[] arguments)
            => Channel.Error(string.Format(format, arguments));

        [MethodImpl(Inline), Op]
        public void Information(string message)
            => Channel.Status(message);

        [MethodImpl(Inline), Op]
        public void Information(string format, params object[] arguments)
            => Channel.Status(string.Format(format, arguments));

        [MethodImpl(Inline), Op]
        public void Verbose(string message)
            => Channel.Status(message);

        [MethodImpl(Inline), Op]
        public void Verbose(string format, params object[] arguments)
            => Channel.Status(string.Format(format, arguments));

        [MethodImpl(Inline), Op]
        public void Warning(string message)
            => Channel.Warn(message);

        [MethodImpl(Inline), Op]
        public void Warning(string format, params object[] arguments)
            => Channel.Warn(string.Format(format, arguments));

        [MethodImpl(Inline), Op]
        public void WriteLine(string message)
            => Channel.Row(message);

        [MethodImpl(Inline), Op]
        public void WriteLine(string format, params object[] arguments)
            => Channel.Row(string.Format(format, arguments));
    }
}