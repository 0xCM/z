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
                dst = new AppCmdSpec(name, Cmd.args(_args));
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

        static FileUri next(IWfChannel channel, IEnumerator<FileUri> src, out bool @continue)
        {
            var file = FileUri.Empty;            
            try
            {
                @continue = src.MoveNext();
                file = src.Current;
            }
            catch(Exception e)
            {
                channel.Babble($"Trapped {e}");
                @continue = true;
            }
            return file;
        }

        static IEnumerable<FileUri> query(IWfChannel channel, CmdArgs args)
        {
            var src = FS.dir(args[0]);
            var files = default(IEnumerable<FileUri>);
            var it = default(IEnumerator<FileUri>);
            if(args.Count > 1)
            {
                var kinds = args.Values().Span().Slice(1).Select(x => FS.kind(FS.ext(x))).Where(x => x!=0);
                iter(kinds, kind => channel.Babble(kind));
                files = DbArchive.enumerate(src,true,kinds); 
            }
            else
            {
                files = DbArchive.enumerate(src,"*.*", true);
            }            

            it = files.GetEnumerator();
            var file = next(channel,it, out var @continue);
            while(@continue)
            {
                if(file.IsNonEmpty)
                    yield return file;
                
                if(!@continue)
                    break;
                file = next(channel,it, out @continue);
            }
        }

        public static void files(IWfChannel channel, CmdArgs args)
        {
            var files = bag<FileUri>();
            var table = FilePath.Empty;
            var list = FilePath.Empty;
            var name = Archives.identifier(FS.dir(args[0]));
            var src = query(channel,args);
            var counter = 0u;

            string msg()
                => $"Collected {counter} files";

            iter(src, file => {
                files.Add(file);
                counter++;
                if(counter % 1024 == 0)
                    channel.Babble(msg());
            }, true);
            channel.Babble(msg());

            var collected = files.ToSeq();
            var listing = Archives.listing(collected.View);
            
            if(args.Count >=2)    
            {
                table = FS.dir(args[1]) + Tables.filename<ListedFile>(name);
                list = FS.dir(args[1]) + FS.file(name,FileKind.List);
            }
            else
            {
                table = AppDb.Catalogs("files").Table<ListedFile>(name);
                list = AppDb.Catalogs("files").Path(name, FileKind.List);
            }

            channel.TableEmit(listing, table);
            var flow = channel.EmittingFile(list);
            using var writer = list.Utf8Writer();
            counter =0;
            foreach(var file in files)
            {
                writer.AppendLine(file.ToFilePath().ToUri());
                counter++;
            }
            channel.EmittedFile(flow, counter);
        }
    }
}