//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrTypeSystem
    {
        public readonly struct UInt32 : IType<PrimalKind>
        {
            public Identifier Name => nameof(UInt32);

            public PrimalKind Kind => PrimalKind.U32;

            public string Format()
                => Name;
        }
    }
}
