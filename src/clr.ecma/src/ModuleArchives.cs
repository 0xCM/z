//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{    
    public class ModuleArchives : Channeled<ModuleArchives>
    {
        public ModuleMap Map(IDbArchive src)
        {
            var running = Channel.Running($"Mapping modules from {src.Root}");
            var map = new ModuleMap(Channel, AssemblyMapped, NativeMapped);            
            map.Include(src);
            var desc = map.Modules.Map(x => x.Describe()).Resequence();
            var dst = Settings.DbRoot().Scoped("modules/mapped").Path($"index.{Process.GetCurrentProcess().Id}", FileKind.Csv);
            Channel.TableEmit(desc, dst);
            Channel.Ran(running);
            return map;
        }


        void AssemblyMapped(MappedAssembly src)
        {
            var reader = src.MetadataReader();
            var name = reader.AssemblyName().SimpleName();
            Channel.Status($"Mapped managed module {src.Path}");
            //Channel.Row(string.Format("{0,-8} | {1,-16} | {2,-16} | {3,-12} | {4,-56} | {5}", src.Index, src.ModuleKind, src.BaseAddress, src.FileSize, src.FileHash, name, FlairKind.StatusData));
        }

        void NativeMapped(MappedModule src)
        {
            Channel.Status($"Mapped native module {src.Path}");

            //Channel.Row(string.Format("{0,-8} | {1,-16} | {2,-16} | {3,-12} | {4,-56} | {5}", src.Index, src.ModuleKind, src.BaseAddress, src.FileSize, src.FileHash, src.Path, FlairKind.StatusData));
        }
    }
}