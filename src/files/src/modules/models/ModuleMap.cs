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

        public ICollection<MappedModule> Modules => Data.Values;

        public void Dispose()
        {
            iter(Modules, x => x.Dispose());
        }

        public bool Find(MemoryAddress address, out MappedModule dst)
        {
            var found = false;
            dst = null;
            foreach(var module in Modules.AsParallel())
            {
                if(!found)
                    found = address >= module.BaseAddress && address <= module.LastAddress;                    
            }
            return found;        
        }

        public void Include(IDbArchive src, bool recurse = false)
        {
            iter(Archives.modules(src.Root, recurse).Members(), module => {
                if(module.IsManaged)
                {
                    try
                    {
                        IncludeAssembly(module);
                    }
                    catch(IOException)
                    {

                    }
                    catch(Exception e)
                    {
                        Channel.Error(e);
                    }
                }
                else
                {
                    try
                    {
                        IncludeNative(module);
                    }
                    catch(IOException)
                    {
                        
                    }
                    catch(Exception e)
                    {
                        Channel.Error(e);
                    }                        
                }
            }, true);
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
                var mapped = new MappedModule(sys.inc(ref Index), FileModuleKind.Native, MemoryFiles.map(src.Path), hash.FileHash.ContentHash);
                Data.TryAdd(mapped.Index, mapped);
                NativeMapped(mapped);
                
            }
            return result;
        }

        bool IncludeAssembly(BinaryModule src)
        {
            var hash = FS.hash(src.Path);
            var result = false;
            if(!HashCodes.Contains(hash.FileHash.ContentHash))
            {
                HashCodes.Add(hash.FileHash.ContentHash);
                var mapped = new MappedAssembly(sys.inc(ref Index), MemoryFiles.map(src.Path), hash.FileHash.ContentHash);
                Data.TryAdd(mapped.Index, mapped);
                AssemblyMapped(mapped);
            }
            return result;                
        }
    }
}