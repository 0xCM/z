//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Avx;
    using static System.Runtime.Intrinsics.X86.Avx2;

    partial struct cpu
    {
        /// <summary>
        /// Creates a 256-bit vector by concatenating two 128-bit source vectors
        /// </summary>
        /// <param name="lo">The lower 128-bits of the target vector</param>
        /// <param name="hi">The upper 128-bits of the target vector</param>
        [MethodImpl(Inline), Concat]
        public static Vector256<byte> vconcat(Vector128<byte> lo, Vector128<byte> hi)
            => InsertVector128(InsertVector128(default, lo, 0), hi, 1);

        /// <summary>
        /// Creates a 256-bit vector by concatenating two 128-bit source vectors
        /// </summary>
        /// <param name="lo">The lower 128-bits of the target vector</param>
        /// <param name="hi">The upper 128-bits of the target vector</param>
        [MethodImpl(Inline), Concat]
        public static Vector256<sbyte> vconcat(Vector128<sbyte> lo, Vector128<sbyte> hi)
            => InsertVector128(InsertVector128(default, lo, 0), hi, 1);

        /// <summary>
        /// Creates a 256-bit vector by concatenating two 128-bit source vectors
        /// </summary>
        /// <param name="lo">The lower 128-bits of the target vector</param>
        /// <param name="hi">The upper 128-bits of the target vector</param>
        [MethodImpl(Inline), Concat]
        public static Vector256<short> vconcat(Vector128<short> lo, Vector128<short> hi)
            => InsertVector128(InsertVector128(default, lo, 0), hi, 1);

        /// <summary>
        /// Creates a 256-bit vector by concatenating two 128-bit source vectors
        /// </summary>
        /// <param name="lo">The lower 128-bits of the target vector</param>
        /// <param name="hi">The upper 128-bits of the target vector</param>
        [MethodImpl(Inline), Concat]
        public static Vector256<ushort> vconcat(Vector128<ushort> lo, Vector128<ushort> hi)
            => InsertVector128(InsertVector128(default, lo, 0), hi, 1);

        /// <summary>
        /// Creates a 256-bit vector by concatenating two 128-bit source vectors
        /// </summary>
        /// <param name="lo">The lower 128-bits of the target vector</param>
        /// <param name="hi">The upper 128-bits of the target vector</param>
        [MethodImpl(Inline), Concat]
        public static Vector256<int> vconcat(Vector128<int> lo, Vector128<int> hi)
            => InsertVector128(InsertVector128(default, lo, 0), hi, 1);

        /// <summary>
        /// Creates a 256-bit vector by concatenating two 128-bit source vectors
        /// </summary>
        /// <param name="lo">The lower 128-bits of the target vector</param>
        /// <param name="hi">The upper 128-bits of the target vector</param>
        [MethodImpl(Inline), Concat]
        public static Vector256<uint> vconcat(Vector128<uint> lo, Vector128<uint> hi)
            => InsertVector128(InsertVector128(default, lo, 0), hi, 1);

        /// <summary>
        /// Creates a 256-bit vector by concatenating two 128-bit source vectors
        /// </summary>
        /// <param name="lo">The lower 128-bits of the target vector</param>
        /// <param name="hi">The upper 128-bits of the target vector</param>
        [MethodImpl(Inline), Concat]
        public static Vector256<long> vconcat(Vector128<long> lo, Vector128<long> hi)
            => InsertVector128(InsertVector128(default, lo, 0), hi, 1);

        /// <summary>
        /// Creates a 256-bit vector by concatenating two 128-bit source vectors
        /// </summary>
        /// <param name="lo">The lower 128-bits of the target vector</param>
        /// <param name="hi">The upper 128-bits of the target vector</param>
        [MethodImpl(Inline), Concat]
        public static Vector256<ulong> vconcat(Vector128<ulong> lo, Vector128<ulong> hi)
            => InsertVector128(InsertVector128(default, lo, 0), hi, 1);

        /// <summary>
        /// Creates a 256-bit vector by concatenating two 128-bit source vectors
        /// </summary>
        /// <param name="lo">The lower 128-bits of the target vector</param>
        /// <param name="hi">The upper 128-bits of the target vector</param>
        [MethodImpl(Inline), Concat]
        public static Vector256<float> vconcat(Vector128<float> lo, Vector128<float> hi)
            => InsertVector128(InsertVector128(default, lo, 0), hi, 1);

        /// <summary>
        /// Creates a 256-bit vector by concatenating two 128-bit source vectors
        /// </summary>
        /// <param name="lo">The lower 128-bits of the target vector</param>
        /// <param name="hi">The upper 128-bits of the target vector</param>
        [MethodImpl(Inline), Concat]
        public static Vector256<double> vconcat(Vector128<double> lo, Vector128<double> hi)
            => InsertVector128(InsertVector128(default, lo, 0), hi, 1);
    }
}