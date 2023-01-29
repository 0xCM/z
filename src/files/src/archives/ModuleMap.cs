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

        readonly Action<MappedModule> NativeMapped;

        public ModuleMap(IWfChannel channel, Action<MappedAssembly> assembly, Action<MappedModule> native)
        {
            Channel = channel;
            AssemblyMapped = assembly;
            NativeMapped = native;
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
                    else
                    {
                        // try
                        // {
                        //     IncludeNative(module);
                        // }
                        // catch(Exception e)
                        // {
                        //     Channel.Error(e);
                        // }
                        
                    }
                }, true);

            });
        }

        bool IncludeNative(BinaryModule src)
        {
            var hash = FS.hash(src.Path);
            var result = false;
            if(HashCodes.Contains(hash.FileHash.ContentHash))
            {
                Channel.Babble($"Duplicate skipped {src.Path}");
            }
            else
            {
                HashCodes.Add(hash.FileHash.ContentHash);
                var mapped = new MappedModule(sys.inc(ref Index), MemoryFiles.map(src.Path), hash.FileHash);
                Data.TryAdd(mapped.Index, mapped);
                NativeMapped(mapped);
                
            }
            return result;

        }
        bool IncludeAssembly(BinaryModule src)
        {
            var hash = FS.hash(src.Path);
            var result = false;
            if(HashCodes.Contains(hash.FileHash.ContentHash))
            {
                Channel.Babble($"Duplicate skipped {src.Path}");
            }
            else
            {
                HashCodes.Add(hash.FileHash.ContentHash);
                var mapped = new MappedAssembly(sys.inc(ref Index), MemoryFiles.map(src.Path), hash.FileHash);
                Data.TryAdd(mapped.Index, mapped);
                AssemblyMapped(mapped);
            }
            return result;                
        }
    }
}