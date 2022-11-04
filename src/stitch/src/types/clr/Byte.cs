//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrTypeSystem
    {
        public readonly struct Byte : IType<PrimalKind>
        {
            public Identifier Name => nameof(Byte);

            public PrimalKind Kind => PrimalKind.U8;

            public string Format()
                => Name;
        }
    }
}
