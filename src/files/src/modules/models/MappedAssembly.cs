//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class MappedAssembly : MappedModule
    {
        public static MappedAssembly map(FilePath src)
            => new MappedAssembly(0, MemoryFiles.map(src));
        
        public MappedAssembly(uint index, MemoryFile file)
            : base(index, FileModuleKind.Managed, file)
        {

        }
        public MappedAssembly(uint index, MemoryFile file, Hash128 hash)
            : base(index, FileModuleKind.Managed, file, hash)
        {

        }
    }
}