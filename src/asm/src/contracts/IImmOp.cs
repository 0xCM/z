//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IImmOp : IAsmOp, ITextual
    {
        ImmKind ImmKind {get;}

        ulong Value {get;}

        AsmOpClass IAsmOp.OpClass
            => AsmOpClass.Imm;
    }

    [Free]
    public interface IImmOp<T> : IImmOp
        where T : unmanaged
    {

    }

    [Free]
    public interface IImm : IImmOp
    {

    }

    [Free]
    public interface IImm<T> : IImm, IImmOp<T>
        where T : unmanaged
    {

    }

    [Free]
    public interface IImm<F,T> : IImm<T>
        where F : unmanaged, IImm<F,T>
        where T : unmanaged
    {
        new T Value {get;}

        ulong IImmOp.Value
            => sys.bw64(Value);

        NativeSize IAsmOp.Size
            => Sizes.native(sys.width<T>());
    }
}