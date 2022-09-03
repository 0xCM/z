//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    /// <summary>
    /// Characterizes a memory operand representation
    /// </summary>
    [Free]
    public interface IMemOp : IAsmOp
    {
        AsmAddress Address {get;}

        NativeSize TargetSize {get;}

        AsmOpClass IAsmOp.OpClass
            => AsmOpClass.Mem;

        NativeSize IAsmOp.Size
            => TargetSize;

        RegOp Base
            => Address.Base;

        RegOp Index
            => Address.Index;

        MemoryScale Scale
            => Address.Scale;

        Disp Disp
            => Address.Disp;

        bool HasIndex
            => Address.HasIndex;

        bool HasDisp
            => Address.HasDisp;

        bool HasScale
            => Address.HasScale;
    }

    [Free]
    public interface IMemOp<T> : IMemOp, IAsmOp<T>
        where T : unmanaged
    {
    }

    public interface IMemOp8 : IMemOp
    {
        NativeSize IMemOp.TargetSize
            => NativeSizeCode.W8;

        NativeSize IAsmOp.Size
            => NativeSizeCode.W8;

        AsmOpKind IAsmOp.OpKind
            => AsmOpKind.Mem8;
    }

    public interface IMemOp8<T> : IMemOp8, IMemOp<T>
        where T : unmanaged, IMemOp8<T>
    {

    }

    public interface IMemOp16 : IMemOp
    {
        NativeSize IMemOp.TargetSize
            => NativeSizeCode.W16;

        NativeSize IAsmOp.Size
            => NativeSizeCode.W16;

        AsmOpKind IAsmOp.OpKind
            => AsmOpKind.Mem16;
    }

    public interface IMemOp16<T> : IMemOp16, IMemOp<T>
        where T : unmanaged, IMemOp16<T>
    {

    }

    public interface IMemOp32 : IMemOp
    {
        NativeSize IMemOp.TargetSize
            => NativeSizeCode.W32;

        NativeSize IAsmOp.Size
            => NativeSizeCode.W32;

        AsmOpKind IAsmOp.OpKind
            => AsmOpKind.Mem32;
    }

    public interface IMemOp32<T> : IMemOp32, IMemOp<T>
        where T : unmanaged, IMemOp32<T>
    {

    }

    public interface IMemOp64 : IMemOp
    {
        NativeSize IMemOp.TargetSize
            => NativeSizeCode.W64;

        NativeSize IAsmOp.Size
            => NativeSizeCode.W64;

        AsmOpKind IAsmOp.OpKind
            => AsmOpKind.Mem64;
    }

    public interface IMemOp64<T> : IMemOp64, IMemOp<T>
        where T : unmanaged, IMemOp64<T>
    {

    }

    public interface IMemOp128 : IMemOp
    {
        NativeSize IMemOp.TargetSize
            => NativeSizeCode.W128;

        NativeSize IAsmOp.Size
            => NativeSizeCode.W128;

        AsmOpKind IAsmOp.OpKind
            => AsmOpKind.Mem128;
    }

    public interface IMemOp128<T> : IMemOp128, IMemOp<T>
        where T : unmanaged, IMemOp128<T>
    {

    }

    public interface IMemOp256 : IMemOp
    {
        NativeSize IMemOp.TargetSize
            => NativeSizeCode.W256;

        NativeSize IAsmOp.Size
            => NativeSizeCode.W256;

        AsmOpKind IAsmOp.OpKind
            => AsmOpKind.Mem256;
    }

    public interface IMemOp256<T> :  IMemOp256, IMemOp<T>
        where T : unmanaged, IMemOp256<T>
    {
    }

    public interface IMemOp512 : IMemOp
    {
        NativeSize IMemOp.TargetSize
            => NativeSizeCode.W512;

        NativeSize IAsmOp.Size
            => NativeSizeCode.W512;

        AsmOpKind IAsmOp.OpKind
            => AsmOpKind.Mem512;
    }

    public interface IMemOp512<T> : IMemOp512, IMemOp<T>
        where T : unmanaged, IMemOp512<T>
    {
    }
}