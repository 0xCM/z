//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class Settings
    {
        [Op]
        public static uint store(SettingLookup src, char sep, StreamWriter dst)
        {
            var settings = src.View;
            var count = (uint)settings.Length;
            if(count == 0)
                return count;

            for(var i = 0; i<count; i++)
            {
                ref readonly var setting = ref skip(settings,i);
                dst.WriteLine(string.Format("{0}{1}{2}", setting.Name, sep, setting.Value));
            }
            return count;
        }

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