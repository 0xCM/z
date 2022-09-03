//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines rng classifiers
    /// </summary>
    public enum RngKind
    {
        None = 0,

        /// <summary>
        /// A crypto-sourced nondeterministic generator
        /// </summary>
        EntropicCrypto = 1,

        /// <summary>
        /// A 32-bit PCG generator
        /// </summary>
        Pcg32 = 2,

        /// <summary>
        /// A suite of 32-bit PCG generators
        /// </summary>
        Pcg32Suite = 3,

        /// <summary>
        /// A 64-bit PCG generator
        /// </summary>
        Pcg64 = 4,

        /// <summary>
        /// A suite of 64-bit PCG generators
        /// </summary>
        Pcg64Suite = 5,

        /// <summary>
        /// A 64-bit SplitMix generator
        /// </summary>
        SplitMix64 = 6,

        /// <summary>
        /// A 16-bit WyHash generator
        /// </summary>
        WyHash16 = 7,

        /// <summary>
        /// A 64-bit WyHash generator
        /// </summary>
        WyHash64 = 8,

        /// <summary>
        /// A suite of 64-bit WyHash generators
        /// </summary>
        WyHash64Suite = 9,

        /// <summary>
        /// An xorshift generator with 128 bits of state
        /// </summary>
        XOrShift128 = 10,

        /// <summary>
        /// An xorshift generator with 256 bits of state
        /// </summary>
        XOrShift256 = 11,

        /// <summary>
        /// An xorshift generator with 1024 bits of state
        /// </summary>
        XOrShift1024 = 12,

        /// <summary>
        /// L’Ecuyer's combined multiple recursive generator (CMRG) with 32-bit unsigned integers
        /// </summary>
        Mrg32K3Au = 13,

        /// <summary>
        /// L’Ecuyer's combined multiple recursive generator (CMRG) with 64-bit floating-point arithmetic.
        /// </summary>
        MRG32K3Ad = 14,

        /// <summary>
        /// Identifies a hardware level entropic source driven by the RDRAND instruction
        /// </summary>
        MklEntropic = 14680064,

        /// <summary>
        /// A 31-bit multiplicative congruential generator provided by MKL
        /// </summary>
        MklMcg31 = 1048576,

        /// <summary>
        /// A generalized feedback shift register generator provided by MKL
        /// </summary>
        MklR250 = 2097152,

        /// <summary>
        /// A combined multiple recursive generator with two components of order 3 provided by MKL
        /// </summary>
        MklMrg32K3A = 3145728,

        /// <summary>
        /// A 59-bit multiplicative congruential generator provided by MKL
        /// </summary>
        MklMcg59 = 4194304,

        /// <summary>
        /// A set of 273 Wichmann-Hill combined multiplicative congruential generators provided by MKL
        /// </summary>
        MklWH = 5242880,

        /// <summary>
        /// A 32-bit Gray code-based generator producing low-discrepancy sequences for dimensions 1 ≤ s ≤ 40 provided by MKL
        /// </summary>
        MklSobol = 6291456,

        /// <summary>
        /// A 32-bit Gray code-based generator producing low-discrepancy sequences for dimensions 1 ≤ s ≤ 318 provided by MKL
        /// </summary>
        MklNiederr = 7340032,

        /// <summary>
        /// A SIMD-oriented Fast Mersenne Twister pseudorandom number generator provided by MKL
        /// </summary>
        MklMt19937 = 8388608,

        /// <summary>
        /// A set of 6024 Mersenne Twister pseudorandom number generators provided by MKL
        /// </summary>
        MklMt2203 = 9437184,

        /// <summary>
        /// A SIMD-oriented Fast Mersenne Twister pseudorandom number generator provided by MKL
        /// </summary>
        MklSfmt19937 = 13631488,

        /// <summary>
        /// An ARS-5 counter-based pseudorandom number generator that uses instructions from the AES-NI set
        /// </summary>
        MklARS5 = 13631488,

        /// <summary>
        /// A Philox4x32-10 counter-based pseudorandom number generator.
        /// </summary>
        MklPhilox4X32X10 = 16777216
    }
}