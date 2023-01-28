//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    using static sys;

    sealed class QueryReceiver : FileQueries.Receiver<QueryReceiver>
    {
        Action<FileUri> Handler;
        
        public override void Matched(FileUri src)
        {
            Handler?.Invoke(src);
        }

        public QueryReceiver WithHandler(Action<FileUri> handler)
        {
            Handler = handler;
            return this;
        }
    }

    class ArchiveCmd : WfAppCmd<ArchiveCmd>
    {
        FileArchives FileArchives => Wf.FileArchives();

        [CmdOp("symlink")]
        void Link(CmdArgs args)
            => Archives.symlink(Channel, args);

        [CmdOp("zip")]
        void Zip(CmdArgs args)
            => Archives.zip(Channel, args);

        [CmdOp("copy")]
        void Copy(CmdArgs args)
            => Archives.copy(Channel, args);

        [CmdOp("files/index")]
        void FileQuery(CmdArgs args)
        {
            var buffer = new HashedFiles();
            var counter = 0u;
            var query = FileQueries.query(FS.dir(args[0]));
            var receiver = QueryReceiver.create(query, r => r.WithHandler(Handler));
            var searching = Channel.Running($"Running file search over {query.Root}");
            void Handler(FileUri src)
            {
                buffer.Include(src);

                if(sys.inc(ref counter) % 1000 == 0)
                    Channel.Babble($"Found {counter} files");
            }
            
            receiver.Run(Channel);
            Channel.Ran(searching, $"Matched {counter} files in {query.Root}");
            var indexing = Channel.Running($"Indexing {counter} files");
            var index = buffer.Index();
            Channel.Ran(indexing,"Created index");
            var duplicates = index.Duplicates();
            iter(duplicates, d => {
                Channel.Row($"duplicates {d.Key}:");
                iter(d.Value, file => Channel.Row($"    {file.Path}"));
            });
        }

        [CmdOp("files")]
        void CatalogFiles(CmdArgs args)
            => Archives.catalog(Channel, args);

        [CmdOp("nuget/pkg")]
        void NugetFiles(CmdArgs args)
            => Archives.nupkg(Channel, args);

        [CmdOp("archives/injest")]
        void InjestFiles(CmdArgs args)
            => FileArchives.Injest(Archives.archive(FS.dir(args[0])), AppDb.Catalogs().Scoped("files"));

        [CmdOp("nuget/stage")]
        void DevPack(CmdArgs args)
            => DevPacks.stage(Channel, PackageKind.Nuget, FS.dir(arg(args,0)));
    }
}