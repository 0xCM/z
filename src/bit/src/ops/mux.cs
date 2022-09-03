//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct bit
    {
        [MethodImpl(Inline), Mux]
        public static bit mux(bit i0, bit i1, bit c0)
            => !c0 ? i0 : i1;

        [MethodImpl(Inline), Mux]
        public static bit mux(bit i0, bit i1, bit i2, bit i3, bit c0, bit c1)
        {
            if(!c0 && !c1)
                return i0;
            else if(c0 && !c1)
                return i1;
            else if(!c0 && c1)
                return i2;
            else
                return i3;
        }

        /// <summary>
        /// Uses the first three bits of the control operand to select one of 8 bits from the input operand
        /// </summary>
        /// <param name="control">Specifies the output selection</param>
        /// <param name="src">The input from which a bit will be selected</param>
        [MethodImpl(Inline), Mux]
        public static bit mux(byte src, byte control)
            => bit.test(src, control);

        /// <summary>
        /// Uses the four bits of the control operand to select one of 16 bits from the input operand
        /// </summary>
        /// <param name="src">The input from which a bit will be selected</param>
        /// <param name="control">Specifies the output selection</param>
        [MethodImpl(Inline), Mux]
        public static bit mux(ushort src, byte control)
            => bit.test(src, control);

        /// <summary>
        /// Uses the first 5 bits of the control operand to select one of 32 bits from the input operand
        /// </summary>
        /// <param name="src">The input from which a bit will be selected</param>
        /// <param name="control">Specifies the output selection</param>
        [MethodImpl(Inline), Mux]
        public static bit mux(uint src, byte control)
            => bit.test(src, control);

        /// <summary>
        /// Uses the first 6 bits of the control operand to select one of 64 bits from the source operand
        /// </summary>
        /// <param name="src">The input from which a bit will be selected</param>
        /// <param name="control">Specifies the output selection</param>
        [MethodImpl(Inline), Mux]
        public static bit mux(ulong src, byte control)
            => bit.test(src, control);
    }
}