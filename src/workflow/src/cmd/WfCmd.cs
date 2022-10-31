//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class WfCmd
    {
        static AppDb AppDb => AppDb.Service;

        public static WfContext<C> context<C>(IWfRuntime wf, Func<ReadOnlySeq<ICmdProvider>> factory)
            where C : IAppCmdSvc, new()
                => WfServices.context<C>(wf,factory);

        [Op]
        public static bool parse(ReadOnlySpan<char> src, out AppCmdSpec dst)
        {
            var i = SQ.index(src, Chars.Space);
            if(i < 0)
                dst = new AppCmdSpec(@string(src), CmdArgs.Empty);
            else
            {
                var name = sys.@string(SQ.left(src,i));
                var _args = sys.@string(SQ.right(src,i)).Split(Chars.Space);
                dst = new AppCmdSpec(name, CmdArgs.args(_args));
            }
            return true;
        }

        public static AppCommands distill(IAppCommands[] src)
        {
            var dst = dict<string,IWfCmdRunner>();
            foreach(var a in src)
                iter(a.Invokers,  a => dst.TryAdd(a.CmdName, a));
            return new AppCommands(dst);
        }

        public static void emit(IWfChannel channel, CmdCatalog src, FilePath dst)
        {
            var data = src.Values;
            iter(data, x => channel.Row(x.Uri.Name));
            Tables.emit(channel, data, dst);
        }

        public static CmdCatalog catalog(ReadOnlySeq<WfOp> src)
        {
            var count = src.Count;
            var dst = alloc<CmdUri>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = src[i].Uri;
            return new CmdCatalog(entries(dst));
        }

        public static CmdCatalog catalog(IWfDispatcher src)
        {
            ref readonly var defs = ref src.Commands.Defs;
            var count = defs.Count;
            var dst = alloc<CmdUri>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = defs[i].Uri;
            return new CmdCatalog(entries(dst));
        }

        static ReadOnlySeq<CmdCatalogEntry> entries(CmdUriSeq src)    
        {
            var entries = alloc<CmdCatalogEntry>(src.Count);
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var uri = ref src[i];
                ref var entry = ref seek(entries,i);
                entry.Uri = uri;
                entry.Hash = uri.Hash;
                entry.Name = uri.Name;
            }
            return entries.Sort().Resequence();        
        }        


    }
}