//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public record class EcmaMember : IComparable<EcmaMember>
    {        
        [Render(12)]
        public EcmaToken Token;

        [Render(12)]
        public EcmaMemberKind Kind;

        [Render(48)]            
        public VersionedName AssemblyName;

        [Render(24)]
        public @string Namespace;

        [Render(24)]
        public @string DeclaringType;

        [Render(24)]
        public @string Name;

        public int CompareTo(EcmaMember src)
        {
            var result = AssemblyName.CompareTo(src.AssemblyName);
            if(result == 0)
            {
                if(result == 0)
                    result = ((byte)Kind).CompareTo((byte)src.Kind);
                if(result == 0)
                {
                    result = Namespace.CompareTo(src.Namespace);
                    if(result == 0)            
                    {
                        Namespace.CompareTo(src.Namespace);
                        if(result == 0)
                            DeclaringType.CompareTo(src.DeclaringType);
                            if(result == 0)
                                result = Name.CompareTo(src.Name);
                    }
                }
            }
            return result;
        }       
    }
}