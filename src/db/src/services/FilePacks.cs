//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    
    public class FilePacks
    {
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