//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrTypeSystem
    {

        [DataTypeAttributeD("clr.decimal",true)]
        public readonly struct Decimal : IType<PrimalKind>
        {
            public Identifier Name => nameof(Decimal);

            public PrimalKind Kind => PrimalKind.F128;

            public string Format()
                => Name;
        }
    }
}
