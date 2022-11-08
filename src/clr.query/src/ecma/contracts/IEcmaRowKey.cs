//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IEcmaRowKey
    {
        EcmaTableKind TableKind {get;}

        Type RowType {get;}
    }
}