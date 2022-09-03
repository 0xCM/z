//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
 
    partial class Cmd
    {
        public static void emit(ICmdSource src, WfEmit channel, FilePath dst)
        {
            var flow = channel.EmittingFile(dst);
            var commands = src.Commands;
            using var writer = dst.AsciWriter();
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var cmd = ref commands[i];
                var fmt = cmd.Format();
                channel.Row(fmt);
                writer.WriteLine(fmt);
            }

            channel.EmittedFile(flow, src.Count);
        }

        public static void emit(CmdCatalog src, FilePath dst, WfEmit channel)
        {
            var data = src.Entries;
            iter(data, x => channel.Row(x.Uri.Name));
            Tables.emit(channel, data.View, dst);
        }
    }
}
