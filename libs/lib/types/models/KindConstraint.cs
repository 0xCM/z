//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class KindConstraint : TypeConstraint, IKindConstraint
    {
        public KindConstraint(ITypeKind kind)
        {
            Kind = kind;
        }

        public ITypeKind Kind {get;}
    }
}