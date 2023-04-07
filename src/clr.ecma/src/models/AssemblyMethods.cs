//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class AssemblyMethods : ReadOnlySeq<AssemblyMethods, EcmaMethodInfo>
    {
        public readonly AssemblyFile File;

        public AssemblyMethods()                    
        {
            File = AssemblyFile.Empty;
        }

        public AssemblyMethods(AssemblyFile file, EcmaMethodInfo[] src)
            : base(src)
        {
            File = file;            
        }

        public VersionedName AssemblyName 
            => File.Identifier;
    }        
}