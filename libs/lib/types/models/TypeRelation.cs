//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct TypeRelation
    {
        public Identifier Class {get;}

        public ulong Kind {get;}

        public IType Source {get;}

        public IType Target {get;}

        [MethodImpl(Inline)]
        public TypeRelation(Identifier @class, ulong kind, IType src, IType dst)
        {
            Class = @class;
            Kind = kind;
            Source = src;
            Target = dst;
        }
    }
}