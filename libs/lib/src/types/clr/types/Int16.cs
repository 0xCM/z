//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrTypeSystem
    {
        [DataTypeAttributeD("clr.i16",true)]
        public readonly struct Int16 : IType<PrimalKind>
        {
            public Identifier Name => nameof(Int16);

            public PrimalKind Kind => PrimalKind.I16;

            public string Format()
                => Name;
        }
    }
}
