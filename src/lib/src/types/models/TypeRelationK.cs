//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct TypeRelation<K>
        where K : unmanaged
    {
        public K Kind {get;}

        public IType Source {get;}

        public IType Target {get;}

        [MethodImpl(Inline)]
        public TypeRelation(K kind, IType src, IType dst)
        {
            Kind = kind;
            Source = src;
            Target = dst;
        }

        public static implicit operator TypeRelation(TypeRelation<K> src)
            => new TypeRelation(src.Kind.ToString(), core.bw64(src.Kind), src.Source, src.Target);
    }
}