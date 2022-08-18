//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static gmath;

    partial class BitVectors
    {
        /// <summary>
        /// Computes the parity of the source vector, which is 1 if an odd number of its components are enabled and 0 otherwise
        /// </summary>
        /// <remarks>
        /// The parity function p:{0,1}x...x{0,1} -> {0,1} is a boolean function that attains the
        /// value 1 when an odd number of its input values are 1 and 0 otherwise.
        /// </remarks>
        [MethodImpl(Inline), Op]
        public static bit parity(BitVector4 src)
            => odd(pop(src));

        /// <summary>
        /// Computes the parity of the source vector, which is 1 if an odd number of its components are enabled and 0 otherwise
        /// </summary>
        /// <remarks>
        /// The parity function p:{0,1}x...x{0,1} -> {0,1} is a boolean function that attains the
        /// value 1 when an odd number of its input values are 1 and 0 otherwise.
        /// </remarks>
        [MethodImpl(Inline), Op]
        public static bit parity(BitVector8 src)
            => odd(pop(src));

        /// <summary>
        /// Computes the parity of the source vector, which is 1 if an odd number of its components are enabled and 0 otherwise
        /// </summary>
        /// <remarks>
        /// The parity function p:{0,1}x...x{0,1} -> {0,1} is a boolean function that attains the
        /// value 1 when an odd number of its input values are 1 and 0 otherwise.
        /// </remarks>
        [MethodImpl(Inline), Op]
        public static bit parity(BitVector16 src)
            => odd(pop(src));

        /// <summary>
        /// Computes the parity of the source vector, which is 1 if an odd number of its components are enabled and 0 otherwise
        /// </summary>
        /// <remarks>
        /// The parity function p:{0,1}x...x{0,1} -> {0,1} is a boolean function that attains the
        /// value 1 when an odd number of its input values are 1 and 0 otherwise.
        /// </remarks>
        [MethodImpl(Inline), Op]
        public static bit parity(BitVector32 src)
            => odd(pop(src));

        /// <summary>
        /// Computes the parity of the source vector, which is 1 if an odd number of its components are enabled and 0 otherwise
        /// </summary>
        /// <remarks>
        /// The parity function p:{0,1}x...x{0,1} -> {0,1} is a boolean function that attains the
        /// value 1 when an odd number of its input values are 1 and 0 otherwise.
        /// </remarks>
        [MethodImpl(Inline), Op]
        public static bit parity(BitVector64 src)
            => odd(pop(src));
    }
}