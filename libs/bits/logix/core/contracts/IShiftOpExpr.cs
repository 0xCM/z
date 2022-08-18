//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IShiftOpExpr : IOperatorExpr
    {

    }

    public interface IShiftOpExpr<T> : IShiftOpExpr, IOperatorExpr<T, BitShiftClass>
        where T : unmanaged
    {
        /// <summary>
        /// The thing to shift
        /// </summary>
        ILogixExpr<T> Subject {get;}


        ILogixExpr<byte> Offset {get;}
    }
}