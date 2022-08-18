//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;

    using static Root;

    public class TypeDef<K> : TypeDef, IType<K>, IEquatable<TypeDef<K>>
        where K : unmanaged
    {
        public new K Kind {get;}

        public TypeDef(Identifier name, K kind)
            : base(name, core.bw64(kind))
        {
            Kind = kind;
        }

        public override string Format()
            => Kind.ToString();

        public bool Equals(TypeDef<K> src)
            => core.bw64(Kind) == core.bw64(src.Kind);

        public new static TypeDef<K> Empty = new TypeDef<K>(Identifier.Empty, default(K));
    }
}