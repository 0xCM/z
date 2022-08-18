//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public class TypeConstraint<T> : TypeConstraint, ITypeConstraint<T>
        where T : IType
    {
        public TypeConstraint()
        {
        }
    }
}