//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;
 
    partial class Cmd
    {
        public static CmdId identify<T>()
            => identify(typeof(T));

        [Op]
        public static CmdId identify(Type spec)
        {
            var tag = spec.Tag<CmdAttribute>();
            if(tag)
            {
                var name = tag.Value.Name;
                if(empty(name))
                    return new CmdId(spec.Name);
                else
                    return new CmdId(name);
            }
            else
                return new CmdId(spec.Name);
        }

        public static void emit(ICmdSource src, FS.FilePath dst, IWfEventTarget log)
        {
            log.Deposit(Events.emittingFile(src.GetType(),dst));
            var commands = src.Commands;
            using var writer = dst.AsciWriter();
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var cmd = ref commands[i];
                var fmt = cmd.Format();
                log.Deposit(Events.row(fmt));
                writer.WriteLine(fmt);
            }

            log.Deposit(Events.emittedFile(src.GetType(), dst, src.Count));
        }

        // public static void emit(CmdCatalog src, FS.FilePath dst, IWfEventTarget log)
        // {
        //     var data = src.Entries;
        //     iter(data, x => log.Deposit(Events.row(x.Uri.Name)));
        //     Tables.emit(log, data.View, dst);
        // }

        public static void emit(CmdCatalog src, FS.FilePath dst, WfEmit channel)
        {
            var data = src.Entries;
            iter(data, x => channel.Row(x.Uri.Name));
            Tables.emit(channel, data.View, dst);
        }
    }
}
