//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct XmlLevel
    {
        public sbyte Depth {get;}

        public string Name {get;}

        [MethodImpl(Inline)]
        public XmlLevel(sbyte depth, string name)
        {
            Depth = depth;
            Name = name;
        }

        [MethodImpl(Inline)]
        public static implicit operator XmlLevel((int depth, string name) src)
            => new XmlLevel((sbyte)src.depth, src.name);
    }
}