//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [SymSource(chars)]
    public enum TextEncodingKind : byte
    {
        None,

        Asci,

        Utf8,

        Unicode,

        Utf32,
    }
}