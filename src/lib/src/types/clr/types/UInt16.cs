//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrTypeSystem
    {
        public readonly struct UInt16 : IType<PrimalKind>
        {
            public Identifier Name => nameof(UInt16);

            public PrimalKind Kind => PrimalKind.U16;

            public string Format()
                => Name;
        }
    }
}
