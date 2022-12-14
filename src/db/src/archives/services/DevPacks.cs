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

        public static void stage(IWfChannel channel, CmdArgs args)
            => stage(channel, PackageKind.Nuget, FS.dir(args[0]));

        public static void stage(IWfChannel channel, PackageKind kind, FolderPath src)
            => stage(channel, kind, Archives.packages(src, kind));

        static ExecToken stage(IWfChannel channel, PackageKind kind, ReadOnlySeq<Package> src)
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

        public static string scope(PackageKind kind)
            => kind switch {
                PackageKind.Nuget => "nuget",
                PackageKind.Msi => "msi",
                PackageKind.Zip => "zip",
                _ => EmptyString
            };

        public static IDbArchive stage(PackageKind kind)
            => Settings.PkgRoot().Scoped(scope(kind));

    }
}