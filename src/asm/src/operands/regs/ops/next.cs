//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using Operands;
using static RegIndexCode;

using T = Operands;

partial struct AsmRegs
{
    /// <summary>
    /// Advances to the next <see cref='T.r8'/> register
    /// </summary>
    /// <param name="src"></param>
    [MethodImpl(Inline), Op]
    public static r8 next(r8 src)
    {
        if(math.lt((byte)src.IndexCode, (byte)r15))
            return emath.inc(src.IndexCode);
        else
            return r0;
    }

    [MethodImpl(Inline), Op]
    public static rKz next(rKz src)
    {
        if(math.lt((byte)src.IndexCode, (byte)r7))
            return emath.inc(src.IndexCode);
        else
            return r0;
    }

    /// <summary>
    /// Advances to the next <see cref='T.r16'/> register, modulo 16
    /// </summary>
    /// <param name="src">The source register</param>
    [MethodImpl(Inline), Op]
    public static r16 next(r16 src)
    {
        if(math.lt((byte)src.IndexCode, (byte)r15))
            return emath.inc(src.IndexCode);
        else
            return r0;
    }

    /// <summary>
    /// Advances to the next <see cref='T.r32'/> register, modulo 16
    /// </summary>
    /// <param name="src">The source register</param>
    [MethodImpl(Inline), Op]
    public static r32 next(r32 src)
    {
        if(math.lt((byte)src.IndexCode, (byte)r15))
            return emath.inc(src.IndexCode);
        else
            return r0;
    }

    /// <summary>
    /// Advances to the next <see cref='r64'/> register, modulo 16
    /// </summary>
    /// <param name="src">The source register</param>
    [MethodImpl(Inline), Op]
    public static r64 next(r64 src)
    {
        if(math.lt((byte)src.IndexCode, (byte)r15))
            return emath.inc(src.IndexCode);
        else
            return r0;
    }

    /// <summary>
    /// Advances to the next <see cref='T.xmm'/> register, modulo 32
    /// </summary>
    /// <param name="src">The source register</param>
    [MethodImpl(Inline), Op]
    public static xmm next(xmm src)
    {
        if(math.lt((byte)src.IndexCode, (byte)r31))
            return emath.inc(src.IndexCode);
        else
            return r0;
    }

    /// <summary>
    /// Advances to the next <see cref='T.ymm'/> register, modulo 32
    /// </summary>
    /// <param name="src">The source register</param>
    [MethodImpl(Inline), Op]
    public static ymm next(ymm src)
    {
        if(math.lt((byte)src.IndexCode, (byte)r31))
            return emath.inc(src.IndexCode);
        else
            return r0;
    }

    /// <summary>
    /// Advances to the next <see cref='T.zmm'/> register, modulo 32
    /// </summary>
    /// <param name="src">The source register</param>
    [MethodImpl(Inline), Op]
    public static zmm next(zmm src)
    {
        if(math.lt((byte)src.IndexCode, (byte)r31))
            return emath.inc(src.IndexCode);
        else
            return r0;
    }

    [MethodImpl(Inline), Op]
    public static rK next(rK src)
    {
        if(math.lt((byte)src.IndexCode, (byte)RegIndexCode.r8))
            return emath.inc(src.IndexCode);
        else
            return r0;
    }

    [MethodImpl(Inline), Op]
    public static rCr next(rCr src)
    {
        if(math.lt((byte)src.IndexCode, (byte)RegIndexCode.r8))
            return emath.inc(src.IndexCode);
        else
            return r0;
    }

    [MethodImpl(Inline), Op]
    public static rDb next(rDb src)
    {
        if(math.lt((byte)src.IndexCode, (byte)RegIndexCode.r8))
            return emath.inc(src.IndexCode);
        else
            return r0;
    }
}
