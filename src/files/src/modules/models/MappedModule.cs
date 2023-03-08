//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class MappedModule : IDisposable
    {
        public readonly uint Index;

        public readonly FilePath Path;

        readonly SegRef Memory;

        public readonly FileHash FileHash;

        readonly MemoryFile File;
        
        public readonly FileModuleKind ModuleKind;

        MappedModule()
        {
            Index = 0;
            Path = FilePath.Empty;
            Memory = SegRef.Empty;
            FileHash = default;
        }

        public MappedModule(uint index, FileModuleKind kind, MemoryFile file, FileHash hash)
        {
            Index = index;
            ModuleKind = kind;
            Path = file.Path;
            Memory = new (file.BaseAddress, file.FileSize);
            FileHash = hash;                
            File = file;
        }

        public MappedModuleInfo Describe()
        {
            var dst = new MappedModuleInfo();
            dst.Seq = Index;
            dst.ModuleKind = ModuleKind;
            dst.Path = Path;
            dst.BaseAddress = Memory.BaseAddress;
            dst.Size = Memory.Size;
            dst.FileHash = FileHash;
            return dst;
        }

        [MethodImpl(Inline)]
        public AddressSpace Addresses()
            => new AddressSpace(Index, new (BaseAddress, FileSize));

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Memory.Address == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Memory.Address != 0;
        }

        public MemoryAddress BaseAddress
        {
            [MethodImpl(Inline)]
            get => Memory.Address;
        }

        public MemoryAddress LastAddress
        {
            [MethodImpl(Inline)]
            get => BaseAddress + Memory.Size;
        }

        public ByteSize FileSize
        {
            [MethodImpl(Inline)]
            get => Memory.Size;
        }

        public ReadOnlySpan<byte> Data
        {
            [MethodImpl(Inline)]
            get => sys.cover<byte>(BaseAddress, FileSize);
        }

        public void Dispose()
            => File?.Dispose();

        public static MappedModule Empty => new();

    }
}