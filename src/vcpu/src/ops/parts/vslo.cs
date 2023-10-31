//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu
{
    /// <summary>
    /// Creates a scalar vector from the lower 64 bits of the source vector
    /// </summary>
    /// <param name="src">The source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<sbyte> vslo(Vector128<sbyte> src)
        => v8i(vscalar(w128, vcell(v64u(src),0)));

    /// <summary>
    /// Creates a scalar vector from the lower 64 bits of the source vector
    /// </summary>
    /// <param name="src">The source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<byte> vslo(Vector128<byte> src)
        => v8u(vscalar(w128, vcell(v64u(src),0)));

    /// <summary>
    /// Creates a scalar vector from the lower 64 bits of the source vector
    /// </summary>
    /// <param name="src">The source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<short> vslo(Vector128<short> src)
        => v16i(vscalar(w128, vcell(v64u(src),0)));

    /// <summary>
    /// Creates a scalar vector from the lower 64 bits of the source vector
    /// </summary>
    /// <param name="src">The source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<ushort> vslo(Vector128<ushort> src)
        => v16u(vscalar(w128, vcell(v64u(src),0)));

    /// <summary>
    /// Creates a scalar vector from the lower 64 bits of the source vector
    /// </summary>
    /// <param name="src">The source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<int> vslo(Vector128<int> src)
        => v32i(vscalar(w128, vcell(v64u(src),0)));

    /// <summary>
    /// Creates a scalar vector from the lower 64 bits of the source vector
    /// </summary>
    /// <param name="src">The source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<uint> vslo(Vector128<uint> src)
        => v32u(vscalar(w128, vcell(v64u(src),0)));

    /// <summary>
    /// Creates a scalar vector from the lower 64 bits of the source vector
    /// </summary>
    /// <param name="src">The source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<long> vslo(Vector128<long> src)
        => v64i(vscalar(w128, vcell(v64u(src),0)));

    /// <summary>
    /// Creates a scalar vector from the lower 64 bits of the source vector
    /// </summary>
    /// <param name="src">The source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<ulong> vslo(Vector128<ulong> src)
        => v64u(vscalar(w128, vcell(v64u(src),0)));

}