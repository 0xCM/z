//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [SymSource("lang")]
    public enum LanguageCode : uint
    {
        [Symbol("")]
        None,

        [Symbol("cs")]
        Cs,

        [Symbol("ts")]
        Ts,

        [Symbol("c")]
        C,

        [Symbol("cpp")]
        Cpp,
    }
}