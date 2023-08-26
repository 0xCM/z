//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using static sys;
using static Asm.AsmRegOps;

partial class AsmCases
{
    [MethodImpl(Inline)]
    public static MemOpCase<T> MemOp<T>(T op, string asm)
        where T : unmanaged, IMemOp<T>
            => new (op, asm);

    public static Index<MemOpCase> MemOps(uint count)
        => alloc<MemOpCase>(count);

    [MethodImpl(Inline)]
    public static void mem<T>(MemOpCase<T> src, ref uint i, Span<MemOpCase> dst)
        where T : unmanaged, IMemOp<T>
            => seek(dst,i++) = src;

    static Result<C> CheckEquality<C,T>(C @case, T expect, T actual)
        where T : IEquatable<T>
    {
        if(!expect.Equals(actual))
            return new Result<C>(@case, (false, string.Format("Failure: '{0}' != '{1}'", expect, actual)));
        else
            return new Result<C>(@case, (true, string.Format("Success: '{0}' == '{1}'", expect, actual)));
    }

    public static Index<MemOpCase> MemOpCases()
    {
        var cases = MemOps(7);
        var i=0u;

        cases[i++] = MemOp(asm.mem8(rax), "byte ptr [rax]");
        cases[i++] = MemOp(asm.mem16(rax), "word ptr [rax]");
        cases[i++] = MemOp(asm.mem32(rdx), "dword ptr [rdx]");
        cases[i++] = MemOp(asm.mem8(r8,rcx), "byte ptr [r8 + rcx]");
        cases[i++] = MemOp(asm.mem16(r8, 2, rcx), "word ptr [r8 + 2*rcx]");
        cases[i++] = MemOp(asm.mem16(r8, 2, rcx, asm.disp8(0x20)),"word ptr [r8 + 2*rcx + 0x20]");
        cases[i++] = MemOp(asm.mem16(r8, 2, rcx, asm.disp8(-0x20)),"word ptr [r8 + 2*rcx - 0x20]");
        return cases;
    }

    public static Index<Result<MemOpCase>> check(ReadOnlySpan<MemOpCase> src)
    {
        var count = src.Length;
        var dst = alloc<Result<MemOpCase>>(count);
        for(var i=0; i<count; i++)
        {
            ref readonly var @case = ref skip(src,i);
            AsmOperand op = @case.Op;
            seek(dst,i) = CheckEquality(@case, @case.Asm, @case.Op.Format());
        }
        return dst;
    }
}
