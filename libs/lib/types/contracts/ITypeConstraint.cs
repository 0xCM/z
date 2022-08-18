//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ITypeConstraint
    {

    }

    public interface ITypeConstraint<T> : ITypeConstraint
        where T : IType
    {

    }
}