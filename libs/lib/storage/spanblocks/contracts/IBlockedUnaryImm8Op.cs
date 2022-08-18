//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free, SFx]
    public interface IBlockedUnaryImm8Op8<T> : IBlockedFunc<W8,T>
        where T : unmanaged
    {
        ref readonly SpanBlock8<T> Invoke(in SpanBlock8<T> src, byte imm8, in SpanBlock8<T> dst);
    }

    [Free, SFx]
    public interface IBlockedUnaryImm8Op16<T> : IBlockedFunc<W16,T>
        where T : unmanaged
    {
        ref readonly SpanBlock16<T> Invoke(in SpanBlock16<T> src, byte imm8, in SpanBlock16<T> dst);
    }

    [Free, SFx]
    public interface IBlockedUnaryImm8Op32<T> : IBlockedFunc<W32,T>
        where T : unmanaged
    {
        ref readonly SpanBlock32<T> Invoke(in SpanBlock32<T> src, byte imm8, in SpanBlock32<T> dst);
    }

    [Free, SFx]
    public interface IBlockedUnaryImm8Op64<T> : IBlockedFunc<W64,T>
        where T : unmanaged
    {
        ref readonly SpanBlock64<T> Invoke(in SpanBlock64<T> src, byte imm8, in SpanBlock64<T> dst);
    }

    [Free, SFx]
    public interface IBlockedUnaryImm8Op128<T> : IBlockedFunc<W128,T>
        where T : unmanaged
    {
        ref readonly SpanBlock128<T> Invoke(in SpanBlock128<T> src, byte imm8, in SpanBlock128<T> dst);
    }

    [Free, SFx]
    public interface IBlockedUnaryImm8Op256<T> : IBlockedFunc<W256,T>
        where T : unmanaged
    {
        ref readonly SpanBlock256<T> Invoke(in SpanBlock256<T> src, byte imm8, in SpanBlock256<T> dst);
    }

    [Free, SFx]
    public interface IBlockedUnaryImm8Op512<T> : IBlockedFunc<W512,T>
        where T : unmanaged
    {
        ref readonly SpanBlock512<T> Invoke(in SpanBlock512<T> src, byte imm8, in SpanBlock512<T> dst);
    }

}