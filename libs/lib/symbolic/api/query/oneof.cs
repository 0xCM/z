//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct SymbolicQuery
    {
        /// <summary>
        /// Returns true if the source operand matches one of the target operands
        /// </summary>
        /// <param name="src">The source operand</param>
        /// <param name="a0">The first target operand</param>
        /// <param name="a1">The second target operand</param>
        [MethodImpl(Inline), Op]
        public static bit oneof(char src, char a0, char a1)
            => match(src,a0) || match(src,a1);

        /// <summary>
        /// Returns true if the source operand matches one of the target operands
        /// </summary>
        /// <param name="src">The source operand</param>
        /// <param name="a0">The first target operand</param>
        /// <param name="a1">The second target operand</param>
        /// <param name="a2">The third target operand</param>
        [MethodImpl(Inline), Op]
        public static bit oneof(char src, char a0, char a1, char a2)
            => match(src,a0) || match(src,a1) || match(src,a2);

        /// <summary>
        /// Returns true if the source operand matches one of the target operands
        /// </summary>
        /// <param name="src">The source operand</param>
        /// <param name="a0">The first target operand</param>
        /// <param name="a1">The second target operand</param>
        /// <param name="a2">The third target operand</param>
        [MethodImpl(Inline), Op]
        public static bit oneof(char src, char a0, char a1, char a2, char a3)
            => match(src,a0) || match(src,a1) || match(src,a2) || match(src,a3);
    }
}