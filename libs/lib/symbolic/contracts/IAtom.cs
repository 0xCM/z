//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IAtom : ITerminalExpr, ITerm
    {
    }

    public interface IAtom<K> : IAtom, ITerminalExpr<K>, ITerm<K>
    {

    }
}