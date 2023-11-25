//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class XTend
{
    /// <summary>
    /// Block-formats the vector, e.g. [01010101 01010101 ... 01010101] where by default the size of each block is the bit-width of a component
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <typeparam name="T">The component type</typeparam>
    public static string FormatBlockedBits<T>(this Vector128<T> src, int width, uint? maxbits = null)
        where T : unmanaged
            => text.bracket(src.ToBitString((int?)maxbits).Format(BitFormatter.blocked(width, Chars.Space, maxbits)));

    /// <summary>
    /// Block-formats the vector, e.g. [01010101 01010101 ... 01010101] where default the size of each block is the bit-width of a component
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <typeparam name="T">The component type</typeparam>
    public static string FormatBlockedBits<T>(this Vector256<T> src, int width, uint? maxbits = null)
        where T : unmanaged
            => text.bracket(src.ToBitString((int?)maxbits).Format(BitFormatter.blocked(width, Chars.Space, maxbits)));

    /// <summary>
    /// Formats vector bits
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <typeparam name="T">The underlying primal type</typeparam>
    public static string FormatBits<T>(this Vector128<T> src, int? maxbits = null,  bool tlz = false, bool specifier = false, int? blockWidth = null,
        char? blocksep = null, int? rowWidth = null)
            where T : unmanaged
                => src.ToBitString(maxbits).Format(BitFormatter.define(tlz, specifier, blockWidth, blocksep, rowWidth,null));

    /// <summary>
    /// Formats vector bits
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <typeparam name="T">The underlying primal type</typeparam>
    public static string FormatBits<T>(this Vector256<T> src, int? maxbits = null, bool tlz = false, bool specifier = false, int? blockWidth = null,
        char? blocksep = null, int? rowWidth = null)
            where T : unmanaged
                => src.ToBitString(maxbits).Format(BitFormatter.define(tlz, specifier, blockWidth, blocksep, rowWidth,null));
                
    /// <summary>
    /// Converts an 128-bit intrinsic vector representation to a bitstring
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <typeparam name="T">The underlying primal type</typeparam>
    [MethodImpl(Inline)]
    public static BitString ToBitString<T>(this Vector128<T> src, int? maxbits = null)
        where T : unmanaged
            => vgcpu.bitstring(src, maxbits);

    /// <summary>
    /// Converts an 256-bit vector representation to a bitstring
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <typeparam name="T">The underlying primal type</typeparam>
    [MethodImpl(Inline)]
    public static BitString ToBitString<T>(this Vector256<T> src, int? maxbits = null)
        where T : unmanaged
            => vgcpu.bitstring(src, maxbits);

    /// <summary>
    /// Converts a 512-bit vector representation to a bitstring
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <typeparam name="T">The underlying primal type</typeparam>
    [MethodImpl(Inline)]
    public static BitString ToBitString<T>(this Vector512<T> src, int? maxbits = null)
        where T : unmanaged
            => vgcpu.bitstring(src, maxbits);
}
