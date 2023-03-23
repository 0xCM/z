//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public enum EcmaMemberKind : byte
    {
        None,

        Class,

        Field,

        Method,

        Property,
    }
    public record class EcmaMember : IComparable<EcmaMember>
    {        
        [Render(12)]
        public EcmaToken Token;

        [Render(12)]
        public EcmaMemberKind Kind;

        [Render(48)]            
        public AssemblyKey Assembly;

        [Render(24)]
        public @string Namespace;

        [Render(24)]
        public @string DeclaringType;

        [Render(24)]
        public @string Name;

        public int CompareTo(EcmaMember src)
        {
            var result = Assembly.CompareTo(src.Assembly);
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