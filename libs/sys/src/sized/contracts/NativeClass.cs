//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Classifies scalar types
    /// </summary>
    [SymSource("types")]
    public enum NativeClass : byte
    {
        [Symbol("")]
        None,

        [Symbol("b", "Designates a bit type")]
        B,

        [Symbol("u", "Designates an unsigned integer type")]
        U,

        [Symbol("i", "Designates a signed integer type")]
        I,

        [Symbol("f", "Designates a floating point type")]
        F,

        [Symbol("c", "Designates a character type")]
        C,
    }
}