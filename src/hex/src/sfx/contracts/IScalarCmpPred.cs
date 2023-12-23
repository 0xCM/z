//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Ops;

[Free]
public interface IScalarCmpPred<F,T> : IBinaryOpExpr<F,CmpPredKind,T,T>
    where F : IScalarCmpPred<F,T>
{

}
