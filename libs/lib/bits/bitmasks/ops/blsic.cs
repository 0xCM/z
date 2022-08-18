//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitMasks
    {
        /// <summary>
        /// Isolate least set bit and complement, computed by dst := ~src | (src - 1),
        /// where all bits in the target are set except for the least set bit in the source
        /// For example, [11101010] |> blisc = [11111101]
        /// </summary>
        /// <param name="src">The source vale</param>
        [MethodImpl(Inline), Op]
        public static byte blsic(byte src)
            => (byte)(~src | (src - 1));

        /// <summary>
        /// Isolate least set bit and complement, computed by dst := ~src | (src - 1),
        /// where all bits in the target are set except for the least set bit in the source
        /// For example, [11101010] |> blisc = [11111101]
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static ushort blsic(ushort src)
            => (ushort)(~src | (src - 1));

        /// <summary>
        /// Isolate least set bit and complement, computed by dst := ~src | (src - 1),
        /// where all bits in the target are set except for the least set bit in the source
        /// For example, [11101010] |> blisc = [11111101]
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static uint blsic(uint src)
            => ~src | (src - 1);

        /// <summary>
        /// Isolate least set bit and complement, computed by dst := ~src | (src - 1),
        /// where all bits in the target are set except for the least set bit in the source
        /// For example, [11101010] |> blisc = [11111101]
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static ulong blsic(ulong src)
            => ~src | (src - 1);
    }
}