//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct AssemblyFile
    {
        public readonly FilePath AssemblyPath;

        public readonly AssemblyName AssemblyName;
        
        public AssemblyFile()
        {
            AssemblyPath = FileUri.Empty;
            AssemblyName = new AssemblyName();
        }

        public AssemblyFile(FilePath path, AssemblyName name)
        {
            AssemblyPath = path;
            AssemblyName = name;
        }

        public Assembly Load()
            => Assembly.LoadFrom(AssemblyPath.Format());

        public string Format()
            => AssemblyPath.Format();

        public override string ToString()
            => Format();
            
        public static AssemblyFile Empty => new AssemblyFile();
    }
}