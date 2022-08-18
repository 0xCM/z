//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrTypeSystem
    {
        [DataTypeAttributeD("clr.i8",true)]
        public readonly struct SByte : IType<PrimalKind>
        {
            public Identifier Name => nameof(SByte);

            public PrimalKind Kind => PrimalKind.I8;

            public string Format()
                => Name;
        }
    }
}
