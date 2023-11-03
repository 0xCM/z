//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

partial class XedInstBlocks
{
    public readonly record struct Attribute
    {
        public readonly BlockFieldName Field;

        public readonly string Value;

        public Attribute(BlockFieldName name, string value)
        {
            Field = name;
            Value = value;
        }

        public bool IsNonEmpty
        {
            get => Field != 0 || nonempty(Value);
        }
        public static Attribute Empty => new(default,EmptyString);
    }
}
