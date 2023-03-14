//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract record class EcmaDependency
    {
        [Render(64)]
        public ClrAssemblyName Source;

        [Render(16)]
        public AssemblyVersion SourceVersion;        

        [Render(16)]
        public EcmaDependencyKind DependencyKind;
    }        

    public abstract record class EcmaDependency<D> : EcmaDependency, IComparable<D>
        where D : EcmaDependency<D>
    {
        public abstract int CompareTo(D src);
    }    
}