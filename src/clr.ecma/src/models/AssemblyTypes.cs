//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class AssemblyTypes : ReadOnlySeq<AssemblyTypes, EcmaTypeDef>
    {
        public readonly AssemblyFile File;

        public AssemblyTypes()
        {
            File = AssemblyFile.Empty;
        }

        public AssemblyTypes(AssemblyFile file, params EcmaTypeDef[] src)
            : base(src)
        {
            File = file;
        }

        public VersionedName AssemblyName 
            => File.Identifier;
    }
}