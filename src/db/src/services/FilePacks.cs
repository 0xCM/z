//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    
    public class FilePacks
    {
        static AppSettings Settings => AppSettings.Default;

        public static void stage(IWfChannel channel, PackageKind kind, FolderPath src)
            => stage(channel, kind, search(src,kind));

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
                    dst = zip(src);
                break;
                case FileKind.Msi:
                    dst = msi(src);
                break;
                case FileKind.Nuget:
                    dst = nuget(src);
                break;
                default:
                    sys.@throw($"File type for '{src}' unknown");
                break;
            }
            return dst;
        }

        public static FilePack zip(FileUri src)
            => new Zip(src);

        public static FilePack nuget(FileUri src)
            => new Nuget(src);

        public static FilePack msi(FileUri src)
            => new Msi(src);

        public sealed class Zip : FilePack<Zip>
        {
            public Zip(FileUri src)
                : base(src, PackageKind.Zip)
            {

            }

            public override FileKind FileKind => FileKind.Zip;
        }

        public sealed class Nuget : FilePack<Nuget>
        {
            public Nuget(FileUri src)
                : base(src, PackageKind.Nuget)
            {

            }

            public override FileKind FileKind => FileKind.Nuget;
        }

        public sealed class Msi : FilePack<Msi>
        {
            public Msi(FileUri src)
                : base(src, PackageKind.Msi)
            {

            }

            public override FileKind FileKind => FileKind.Msi;
        }
    }
}