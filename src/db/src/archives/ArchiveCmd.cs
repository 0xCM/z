//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    using static sys;

    class ArchiveCmd : WfAppCmd<ArchiveCmd>
    {
        FileArchives FileArchives => Channel.Channeled<FileArchives>();

        public static void copy(IWfChannel channel, CmdArgs args)
            => copy(channel, FS.dir(args[0]), FS.dir(args[1]));
        
        public static Task<ExecToken> copy(IWfChannel channel, FolderPath src, FolderPath dst)
            => ProcExec.launch(channel, FS.path("robocopy.exe"), Cmd.args(src, dst, "/e"));

        [CmdOp("symlink")]
        void Link(CmdArgs args)
            => Archives.symlink(Channel, args);

        [CmdOp("zip")]
        void Zip(CmdArgs args)
            => Archives.zip(Channel, args);

        [CmdOp("copy")]
        void Copy(CmdArgs args)
            => copy(Channel, args);

        [CmdOp("files/kinds")]
        void FileKinds()
        {
            var src = Symbols.index<FileKind>();
            var parser = EnumParser<FileKind>.Service;
            iter(src.Storage, s => {
                if(!parser.Parse(s.Expr.Format(), out FileKind kind))
                {
                    Channel.Error(s.Expr);                    
                }
                else
                {
                    Channel.Row(kind);
                }

            });
        }

        [CmdOp("files/index")]
        void FileQuery(CmdArgs args)
        {
            var query = FileQueries.query(FS.dir(args[0]));
            var index = FS.index();
            var counter = 0u;
            void Handler(FilePath src)
            {
                if(index.Include(src) && src.FileKind() == FileKind.Dll)
                {
                    using var reader = src.BinaryReader();
                    Span<byte> buffer = stackalloc byte[1024];
                    var length = reader.Read(buffer);
                    if(length >= (0x3C + 4))
                    {
                        var sigloc = u32(slice(buffer,0x3C, 4));
                        if(sigloc + 4 <= 1024)
                        {
                            var sig = slice(buffer,sigloc, 4);
                            Channel.Row(
                                ((char)sig[0]).ToString() + ((char)sig[1]).ToString()
                                );
                        }
                    }
                }

                if(sys.inc(ref counter) % 1000 == 0)
                    Channel.Babble($"Indexed {counter} files");
            }

            var receiver = QueryReceiver.create(query, r => r.WithHandler(Handler));
            receiver.Run(Channel);
            var duplicates = index.Duplicates.Map(x => x.Value).SelectMany(x => x);
            var unique = index.Unique;
            Require.equal(counter, (uint)(unique.Count + duplicates.Length));

            Channel.Status($"Indexed {unique.Count} unique files with {duplicates.Length} duplicates");
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