//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrTypeSystem
    {
        [DataTypeAttributeD("clr.float",true)]
        public readonly struct Float : IType<PrimalKind>
        {
            public Identifier Name => nameof(Float);

            public PrimalKind Kind => PrimalKind.F32;

            public string Format()
                => Name;
        }
    }
}
