//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using Operands;

using static RegIndexCode;
using static emath;

partial struct AsmRegs
{
    [MethodImpl(Inline), Op]
    public static r8 prior(r8 src)
    {
        if(math.gt((byte)src.IndexCode, (byte)r0))
            return dec(src.IndexCode);
        else
            return r15;
    }

    [MethodImpl(Inline), Op]
    public static r16 prior(r16 src)
    {
        if(math.gt((byte)src.IndexCode, (byte)r0))
            return dec(src.IndexCode);
        else
            return r15;
    }

    [MethodImpl(Inline), Op]
    public static r32 prior(r32 src)
    {
        if(math.gt((byte)src.IndexCode, (byte)r0))
            return dec(src.IndexCode);
        else
            return r15;
    }

    [MethodImpl(Inline), Op]
    public static r64 prior(r64 src)
    {
        if(math.gt((byte)src.IndexCode, (byte)r0))
            return dec(src.IndexCode);
        else
            return r15;
    }

    [MethodImpl(Inline), Op]
    public static rK prior(rK src)
    {
        if(math.gt((byte)src.IndexCode, (byte)r0))
            return dec(src.IndexCode);
        else
            return r31;
    }

    [MethodImpl(Inline), Op]
    public static rKz prior(rKz src)
    {
        if(math.gt((byte)src.IndexCode, (byte)r0))
            return dec(src.IndexCode);
        else
            return r7;
    }

    [MethodImpl(Inline), Op]
    public static xmm prior(xmm src)
    {
        if(math.gt((byte)src.IndexCode, (byte)r0))
            return dec(src.IndexCode);
        else
            return r31;
    }

    [MethodImpl(Inline), Op]
    public static ymm prior(ymm src)
    {
        if(math.gt((byte)src.IndexCode, (byte)r0))
            return dec(src.IndexCode);
        else
            return r31;
    }

    [MethodImpl(Inline), Op]
    public static zmm prior(zmm src)
    {
        if(math.gt((byte)src.IndexCode, (byte)r0))
            return dec(src.IndexCode);
        else
            return r31;
    }


    [MethodImpl(Inline), Op]
    public static rCr prior(rCr src)
    {
        if(math.gt((byte)src.IndexCode, (byte)r0))
            return dec(src.IndexCode);
        else
            return r31;
    }

    [MethodImpl(Inline), Op]
    public static rDb prior(rDb src)
    {
        if(math.gt((byte)src.IndexCode, (byte)r0))
            return dec(src.IndexCode);
        else
            return r31;
    }
}
