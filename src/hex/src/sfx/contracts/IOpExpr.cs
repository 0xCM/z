//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

[Free]
public interface IOpExpr : IExpr
{
    Identifier OpName {get;}

    bool INullity.IsEmpty
        => OpName.IsEmpty;
}

[Free]
public interface IOpExpr<K> : IOpExpr, IKinded<K>
    where K : unmanaged
{
    bool INullity.IsEmpty
        => OpName.IsEmpty;
}
