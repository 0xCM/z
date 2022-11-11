//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using K = TextEncodingKind;

    public readonly struct Utf8Points : ITextEncodingKind<Utf8Points>
    {
        public static Utf8Points Value => default;

        public K Kind => K.Utf8;
    }
}