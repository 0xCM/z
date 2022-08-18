//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrTypeSystem
    {
        [DataTypeAttributeD("clr.bool",true)]
        public readonly struct Bool : IType<PrimalKind>
        {
            public Identifier Name => nameof(Bool);

            public PrimalKind Kind => PrimalKind.U1;

            public string Format()
                => Name;
        }
    }
}
