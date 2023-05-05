//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential, Pack = 1)]
    public record struct EcmaTypeDef : IComparable<EcmaTypeDef>
    {
        const string TableId = "ecma.types";

        [Render(16)]            
        public EcmaToken Token;

        [Render(48)]            
        public AssemblyKey Assembly;

        [Render(48)]
        public @string Name;

        [Render(96)]
        public @string FullName;
        
        [Render(48)]
        public @string DeclaringType;

        [Render(48)]
        public @string Namespace;

        [Render(48)]
        public @string BaseName;

        [Render(1)]
        public TypeAttributes Attributes;

        public int CompareTo(EcmaTypeDef src)
        {
            var result = Assembly.CompareTo(src.Assembly);
            if(result == 0)
                result = FullName.CompareTo(src.FullName);
            return result;
        }
    }
}