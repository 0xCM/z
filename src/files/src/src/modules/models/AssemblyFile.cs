//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public record class AssemblyFile : IBinaryModule<AssemblyFile>, IComparable<AssemblyFile>
    {
        public FilePath Path {get;}

        public FileModuleKind ModuleKind {get;}

        public readonly ClrAssemblyName AssemblyName;
        
        public readonly AssemblyVersion Version;

        public AssemblyFile()
        {
            Path = FileUri.Empty;
            AssemblyName = ClrAssemblyName.Empty;
            ModuleKind = 0;
            Version = default;
        }

        public AssemblyFile(FilePath path, AssemblyName name, FileModuleKind? kind = null)
        {
            Path = path;
            AssemblyName = name;
            ModuleKind = kind ?? (path.FileKind() == FileKind.Exe ? FileModuleKind.Exe : FileModuleKind.Dll);
            Version = name.Version;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Path.IsEmpty && AssemblyName.IsEmpty;
        }
        
        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Path.IsNonEmpty || AssemblyName.IsNonEmpty;
        }

        public Assembly Load()
            => Assembly.LoadFrom(Path.Format());

        public string Format()
            => Path.IsNonEmpty ? Path.Format() : $"{AssemblyName}.{Version}";

        public override string ToString()
            => Format();
            
        public int CompareTo(AssemblyFile src)
        {
            var result = AssemblyName.CompareTo(src.AssemblyName);
            if(result == 0)
                result = Path.CompareTo(src.Path);
            return result;
        }

        public static AssemblyFile Empty => new AssemblyFile();
    }
}