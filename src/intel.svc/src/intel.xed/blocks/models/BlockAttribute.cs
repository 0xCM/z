//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

partial class XedModels
{
    public readonly record struct BlockAttribute
    {
        public readonly BlockFieldName Field;

        public readonly string Value;

        public BlockAttribute(BlockFieldName name, string value)
        {
            Field = name;
            Value = value;
        }

        public bool IsNonEmpty
        {
            get => Field != 0 || nonempty(Value);
        }
        public static BlockAttribute Empty => new(default,EmptyString);
    }
}
