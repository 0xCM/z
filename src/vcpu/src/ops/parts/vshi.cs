//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu
{
    /// <summary>
    /// Creates a scalar vector from the upper 64 bits of the source vector
    /// </summary>
    /// <param name="src">The source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<sbyte> vshi(Vector128<sbyte> src)
        => v8i(vscalar(w128, vcell(v64u(src),1)));

    /// <summary>
    /// Creates a scalar vector from the upper 64 bits of the source vector
    /// </summary>
    /// <param name="src">The source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<byte> vshi(Vector128<byte> src)
        => v8u(vscalar(w128, vcell(v64u(src), 1)));

    /// <summary>
    /// Creates a scalar vector from the upper 64 bits of the source vector
    /// </summary>
    /// <param name="src">The source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<short> vshi(Vector128<short> src)
        => v16i(vscalar(w128, vcell(v64u(src), 1)));

    /// <summary>
    /// Creates a scalar vector from the upper 64 bits of the source vector
    /// </summary>
    /// <param name="src">The source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<ushort> vshi(Vector128<ushort> src)
        => v16u(vscalar(w128, vcell(v64u(src), 1)));

    /// <summary>
    /// Creates a scalar vector from the upper 64 bits of the source vector
    /// </summary>
    /// <param name="src">The source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<int> vshi(Vector128<int> src)
        => v32i(vscalar(w128, vcell(v64u(src), 1)));

    /// <summary>
    /// Creates a scalar vector from the upper 64 bits of the source vector
    /// </summary>
    /// <param name="src">The source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<uint> vshi(Vector128<uint> src)
        => v32u(vscalar(w128, vcell(v64u(src), 1)));

    /// <summary>
    /// Creates a scalar vector from the upper 64 bits of the source vector
    /// </summary>
    /// <param name="src">The source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<long> vshi(Vector128<long> src)
        => vscalar(w128, vcell(src,1));

    /// <summary>
    /// Creates a scalar vector from the upper 64 bits of the source vector
    /// </summary>
    /// <param name="src">The source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<ulong> vshi(Vector128<ulong> src)
        => vscalar(w128, vcell(src,1));
}
