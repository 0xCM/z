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
    public static RexB rexb(RexBToken token, RegIndexCode r)
        => new (token, r);

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
        var dst = alloc<RexB>(16*3 + 20 + 4);
        var j=0u;
        Gen(AsmRegSets.Gp8Regs(), rb(), ref j, dst);
        Gen(AsmRegSets.Gp16Regs(), rw(), ref j, dst);
        Gen(AsmRegSets.Gp32Regs(), rd(), ref j, dst);
        Gen(AsmRegSets.Gp64Regs(), ro(), ref j, dst);
        return dst;
    }

    void Gen(RegOpSeq src, RexBToken token, ref uint j, Span<RexB> dst)
    {
        var count = src.Count;
        for(byte i=0; i<count; i++)
        {
            ref readonly var reg = ref src[i];
            var code = reg.IndexCode == 0 ? 0 : (byte)reg.IndexCode % 16;
            seek(dst,j++) = rexb(token, (RegIndexCode)code);
        }
    }
}
