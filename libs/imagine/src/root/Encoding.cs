//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using TE = TextEncodingKind;

    partial struct Root
    {
        public const TE UTF16 = TE.Unicode;

        public const TE ASCI = TE.Asci;

        public const TE UTF8 = TE.Utf8;
    }
}