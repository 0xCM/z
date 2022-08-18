//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Classifies the sign aspect of a 64-bit value
    /// </summary>
    [SymSource(numeric)]
    public enum Sign64Kind : ulong
    {
        Unsigned = 0,

        Signed = ulong.MaxValue ^ long.MaxValue
    }
}