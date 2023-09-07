//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Reflection.Emit;

    public readonly struct CellDelegate
    {
        [MethodImpl(Inline)]
        public static CellDelegate define(OpIdentity id, MemoryAddress src, DynamicMethod enclosure, Delegate dynop)
            => new (id.Format(), src,enclosure,dynop);

        [MethodImpl(Inline)]
        public static CellDelegate define(Identifier id, MemoryAddress src, DynamicMethod enclosure, Delegate dynop)
            => new (id, src,enclosure,dynop);

        public Identifier Name {get;}

        public MemoryAddress SourceAddress {get;}

        public DynamicMethod Enclosure {get;}

        public Delegate Operation {get;}

        [MethodImpl(Inline)]
        public CellDelegate(Identifier name, MemoryAddress src, DynamicMethod enclosure, Delegate dynop)
        {
            Name = name;
            SourceAddress = src;
            Enclosure = enclosure;
            Operation = dynop;
        }

        [MethodImpl(Inline)]
        public static implicit operator Delegate(CellDelegate src)
            => src.Operation;
    }
}