//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Z0.Asm;

    [Free]
    public interface IRegMask : IAsmOp
    {
        RegOp Target {get;}

        RegIndex Mask {get;}

        RegMaskKind MaskKind {get;}

        AsmOpKind IAsmOp.OpKind
            => AsmOpKind.RegMask;

        AsmOpClass IAsmOp.OpClass
            => AsmOpClass.RegMask;

        NativeSize IAsmOp.Size
            => NativeSizeCode.W64;
    }

    [Free]
    public interface IRegMask<T> : IRegMask
        where T : unmanaged
    {

    }
}