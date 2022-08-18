//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = BitPatterns;

    [StructLayout(StructLayout,Pack=1), Record(TableId)]
    public readonly record struct BpDef : IBpDef
    {
        const string TableId = "bits.patterns.defs";

        /// <summary>
        /// The name of the pattern source
        /// </summary>
        [Render(32)]
        public readonly BfOrigin Origin;

        /// <summary>
        /// The pattern name
        /// </summary>
        [Render(32)]
        public readonly asci32 Name;

        /// <summary>
        /// The pattern content
        /// </summary>
        [Render(1)]
        public readonly BitPattern Pattern;

        [MethodImpl(Inline)]
        public BpDef(in asci32 name, in BitPattern pattern, BfOrigin origin)
        {
            Name = name;
            Pattern = pattern;
            Origin = origin;
        }

        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();

        BpCalcs IBpDef.Calcs
            => api.calcs(this);

        asci32 IBpDef.Name
            => Name;

        BitPattern IBpDef.Pattern
            => Pattern;

        BfOrigin IBpDef.Origin
            => Origin;
    }
}