//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

[ApiHost]
public readonly unsafe partial struct vpack
{
    const NumericKind Closure = UnsignedInts;

    /// <summary>
    /// PMOVSXBW xmm, m64
    /// </summary>
    /// <returns></returns>
    [MethodImpl(Inline)]
    public static Vector128<short> pmovsxbw(sbyte* pSrc)
        => ConvertToVector128Int16(pSrc);

    /// <summary>
    /// PMOVZXBW xmm, m64
    /// </summary>
    /// <returns></returns>
    [MethodImpl(Inline)]
    public static Vector128<short> pmovzxbw(byte* pSrc)
        => ConvertToVector128Int16(pSrc);
}
