//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free, SFx]
    public interface IBlockedUnaryImm8Op8<T> : IBlockedFunc<W8,T>
        where T : unmanaged
    {
        SpanBlock8<T> Invoke(SpanBlock8<T> src, byte imm8, SpanBlock8<T> dst);
    }

    [Free, SFx]
    public interface IBlockedUnaryImm8Op16<T> : IBlockedFunc<W16,T>
        where T : unmanaged
    {
        SpanBlock16<T> Invoke(SpanBlock16<T> src, byte imm8, SpanBlock16<T> dst);
    }

    [Free, SFx]
    public interface IBlockedUnaryImm8Op32<T> : IBlockedFunc<W32,T>
        where T : unmanaged
    {
        SpanBlock32<T> Invoke(in SpanBlock32<T> src, byte imm8, in SpanBlock32<T> dst);
    }

    [Free, SFx]
    public interface IBlockedUnaryImm8Op64<T> : IBlockedFunc<W64,T>
        where T : unmanaged
    {
        SpanBlock64<T> Invoke(SpanBlock64<T> src, byte imm8, SpanBlock64<T> dst);
    }

    [Free, SFx]
    public interface IBlockedUnaryImm8Op128<T> : IBlockedFunc<W128,T>
        where T : unmanaged
    {
        SpanBlock128<T> Invoke(SpanBlock128<T> src, byte imm8, SpanBlock128<T> dst);
    }

    [Free, SFx]
    public interface IBlockedUnaryImm8Op256<T> : IBlockedFunc<W256,T>
        where T : unmanaged
    {
        SpanBlock256<T> Invoke(SpanBlock256<T> src, byte imm8, SpanBlock256<T> dst);
    }

    [Free, SFx]
    public interface IBlockedUnaryImm8Op512<T> : IBlockedFunc<W512,T>
        where T : unmanaged
    {
        SpanBlock512<T> Invoke(SpanBlock512<T> src, byte imm8, SpanBlock512<T> dst);
    }
}