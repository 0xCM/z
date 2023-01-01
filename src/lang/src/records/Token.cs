//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Lang
{
    using static JsonValues;

    partial class Records
    {
        public sealed record class Token : JsonRecord<Token>
        {
            public JV<@string> Name;

            public JV<@string> Value;

            public Token()
            {
                Name = @string.Empty;
                Value = @string.Empty;
            }
        
            public Token(@string name, @string value)
            {
                Name = name;
                Value= value;
            }

            public static Token Empty => new();
        }
    }
}