//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    using static sys;

    public class ModuleMap : IDisposable
    {
        static uint Index;

        readonly ConcurrentDictionary<uint,MappedModule> Data = new();

        readonly ConcurrentBag<Hash128> HashCodes = new();

        readonly IWfChannel Channel;
        
        readonly Action<MappedAssembly> AssemblyMapped;

        public ModuleMap(IWfChannel channel, Action<MappedAssembly> mapped)
        {
            Channel = channel;
            AssemblyMapped = mapped;
        }

        public void Dispose()
        {
            iter(Data.Values, x => x.Dispose());
        }

        public void Include(IEnumerable<FolderPath> src)
        {
            iter(src, dir => {
                var modules = Archives.modules(dir).Members();
                iter(modules, module => {
                    if(module.IsManaged)
                    {
                        try
                        {
                            IncludeAssembly(module);
                        }
                        catch(Exception e)
                        {
                            Channel.Error(e);
                        }
                    }
                }, true);

            });
        }

        bool IncludeAssembly(BinaryModule src)
        {
            var hash = FS.hash(src.Path);
            var result = false;
            if(HashCodes.Contains(hash))
            {
                Channel.Babble($"Duplicate skipped {src.Path}");
            }
            else
            {
                HashCodes.Add(hash);
                var mapped = new MappedAssembly(sys.inc(ref Index), MemoryFiles.map(src.Path), hash);
                Data.TryAdd(mapped.Index, mapped);
                AssemblyMapped(mapped);
            }
            return result;                
        }
    }
}