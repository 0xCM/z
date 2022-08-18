//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface ITerminalExpr : IValued
    {

    }

    [Free]
    public interface ITerminalExpr<T> : ITerminalExpr, IValued<T>
    {
    }
}