//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct AssemblyFile : IBinaryModule<AssemblyFile>, IComparable<AssemblyFile>
    {
        public FilePath Path {get;}

        public FileModuleKind ModuleKind {get;}

        public readonly ClrAssemblyName Name;
        
        public readonly AssemblyVersion Version;

        public AssemblyFile()
        {
            Path = FileUri.Empty;
            Name = ClrAssemblyName.Empty;
            ModuleKind = 0;
            Version = default;
        }

        public AssemblyFile(FilePath path, AssemblyName name)
        {
            Path = path;
            Name = name;
            ModuleKind = FileModuleKind.ManagedDll;
            Version = name.Version;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Path.IsEmpty && Name.IsEmpty;
        }
        
        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Path.IsNonEmpty || Name.IsNonEmpty;
        }

        public Assembly Load()
            => Assembly.LoadFrom(Path.Format());

        public string Format()
            => Path.IsNonEmpty ? Path.Format() : $"{Name}.{Version}";

        public override string ToString()
            => Format();
            
        public int CompareTo(AssemblyFile src)
        {
            var result = Name.CompareTo(src.Name);
            if(result == 0)
                result = Path.CompareTo(src.Path);
            return result;
        }

        public static AssemblyFile Empty => new AssemblyFile();
    }
}