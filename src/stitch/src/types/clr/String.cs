//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrTypeSystem
    {
        public readonly struct String : IType<PrimalKind>
        {
            public Identifier Name => nameof(String);

            public PrimalKind Kind => PrimalKind.String;

            public string Format()
                => Name;
        }
    }
}
