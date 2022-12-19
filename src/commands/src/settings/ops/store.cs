//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class Settings
    {
        public static void store(IWfChannel channel, ReadOnlySpan<Setting> src, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci)
        {
            var emitter = text.emitter();
            iter(src, x=> emitter.AppendLine(x.Format()));
            channel.FileEmit(emitter.Emit(),dst, encoding);            
        }

        public static void store<T>(IWfChannel channel, ReadOnlySpan<Setting<T>> src, FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci)
        {
            var emitter = text.emitter();
            iter(src, x=> emitter.AppendLine(x.Format()));
            channel.FileEmit(emitter.Emit(),dst, encoding);            
        }
    }
}