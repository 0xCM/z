//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO.Compression;

    using static sys;

    
    public sealed class PkgArchives : Stateless<PkgArchives>
    {
        public static ZipFile zip(FolderPath src, FilePath dst)
        {
            System.IO.Compression.ZipFile.CreateFromDirectory(src.Format(), dst.Format(), CompressionLevel.Fastest, true);
            return new ZipFile(dst);
        }

        public static Task<ExecToken> zip(IWfChannel channel, FolderPath src, FilePath dst)
        {
            ExecToken run()
            {
                var msg = $"{src} -> {dst}";
                var running = channel.Running(msg);
                zip(src, dst);
                return channel.Ran(running, msg); 
            }
            return start(run);
        }
 
        public static Task<ExecToken> unzip(IWfChannel channel, FilePath src, FolderPath dst)
        {
            ExecToken Run()
            {
                var running = channel.Running($"Extracting {src} to {dst}");
                using (var stream = src.Stream())
                {
                    var zip = new ZipArchive(stream);
                    foreach (var entry in zip.Entries)
                    {
                        var extractedFilePath = (dst + FS.file(entry.FullName)).CreateParentIfMissing();
                        using (var zfs = entry.Open())
                        {
                            using (var extractedFileStream = extractedFilePath.Stream())
                                zfs.CopyTo(extractedFileStream);
                        }
                    }
                }
                return channel.Ran(running, $"Extracted {src} to {dst}");
            }
            return start(Run);
        }

        public static Task<ExecToken> nupkg(IWfChannel channel, FolderPath src)
        {
            ExecToken Run()
            {
                var dst = EnvDb.Nested("nuget", src);
                var buffer = sys.bag<Package>();
                iter(packages(src, PackageKind.Nuget), pkg => buffer.Add(pkg), true);                
                return channel.TableEmit(buffer.Array().Sort(), dst.Path("nugetpkg", FileKind.Csv));
            }
            return sys.start(Run);
        }

        public static string name(PackageKind kind)
            => kind switch {
                PackageKind.Nuget => "nuget",
                PackageKind.Msi => "msi",
                PackageKind.Zip => "zip",
                _ => EmptyString
            };

        public static FileKind filekind(PackageKind src)
            => src switch{
                PackageKind.Zip => FileKind.Zip,
                PackageKind.Nuget => FileKind.Nuget,
                PackageKind.Msi => FileKind.Msi,
                _ => FileKind.None
            };

        public static ReadOnlySeq<Package> packages(FolderPath src, PackageKind kind)
        {
            var files = src.EnumerateFiles(filekind(kind).Ext(), true).ToSeq();
            var count = files.Count;
            var dst = alloc<Package>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var file = ref files[i];
                var uri = $"file://{file.Name.Text}";
                seek(dst,i) = package(new FileUri(uri));
            }
            return dst;
        }

        public static Package package(FilePath src)
        {
            var kind = src.FileKind();
            var dst = default(Package);
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