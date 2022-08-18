//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    /// <summary>
    /// Specifies an avx512 rounding mode
    /// </summary>
    /// <remarks>
    /// https://docs.microsoft.com/en-us/cpp/assembler/masm/instruction-format?view=msvc-170
    /// </remarks>
    [SymSource("asm")]
    public enum RoundingMode : byte
    {
        [Symbol("")]
        None,

        [Symbol("{sae}","Suppress all exceptions (no rounding needed)")]
        Sae,

        [Symbol("{rn-sae}","Round to nearest, ties to even, suppress all exceptions")]
        RnSae,

        [Symbol("{rd-sae}","Round down (toward negative infinity), suppress all exceptions")]
        RdSae,

        [Symbol("{ru-sae}","Round up (toward positive infinity), suppress all exception")]
        RuSae,

        [Symbol("{rz-sae}","Round toward zero, suppress all exception")]
        RzSae,
    }
}