//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using static sys;
using static AsmOpCodeTokens;

/// <summary>
/// Generates <see cref='RexB'/> tables
/// </summary>
public sealed class RexBGenerator : AppService<RexBGenerator>
{
    // RexBBits:[Index[00000] | Token[000]]
    public static RexB rexb(RexBToken token, RegIndexCode r, bit gpHi)
        => new (token, r, gpHi);

    [MethodImpl(Inline)]
    static RexBToken rb()
        => RexBToken.rb;

    [MethodImpl(Inline)]
    static RexBToken rw()
        => RexBToken.rw;

    [MethodImpl(Inline)]
    static RexBToken rd()
        => RexBToken.rd;

    [MethodImpl(Inline)]
    static RexBToken ro()
        => RexBToken.ro;

    public RexBGenerator()
    {

    }

    public Index<RexB> Generate()
    {
        var regs = AsmRegSets.create();
        var dst = alloc<RexB>(16*4 + 4);
        var j=0u;
        Gen(regs.Gp8LoRegs(), rb(), 0, ref j, dst);
        Gen(regs.Gp8HiRegs(), rb(), 1, ref j, dst);
        Gen(regs.Gp16Regs(), rw(), 0, ref j, dst);
        Gen(regs.Gp32Regs(), rd(), 0, ref j, dst);
        Gen(regs.Gp64Regs(), ro(), 0, ref j, dst);
        return dst;
    }

    void Gen(RegOpSeq src, RexBToken token, bit hi, ref uint j, Span<RexB> dst)
    {
        var count = src.Count;
        for(byte i=0; i<count; i++)
        {
            ref readonly var reg = ref src[i];
            seek(dst,j++) = rexb(token, (RegIndexCode)reg.Index, hi);
        }
    }
}
