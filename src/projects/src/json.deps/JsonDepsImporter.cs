//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class JsonDepsImporter : Channeled<JsonDepsImporter>
    {
        public Task<ExecToken> Import(FolderPath src, FolderPath dst)
        {
            ExecToken Import()
            {
                
                try
                {
                    var counter = 0u;
                    var importing = Channel.Running($"Importing jsondeps from {src}");
                    var paths = src.DbArchive().Files(FileKind.JsonDeps, true);
                    iter(paths, path => {
                    var flow = Channel.Running($"Importing {path}");
                    var deps = JsonDeps.parse(path);
                    var libs = deps.Libs();
                    iter(libs, lib => {

                    });
                    counter++;
                    Channel.Ran(flow, $"Imported {path}");

                    }, true);

                    return Channel.Ran(importing, $"Imported {counter} dependency files from {src} to {dst}");
                }
                catch(Exception e)
                {
                    Channel.Error(e);
                    return ExecToken.Empty;
                }
            }
            return sys.start(Import);
        }
    }
}