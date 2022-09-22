//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitVectors
    {
        /*
        0 | 0 | 0 => selects input 0 = log2(0) [00000001]
        0 | 0 | 1 => selects input 1 = log2(1) [00000010]
        0 | 1 | 0 => selects input 2 = log2(2) [00000100]
        0 | 1 | 1 => selects input 3 = log2(3) [00001000]
        1 | 0 | 0 => selects input 4 = log2(4) [00010000]
        1 | 0 | 1 => selects input 5 = log2(5) [00100000]
        1 | 1 | 0 => selects input 6 = log2(6) [01000000]
        1 | 1 | 1 => selects input 7 = log2(7) [10000000]
        */
        /// <summary>
        /// Uses the first three bits of the control operand to select one of 8 bits from the input operand
        /// </summary>
        /// <param name="control">Specifies the output selection</param>
        /// <param name="src">The input from which a bit will be selected</param>
        [MethodImpl(Inline), Op]
        public static bit mux(BitVector8 src,BitVector4 control)
            => src[control.State];

        /// <summary>
        /// Uses the four bits of the control operand to select one of 16 bits from the input operand
        /// </summary>
        /// <param name="src">The input from which a bit will be selected</param>
        /// <param name="control">Specifies the output selection</param>
        [MethodImpl(Inline), Op]
        public static bit mux(BitVector16 src, BitVector4 control)
            => src[control.State];

        /// <summary>
        /// Uses the first 5 bits of the control operand to select one of 32 bits from the input operand
        /// </summary>
        /// <param name="src">The input from which a bit will be selected</param>
        /// <param name="control">Specifies the output selection</param>
        [MethodImpl(Inline), Op]
        public static bit mux(BitVector32 src, BitVector8 control)
            => src[control.State];

        /// <summary>
        /// Uses the first 6 bits of the control operand to select one of 64 bits from the input operand
        /// </summary>
        /// <param name="src">The input from which a bit will be selected</param>
        /// <param name="control">Specifies the output selection</param>
        [MethodImpl(Inline), Op]
        public static bit mux(BitVector64 src, BitVector8 control)
            => src[control.State];
    }
}