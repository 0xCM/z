//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableName)]
    public record struct EcmaPinvoke : IComparable<EcmaPinvoke>
    {
        const string TableName = "ecma.pinvoke";

        [Render(12)]
        public EcmaToken Token;

        [Render(48)]            
        public AssemblyKey Assembly;

        [Render(48)]
        public string MethodName;

        [Render(32)]
        public EcmaMethodImport MethodImport;

        public int CompareTo(EcmaPinvoke src)
        {
            var result = Assembly.CompareTo(src.Assembly);
            if(result == 0)
            {
                result = MethodImport.CompareTo(src.MethodImport);
                if(result == 0)
                    result = Token.CompareTo(src.Token);
            }
            return result;
        }
    }   
}