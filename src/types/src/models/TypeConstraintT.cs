//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class TypeConstraint<T> : TypeConstraint, ITypeConstraint<T>
        where T : IType
    {
        public TypeConstraint()
        {
        }
    }
}