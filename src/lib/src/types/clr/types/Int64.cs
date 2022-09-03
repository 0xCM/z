//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrTypeSystem
    {
        [DataTypeAttributeD("clr.i64",true)]
        public readonly struct Int64 : IType<PrimalKind>
        {
            public Identifier Name => nameof(Int64);

            public PrimalKind Kind => PrimalKind.I64;

            public string Format()
                => Name;
        }
    }
}
