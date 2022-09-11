//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [SymSource(sized), DataWidth(3)]
    public enum NativeSizeCode : byte
    {
        /// <summary>
        /// Indicates the width of an 8-bit register
        ///</summary>
        [Symbol("w8", "Indicates a bit-width of 8=(2^3)^0")]
        W8 = 0,

        /// <summary>
        /// Indicates the width of a 16-bit register
        ///</summary>
        [Symbol("w16", "Indicates a bit-width of 16=(2^3)^1")]
        W16 = 1,

        /// <summary>
        /// Indicates the width of a 32-bit register
        ///</summary>
        [Symbol("w32" ,"Indicates a bit-width of 32=(2^3)^2")]
        W32 = 2,

        /// <summary>
        /// Indicates the width of a 64-bit register
        ///</summary>
        [Symbol("w64", "Indicates a bit-width of 64=(2^3)^3")]
        W64 = 3,

        /// <summary>
        /// Indicates the width of a 128-bit register
        ///</summary>
        [Symbol("w128", "Indicates a bit-width of 128=(2^3)^4")]
        W128 = 4,

        /// <summary>
        /// Indicates 256-bit width
        ///</summary>
        [Symbol("w256", "Indicates a bit-width of 256=(2^3)^5")]
        W256 = 5,

        /// <summary>
        /// Indicates 512-bit width
        ///</summary>
        [Symbol("w512", "Indicates a bit-width of 512=(2^3)^6")]
        W512 = 6,

        /// <summary>
        /// Indicates an 80-bit width
        ///</summary>
        [Symbol("w80", "Indicates a bit-width of 80")]
        W80 = 7,
    }
}