//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Reflection.Emit;

    [ApiHost]
    public partial class CellDelegates
    {
        const NumericKind Closure = Integers;

        [MethodImpl(Inline)]
        public static CellDelegate define(OpIdentity id, MemoryAddress src, DynamicMethod enclosure, Delegate dynop)
            => CellDelegate.define(id, src, enclosure, dynop);

        [MethodImpl(Inline)]
        public static CellDelegate define(Identifier id, MemoryAddress src, DynamicMethod enclosure, Delegate dynop)
            => CellDelegate.define(id, src, enclosure, dynop);
    }
}