//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    /// <summary>
    /// Characterizes a register operand representation
    /// </summary>
    [Free]
    public interface IRegOp : IAsmOp, ITextual
    {
        /// <summary>
        /// The register index code
        /// </summary>
        RegIndexCode Index {get;}

        /// <summary>
        /// The register classifier
        /// </summary>
        RegClassCode RegClassCode {get;}

        NativeSize IAsmOp.Size
            => new NativeSize(Size);

        RegClass RegClass
            => RegClassCode;

        string ITextual.Format()
            => GetType().Name;
    }

    /// <summary>
    /// Characterizes a parametric register operand representation
    /// </summary>
    /// <typeparam name="T">The represented storage type</typeparam>
    [Free]
    public interface IRegOp<T> : IRegOp
        where T : unmanaged
    {
        AsmOpClass IAsmOp.OpClass
            => AsmOpClass.Reg | (AsmOpClass)width<T>(w16);
    }

    /// <summary>
    /// Characterizes an operand representation of an 8-bit register
    /// </summary>
    [Free]
    public interface IRegOp8 : IRegOp
    {
        NativeSize IAsmOp.Size
            => NativeSizeCode.W8;

        AsmOpKind IAsmOp.OpKind
            => AsmOpKind.GpReg8;
    }

    [Free]
    public interface IRegOp8<T> : IRegOp8, IRegOp<T>
        where T : unmanaged, IRegOp8<T>
    {
        RegClassCode IRegOp.RegClassCode
            => RegClassCode.GP;
    }

    /// <summary>
    /// Characterizes a register operand reprentation
    /// </summary>
    [Free]
    public interface IRegOp16 : IRegOp
    {
        NativeSize IAsmOp.Size
            => NativeSizeCode.W16;

        AsmOpKind IAsmOp.OpKind
            => AsmOpKind.GpReg16;
    }

    [Free]
    public interface IRegOp16<T> : IRegOp16, IRegOp<T>
        where T : unmanaged, IRegOp16<T>
    {
        RegClassCode IRegOp.RegClassCode
            => RegClassCode.GP;
    }

    /// <summary>
    /// Characterizes an operand representation of a 32-bit register
    /// </summary>
    [Free]
    public interface IRegOp32 : IRegOp
    {
        NativeSize IAsmOp.Size
            => NativeSizeCode.W32;

        AsmOpKind IAsmOp.OpKind
            => AsmOpKind.GpReg32;
    }

    [Free]
    public interface IRegOp32<T> : IRegOp32, IRegOp<T>
        where T : unmanaged, IRegOp32<T>
    {
        RegClassCode IRegOp.RegClassCode
            => RegClassCode.GP;
    }

    [Free]
    public interface IRegOp64 : IRegOp
    {
        NativeSize IAsmOp.Size
            => NativeSizeCode.W64;

        AsmOpKind IAsmOp.OpKind
            => AsmOpKind.GpReg64;
    }

    [Free]
    public interface IRegOp64<T> : IRegOp64, IRegOp<T>
        where T : unmanaged, IRegOp64<T>
    {
        RegClassCode IRegOp.RegClassCode
            => RegClassCode.GP;
    }

    /// <summary>
    /// Characterizes an operand representation of a 128-bit register
    /// </summary>
    [Free]
    public interface IRegOp128 : IRegOp
    {
        NativeSize IAsmOp.Size
            => NativeSizeCode.W128;

        AsmOpKind IAsmOp.OpKind
            => AsmOpKind.VReg128;
    }

    [Free]
    public interface IRegOp128<T> : IRegOp128, IRegOp<T>
        where T : unmanaged, IRegOp128<T>
    {
        RegClassCode IRegOp.RegClassCode
            => RegClassCode.XMM;
    }

    [Free]
    public interface IRegOp256 : IRegOp
    {
        NativeSize IAsmOp.Size
            => NativeSizeCode.W256;

        AsmOpKind IAsmOp.OpKind
            => AsmOpKind.VReg256;
    }

    [Free]
    public interface IRegOp256<T> : IRegOp256, IRegOp<T>
        where T : unmanaged, IRegOp256<T>
    {
        RegClassCode IRegOp.RegClassCode
            => RegClassCode.YMM;
    }

    /// <summary>
    /// Characterizes an operand representation of a 512-bit register
    /// </summary>
    [Free]
    public interface IRegOp512 : IRegOp
    {
        NativeSize IAsmOp.Size
            => NativeSizeCode.W512;

        AsmOpKind IAsmOp.OpKind
            => AsmOpKind.VReg512;
    }

    [Free]
    public interface IRegOp512<T> : IRegOp512, IRegOp<T>
        where T : unmanaged, IRegOp512<T>
    {
        RegClassCode IRegOp.RegClassCode
            => RegClassCode.ZMM;
    }
}