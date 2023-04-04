//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract record class EcmaDependency : Dependency
    {
        [Render(64)]
        public ClrAssemblyName Source;

        [Render(16)]
        public AssemblyVersion SourceVersion;        

        [Render(16)]
        public EcmaDependencyKind DependencyKind;
    }


}