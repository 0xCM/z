//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu
{
    /// <summary>
    /// Creates a 256-bit vector by concatenating two 128-bit source vectors
    /// </summary>
    /// <param name="lo">The lower 128-bits of the target vector</param>
    /// <param name="hi">The upper 128-bits of the target vector</param>
    [MethodImpl(Inline), Concat]
    public static Vector256<byte> vconcat(Vector128<byte> lo, Vector128<byte> hi)
        => Avx2.InsertVector128(Avx2.InsertVector128(default, lo, 0), hi, 1);

    /// <summary>
    /// Creates a 256-bit vector by concatenating two 128-bit source vectors
    /// </summary>
    /// <param name="lo">The lower 128-bits of the target vector</param>
    /// <param name="hi">The upper 128-bits of the target vector</param>
    [MethodImpl(Inline), Concat]
    public static Vector256<sbyte> vconcat(Vector128<sbyte> lo, Vector128<sbyte> hi)
        => Avx2.InsertVector128(Avx2.InsertVector128(default, lo, 0), hi, 1);

    /// <summary>
    /// Creates a 256-bit vector by concatenating two 128-bit source vectors
    /// </summary>
    /// <param name="lo">The lower 128-bits of the target vector</param>
    /// <param name="hi">The upper 128-bits of the target vector</param>
    [MethodImpl(Inline), Concat]
    public static Vector256<short> vconcat(Vector128<short> lo, Vector128<short> hi)
        => Avx2.InsertVector128(Avx2.InsertVector128(default, lo, 0), hi, 1);

    /// <summary>
    /// Creates a 256-bit vector by concatenating two 128-bit source vectors
    /// </summary>
    /// <param name="lo">The lower 128-bits of the target vector</param>
    /// <param name="hi">The upper 128-bits of the target vector</param>
    [MethodImpl(Inline), Concat]
    public static Vector256<ushort> vconcat(Vector128<ushort> lo, Vector128<ushort> hi)
        => Avx2.InsertVector128(Avx2.InsertVector128(default, lo, 0), hi, 1);

    /// <summary>
    /// Creates a 256-bit vector by concatenating two 128-bit source vectors
    /// </summary>
    /// <param name="lo">The lower 128-bits of the target vector</param>
    /// <param name="hi">The upper 128-bits of the target vector</param>
    [MethodImpl(Inline), Concat]
    public static Vector256<int> vconcat(Vector128<int> lo, Vector128<int> hi)
        => Avx2.InsertVector128(Avx2.InsertVector128(default, lo, 0), hi, 1);

    /// <summary>
    /// Creates a 256-bit vector by concatenating two 128-bit source vectors
    /// </summary>
    /// <param name="lo">The lower 128-bits of the target vector</param>
    /// <param name="hi">The upper 128-bits of the target vector</param>
    [MethodImpl(Inline), Concat]
    public static Vector256<uint> vconcat(Vector128<uint> lo, Vector128<uint> hi)
        => Avx2.InsertVector128(Avx2.InsertVector128(default, lo, 0), hi, 1);

    /// <summary>
    /// Creates a 256-bit vector by concatenating two 128-bit source vectors
    /// </summary>
    /// <param name="lo">The lower 128-bits of the target vector</param>
    /// <param name="hi">The upper 128-bits of the target vector</param>
    [MethodImpl(Inline), Concat]
    public static Vector256<long> vconcat(Vector128<long> lo, Vector128<long> hi)
        => Avx2.InsertVector128(Avx2.InsertVector128(default, lo, 0), hi, 1);

    /// <summary>
    /// Creates a 256-bit vector by concatenating two 128-bit source vectors
    /// </summary>
    /// <param name="lo">The lower 128-bits of the target vector</param>
    /// <param name="hi">The upper 128-bits of the target vector</param>
    [MethodImpl(Inline), Concat]
    public static Vector256<ulong> vconcat(Vector128<ulong> lo, Vector128<ulong> hi)
        => Avx2.InsertVector128(Avx2.InsertVector128(default, lo, 0), hi, 1);

    [MethodImpl(Inline)]
    public static Vector512<T> vconcat<T>(Vector256<T> lo, Vector256<T> hi)
        where T : unmanaged
            => Vector512.Create(lo,hi);    
}
