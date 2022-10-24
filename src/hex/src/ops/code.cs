//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static HexCharData;

    using H = HexCharData;

    partial class H0x
    {
        /// <summary>
        /// Returns the upper-case hex code for a specified digit
        /// </summary>
        /// <param name="case">The case selector</param>
        /// <param name="index">The digit value</param>
        /// <remarks>movzx eax,dl -> movsxd rax,eax -> mov rdx,28b57e0aca9h -> movzx eax,byte ptr [rax+rdx] </remarks>
        [MethodImpl(Inline), Op]
        public static HexDigitCode code(UpperCased @case, HexDigitValue digit)
            => (HexDigitCode)skip(H.UpperCodes, (byte)digit);

        /// <summary>
        /// Returns the lower-case hex code for a specified digit
        /// </summary>
        /// <param name="case">The case selector</param>
        /// <param name="index">The digit value</param>
        /// <remarks>movzx eax,dl -> movsxd rax,eax -> mov rdx,28b57e0aed9h -> movzx eax,byte ptr [rax+rdx]</remarks>
        [MethodImpl(Inline), Op]
        public static HexDigitCode code(LowerCased @case, HexDigitValue digit)
            => (HexDigitCode)skip(H.LowerCodes, (byte)digit);

        // /// <summary>
        // /// Returns the hex character code for a specified value of at most 4 bits
        // /// </summary>
        // /// <param name="src">The value to be hex-encoded</param>
        // [MethodImpl(Inline), Op]
        // public static HexUpperCode code(UpperCased upper, Hex4 src)
        //     => (HexUpperCode)sys.skip(first(UpperHexDigits), src);

        // /// <summary>
        // /// Returns the hex character code for a <see cref='uint4'/> value
        // /// </summary>
        // /// <param name="src">The value to be hex-encoded</param>
        // [MethodImpl(Inline), Op]
        // public static HexLowerCode code(LowerCased lower, Hex4 src)
        //     => (HexLowerCode)sys.skip(first(LowerHexDigits), src);

        /// <summary>
        /// Returns the hex character code for a specified value of at most 4 bits
        /// </summary>
        /// <param name="src">The value to be hex-encoded</param>
        [MethodImpl(Inline), Op]
        public static HexUpperCode code(N4 n, UpperCased upper, byte src)
            => (HexUpperCode)sys.skip(first(UpperHexDigits), src);

        /// <summary>
        /// Returns the hex character code for a <see cref='uint4'/> value
        /// </summary>
        /// <param name="src">The value to be hex-encoded</param>
        [MethodImpl(Inline), Op]
        public static HexLowerCode code(N4 n, LowerCased lower, byte src)
            => (HexLowerCode)sys.skip(first(LowerHexDigits), src);
    }
}
