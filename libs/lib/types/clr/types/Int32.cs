//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrTypeSystem
    {
        [DataTypeAttributeD("clr.i32",true)]
        public readonly struct Int32 : IType<PrimalKind>
        {
            public Identifier Name => nameof(Int32);

            public PrimalKind Kind => PrimalKind.I32;

            public string Format()
                => Name;
        }
    }
}
