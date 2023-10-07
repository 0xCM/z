//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using static sys;

partial struct AsmRegs
{
    [MethodImpl(Inline), Op]
    public static uint filter(RegClassCode @class, ReadOnlySpan<RegOp> src, Span<RegOp> dst)
    {
        var k=0u;
        var j = min(src.Length, dst.Length);
        for(var i=0; i<j; i++)
        {
            ref readonly var candidate = ref skip(src,i);
            if(invalid(candidate.IndexCode))
                continue;

            if(candidate.RegClassCode == @class)
                seek(dst,k++) = candidate;
        }
        return k;
    }

    [MethodImpl(Inline), Op]
    public static uint filter(NativeSizeCode width, ReadOnlySpan<RegOp> src, Span<RegOp> dst)
    {
        var k=0u;
        var j = min(src.Length, dst.Length);
        for(var i=0; i<j; i++)
        {
            ref readonly var candidate = ref skip(src,i);

            if(invalid(candidate.IndexCode))
                continue;

            if(candidate.Size == width)
                seek(dst,k++) = candidate;
        }
        return k;
    }

    [MethodImpl(Inline), Op]
    public static uint filter(RegClassCode @class, NativeSizeCode width, ReadOnlySpan<RegOp> src, Span<RegOp> dst)
    {
        var k=0u;
        var j = min(src.Length, dst.Length);
        for(var i=0; i<j; i++)
        {
            ref readonly var candidate = ref skip(src,i);

            if(invalid(candidate.IndexCode))
                continue;

            if(candidate.Size == width && candidate.RegClassCode == @class)
                seek(dst,k++) = candidate;
        }
        return k;
    }
}
