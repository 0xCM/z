//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IKindConstraint : ITypeConstraint
    {
        ITypeKind Kind {get;}
    }

    public interface IKindConstraint<K> : IKindConstraint
        where K : ITypeKind
    {
        new K Kind {get;}

        ITypeKind IKindConstraint.Kind
            => Kind;
    }
}