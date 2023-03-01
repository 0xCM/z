//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Lang
{
    public record class ConstGroup
    {
        public readonly @string Name;

        public readonly @string Spec;

        public ConstGroup(@string name, @string spec)
        {
            Name = name;
            Spec = spec;
        }

        public string Format()
            => $"{Name}: {Spec}";

        public override string ToString()
            => Format();
    }
}