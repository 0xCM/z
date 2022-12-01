//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class DevPacks
    {
        static AppSettings Settings => AppSettings.Default;

        public static IDbArchive Root()
            => Settings.PkgRoot().Scoped("devpacks");

        public IDbArchive ZPack()
            => Root().Scoped("zpack");

        public static void search(IWfChannel channel, CmdArgs args)
        {
            var src = FS.dir(args[0]);
            var packs = search(src, PackageKind.Nuget);
            iter(packs, p => channel.Write(p));
        }

        public static void stage(IWfChannel channel, CmdArgs args)
            => stage(channel, PackageKind.Nuget, FS.dir(args[0]));

        public static void stage(IWfChannel channel, PackageKind kind, FolderPath src)
            => stage(channel, kind, search(src, kind));

        static ExecToken stage(IWfChannel channel, PackageKind kind, ReadOnlySeq<FilePack> src)
        {
            var dst = stage(kind);
            var running = channel.Running($"Updating {dst.Root}");
            var counter = 0u;
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var pack = ref src[i];
                var path = pack.Location.ToFilePath().CopyTo(dst.Root);
                if(path.IsNonEmpty)
                {
                    channel.Babble($"{pack} -> {path.ToUri()}");
                    counter++;
                }
                else
                    channel.Error($"The operation to copy {pack} to {dst.Root} failed");
            }

            return channel.Ran(running,$"Copied {counter} files to {dst.Root}");
        }

        public static ReadOnlySeq<FilePack> search(FolderPath src, PackageKind kind)
        {
            var files = src.EnumerateFiles(filekind(kind).Ext(), true).ToSeq();
            var count = files.Count;
            var dst = alloc<FilePack>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var file = ref files[i];
                var uri = $"file://{file.Name.Text}";
                seek(dst,i) = define(new FileUri(uri));
            }
            return dst;
        }

        public static string scope(PackageKind kind)
            => kind switch {
                PackageKind.Nuget => "nuget",
                PackageKind.Msi => "msi",
                PackageKind.Zip => "zip",
                _ => EmptyString
            };

        public static IDbArchive stage(PackageKind kind)
            => Settings.PkgRoot().Scoped(scope(kind));

        public static FileKind filekind(PackageKind src)
            => src switch{
                PackageKind.Zip => FileKind.Zip,
                PackageKind.Nuget => FileKind.Nuget,
                PackageKind.Msi => FileKind.Msi,
                _ => FileKind.None
            };

        public static FilePack define(FileUri src)
        {
            var kind = src.Ext().FileKind();
            var dst = default(FilePack);
            switch(kind)
            {
                case FileKind.Zip:
                    dst = new ZipFile(src);
                break;
                case FileKind.Msi:
                    dst = new MsiFile(src);
                break;
                case FileKind.Nuget:
                    dst = new NugetFile(src);
                break;
                default:
                    sys.@throw($"File type for '{src}' unknown");
                break;
            }
            return dst;
        }


    }
}