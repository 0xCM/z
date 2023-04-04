//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public partial class EcmaModels
    {
        public sealed record class Method
        {
            public MemberKey Key;

            public EcmaMethodDef Def;

            public Method()
            {

            }

            public Method(MemberKey key, EcmaMethodDef def)
            {
                Key = key;
                Def = def;
            }
        }

        public sealed class Methods : ReadOnlySeq<Methods, Method>
        {
            public AssemblyKey AssemblyKey;

            public FilePath AssemblyPath;

            public VersionedName AssemblyName
                => AssemblyKey.Identifier;

            public Methods()                    
            {
                AssemblyKey = AssemblyKey.Empty;
            }

            public Methods(AssemblyKey key, FilePath path, params Method[] src)
                : base(src)
            {
                AssemblyPath = path;
                AssemblyKey = key;
            }
        }        
    }

}