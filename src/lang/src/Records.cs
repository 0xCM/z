//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Lang
{
    using static JsonValues;

    [ApiHost]
    public partial class Records
    {
        public static Token token(@string name, @string value)
            => new (name,value);
    }
}