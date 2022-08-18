//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct ClrStructAdapter
    {
        public Type Definition {get;}

        [MethodImpl(Inline)]
        public ClrStructAdapter(Type src)
            => Definition = src;

        public ClrTypeAdapter Generalized
        {
            [MethodImpl(Inline)]
            get => Definition;
        }

        public ClrTypeName Name
        {
            [MethodImpl(Inline)]
            get => new ClrTypeName(Definition);
        }

        [MethodImpl(Inline)]
        public static implicit operator ClrTypeAdapter(ClrStructAdapter src)
            => src.Generalized;

        [MethodImpl(Inline)]
        public static implicit operator Type(ClrStructAdapter src)
            => src.Definition;

        public IEnumerable<ClrStructAdapter> NestedTypes
            => Definition.GetNestedTypes().Select(t => new ClrStructAdapter(t));
    }
}