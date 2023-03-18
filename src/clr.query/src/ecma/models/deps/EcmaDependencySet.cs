//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public record class EcmaDependencySet
    {        
        public ClrAssemblyName Source;

        public AssemblyVersion SourceVersion;        

        public ReadOnlySeq<ManagedDependency> ManagedDependencies;

        public ReadOnlySeq<NativeDependency> NativeDependencies;
    }
}