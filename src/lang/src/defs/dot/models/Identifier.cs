//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Lang.Dot
{
    public record class Identifier
    {
        readonly @string Definition;

        public Identifier(string def)
        {
            Definition = def;
        }

        public string Format()
            => Definition;

        public override string ToString()
            => Format();
    }
}
