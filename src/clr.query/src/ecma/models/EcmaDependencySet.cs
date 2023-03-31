//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{    
    public record class EcmaDependencySet : IComparable<EcmaDependencySet>
    {        
        public ClrAssemblyName SourceName;

        public FileUri SourcePath;

        public AssemblyVersion SourceVersion;        

        public ReadOnlySeq<ManagedDependency> ManagedDependencies;

        public ReadOnlySeq<NativeDependency> NativeDependencies;

        public int CompareTo(EcmaDependencySet src)
        {
            var result = SourceName.CompareTo(src.SourceName);
            if(result == 0)
                result = SourcePath.CompareTo(src.SourcePath);
            return result;            
        }
    }
}