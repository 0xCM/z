//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Lang.Dot
{
    public record class Attribute : Statement
    {
        public readonly @string Name;

        readonly object Value;

        protected Attribute(string name, object value)
        {
            Name = name;
            Value = value;
        }         

        public override string Format()
            => $"{Name}={Value}";

    }
}
