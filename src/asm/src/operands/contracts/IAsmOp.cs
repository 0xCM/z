//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    /// <summary>
    /// Characterizes an asm operand representation
    /// </summary>
    [Free]
    public interface IAsmOp : IExpr
    {
        AsmOpKind OpKind {get;}

        AsmOpClass OpClass {get;}

        NativeSize Size {get;}

        bool INullity.IsEmpty
            => OpKind == 0;

        bool INullity.IsNonEmpty
            => OpKind != 0;

        string IExpr.Format()
            => "<unimplemented>";
    }

    [Free]
    public interface IAsmOp<T> : IAsmOp
        where T : unmanaged
    {

    }
}