//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class DevPacks : WfSvc<DevPacks>
    {
        public void NugetStage(DbArchive src)
        {
            stage(FilePacks.search(src, PackageKind.Nuget), Channel);
        }

        static ExecToken stage(ReadOnlySeq<FilePack> src, IWfChannel channel)
        {
            var dst = AppSettings.DevPacks().Scoped("nuget/incoming");
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
    }
}