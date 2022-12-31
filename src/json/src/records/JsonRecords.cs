//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static JsonValues;

    public sealed record class TokenRecord : JsonRecord<TokenRecord>
    {
        public JV<@string> Name;

        public JV<@string> Value;

        public TokenRecord()
        {
            Name = @string.Empty;
            Value = @string.Empty;
        }
    
        public TokenRecord(@string name, @string value)
        {
            Name = name;
            Value= value;
        }

        public static TokenRecord Empty => new();
    }
}