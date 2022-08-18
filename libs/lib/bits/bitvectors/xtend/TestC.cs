//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XBv
    {
        /// <summary>
        /// Returns true of all bits are enabled, false otherwise
        /// </summary>
        [MethodImpl(Inline)]
        public static bit TestC<T>(this ScalarBits<T> src)
            where T : unmanaged
                => BitVectors.testc(src);

        /// <summary>
        /// Returns true of all bits are enabled, false otherwise
        /// </summary>
        [MethodImpl(Inline)]
        public static bit TestC<N,T>(this ScalarBits<N,T> src)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => BitVectors.testc(src);

        /// <summary>
        /// Returns true of all bits are enabled, false otherwise
        /// </summary>
        [MethodImpl(Inline)]
        public static bit TestC(this BitVector8 src)
            => BitVectors.testc(src);

        /// <summary>
        /// Returns true of all bits are enabled, false otherwise
        /// </summary>
        [MethodImpl(Inline)]
        public static bit TestC(this BitVector16 src)
            => BitVectors.testc(src);

        /// <summary>
        /// Returns true of all bits are enabled, false otherwise
        /// </summary>
        [MethodImpl(Inline)]
        public static bit TestC(this BitVector32 src)
            => BitVectors.testc(src);

        /// <summary>
        /// Returns true of all bits are enabled, false otherwise
        /// </summary>
        [MethodImpl(Inline)]
        public static bit TestC(this BitVector64 src)
            => BitVectors.testc(src);
    }
}