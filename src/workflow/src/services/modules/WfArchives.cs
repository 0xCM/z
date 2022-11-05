//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using static WfArchives.CommandNames;

    [WfModule]
    public class WfArchives : WfModule<WfArchives>
    {
        public class CommandNames 
        {
            public const string FilesGather = "files/gather";

            public const string FilesCopy = "files/copy";

            public const string FilesPack = "files/pack";
        }

        public static Task<ListedFiles> catalog(IWfChannel channel, FolderPath src, FolderPath dst)
        {
            throw new NotImplementedException();

        }

        public static ListedFiles catalog(IWfChannel channel, CmdArgs args)
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
                list = FS.dir(args[1]) + FS.file(name, FileKind.List);
            }
            else
            {
                table = AppDb.Service.Catalogs("files").Table<ListedFile>(name);
                list = AppDb.Service.Catalogs("files").Path(name, FileKind.List);
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
            return listing;
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

        [Cmd(FilesCopy)]
        public record struct CopyFiles(FolderPath Source, FolderPath Target) 
            : IWfFlow<CopyFiles,FolderPath,FolderPath> {}

        [Cmd(FilesPack)]
        public record struct PackFolder(FolderPath Source, FileUri Target) 
            : IWfFlow<PackFolder,FolderPath,FileUri> {}

        [Cmd(FilesGather)]
        public record struct GatherFiles(FolderPath Source, FolderPath Target, FileExt Ext) 
            : IWfFlow<GatherFiles,FolderPath,FolderPath> {}

        [MethodImpl(Inline), CmdFx(FilesCopy)]
        public static CopyFiles copy(FolderPath src, FolderPath dst)
            => new (src,dst);        

        [MethodImpl(Inline), CmdFx(FilesPack)]
        public static PackFolder pack(FolderPath src, FileUri dst)
            => new (src,dst);        

        [MethodImpl(Inline), CmdFx]
        public static GatherFiles gather(FolderPath src, FolderPath dst, FileExt ext)
            => new (src,dst,ext);

        [CmdOp(FilesGather)]
        public Task<ExecToken> Gather(IWfChannel channel, CmdArgs args)
        {            
            var cmd = gather(FS.dir(args[0]), FS.dir(args[1]), FileKind.Nuget.Ext());
            return Exec(channel, cmd);
        }

        Task<ExecToken> Exec(IWfChannel channel, GatherFiles cmd)
        {
            ExecToken exec()
            {
                var flow = channel.Running(cmd);
                var paths = cmd.Source.Files(cmd.Ext,true);
                iter(paths, src => {
                    var dst = src.CopyTo(cmd.Target);
                    channel.Babble($"Copied {src} -> {dst}");
                });
                return channel.Ran(flow);
            }

            return start(exec);            
        }

        protected override Task<ExecToken> Start<C>(C cmd) 
        {
            throw new NotImplementedException();
        }
    }
}
