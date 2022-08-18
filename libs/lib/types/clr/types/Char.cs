//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrTypeSystem
    {
        [DataTypeAttributeD("clr.char", true)]
        public readonly struct Char : IType<PrimalKind>
        {
            public Identifier Name => nameof(Char);

            public PrimalKind Kind => PrimalKind.C16;

            public string Format()
                => Name;
        }
    }
}
