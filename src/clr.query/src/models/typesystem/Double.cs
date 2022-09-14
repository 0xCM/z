//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrTypeSystem
    {
        public readonly struct Double : IType<PrimalKind>
        {
            public Identifier Name => nameof(Double);

            public PrimalKind Kind => PrimalKind.F64;

            public string Format()
                => Name;
        }
    }
}
