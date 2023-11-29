//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static CpuBytes;
using static vcpu;

partial struct vmask
{
    /// <summary>
    /// Produces the lo shuffle spec for packing (128x32, 128x32) -> 128x16
    /// </summary>
    /// <param name="w">The vector width selector</param>
    /// <param name="src">The source cell width selector</param>
    /// <param name="dst">The target cell width selector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<byte> packusLo(N128 w, N32 src, N16 dst)
        => vload(w, PackUSLo32x128x16u);

    /// <summary>
    /// Produces the lo shuffle spec for packing (128x16,128x16) -> 128x8
    /// </summary>
    /// <param name="w">The vector width selector</param>
    /// <param name="src">The source cell width selector</param>
    /// <param name="dst">The target cell width selector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<byte> packusLo(N128 w, N16 src, N8 dst)
        => vload(w, PackUSLo16x128x8u);

    [MethodImpl(Inline), Op]
    public static Vector256<byte> packusLo(N256 w, N16 src, N8 dst)
        => vload(w, PackUSLo16x256x8u);

    /// <summary>
    /// Retrieves the lo shuffle spec for packing 256x32x2 -> 256x16
    /// </summary>
    /// <param name="w">The vector width selector</param>
    /// <param name="src">The source cell width selector</param>
    /// <param name="dst">The target cell width selector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<byte> vpackuslo(N256 w, N32 src, N16 dst)
        => vload(w,PackUSLo32x256x16u);
}

