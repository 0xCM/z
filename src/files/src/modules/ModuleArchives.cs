//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{    
    public class ModuleArchives : Channeled<ModuleArchives>
    {        
        public ModuleMap Map(IDbArchive src, bool recursive = false)
        {
            var running = Channel.Running($"Mapping modules from {src.Root}");
            var map = new ModuleMap(Channel, AssemblyMapped, NativeMapped);            
            map.Include(src, recursive);
            var desc = map.Modules.Map(x => x.Describe()).Resequence();
            var dst = Settings.DbRoot().Scoped("modules/mapped").Path($"index.{Process.GetCurrentProcess().Id}", FileKind.Csv);
            Channel.TableEmit(desc, dst);
            Channel.Ran(running);
            return map;
        }

        void AssemblyMapped(MappedAssembly src)
        {
            Channel.Status($"Mapped managed module {src.Path}");
        }

        void NativeMapped(MappedModule src)
        {
            Channel.Status($"Mapped native module {src.Path}");
        }
    }
}