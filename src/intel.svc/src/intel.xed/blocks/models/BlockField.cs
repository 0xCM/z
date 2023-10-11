//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using Asm;

using static XedModels;

partial class XedZ
{
    public readonly record struct BlockField
    {
        public readonly BlockFieldName Name;

        readonly dynamic Value;

        public BlockField(BlockFieldName name, uint2 value)
        {
            Name = name;
            Value = value;
        }

        public BlockField(BlockFieldName name, uint3 value)
        {
            Name = name;
            Value = value;
        }

        public BlockField(BlockFieldName name, InstPatternBody value)
        {
            Name = name;
            Value = value;
        }

        public BlockField(BlockFieldName name, ASZ value)
        {
            Name = name;
            Value = value;
        }

        public BlockField(BlockFieldName name, InstExtension value)
        {
            Name = name;
            Value = value;
        }

        public BlockField(BlockFieldName name, InstIsa value)
        {
            Name = name;
            Value = value;
        }

        public BlockField(BlockFieldName name, EOSZ value)
        {
            Name = name;
            Value = value;
        }

        public BlockField(BlockFieldName name, EASZ value)
        {
            Name = name;
            Value = value;
        }

        public BlockField(BlockFieldName name, CategoryKind value)
        {
            Name = name;
            Value = value;
        }

        public BlockField(BlockFieldName name, RuleName value)
        {
            Name = name;
            Value = value;
        }

        public BlockField(BlockFieldName name, XedInstClass value)
        {
            Name = name;
            Value = value;
        }

        public BlockField(BlockFieldName name, AsmOpCodeClass value)
        {
            Name = name;
            Value = value;
        }

        public BlockField(BlockFieldName name, bool value)
        {
            Name = name;
            Value = value;
        }

        public BlockField(BlockFieldName name, Hex8 value)
        {
            Name = name;
            Value = value;
        }

        public BlockField(BlockFieldName name, VsibKind value)
        {
            Name = name;
            Value = value;
        }

        public BlockField(BlockFieldName name, MachineMode value)
        {
            Name = name;
            Value = value;
        }

        public BlockField(BlockFieldName name, XedInstForm value)
        {
            Name = name;
            Value = value;
        }

        BlockField(BlockFieldName name, dynamic value)
        {
            Name = name;
            Value = value;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Name == 0 || Value == null;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !IsEmpty;
        }

        public string Format()
            => $"{Value}";

        public override string ToString()
            => Format();

        public static BlockField Empty => new(0,EmptyString);
    }
}
