//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Settings
    {
        public static string json(Setting src)
            => string.Concat(RP.enquote(src.Name), Chars.Colon, Chars.Space, src.ValueText.Enquote());
    }
}