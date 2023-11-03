//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using Asm;

using static XedModels;

partial class XedInstBlocks
{
    public readonly record struct BlockField
    {
        public readonly BlockFieldName Name;

        readonly dynamic Value;

        public BlockField(BlockFieldName name, bit value)
        {
            Name = name;
            Value = value;
        }

        public BlockField(BlockFieldName name, InstAttribs value)
        {
            Name = name;
            Value = value;
        }

        public BlockField(BlockFieldName name, WidthCode value)
        {
            Name = name;
            Value = value;
        }

        public BlockField(BlockFieldName name, NativeSize value)
        {
            Name = name;
            Value = value;
        }

        public BlockField(BlockFieldName name, PatternOps value)
        {
            Name = name;
            Value = value;
        }

        public BlockField(BlockFieldName name, byte value)
        {
            Name = name;
            Value = value;
        }

        public BlockField(BlockFieldName name, InstCells value)
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

        public BlockField(BlockFieldName name, OperandClasses value)
        {
            Name = name;
            Value = value;
        }

        public BlockField(BlockFieldName name, VL value)
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
            get => Name == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !IsEmpty;
        }

        public string Format()
            => $"{Name}: {Value}";

        public override string ToString()
            => Format();

        public static explicit operator InstExtension(BlockField src)
            => (InstExtension)src.Value;

        public static explicit operator InstIsa(BlockField src)
            => (InstIsa)src.Value;

        public static explicit operator EASZ(BlockField src)
            => (EASZ)src.Value;

        public static explicit operator EOSZ(BlockField src)
            => (EOSZ)src.Value;

        public static explicit operator InstCells(BlockField src)
            => (InstCells)src.Value;

        public static explicit operator PatternOps(BlockField src)
            => (PatternOps)src.Value;

        public static explicit operator VL(BlockField src)
            => (VL)src.Value;

        public static explicit operator byte(BlockField src)
            => (byte)src.Value;

        public static explicit operator Hex8(BlockField src)
            => (Hex8)src.Value;

        public static explicit operator AsmOpCodeClass(BlockField src)
            => (AsmOpCodeClass)src.Value;

        public static explicit operator XedInstClass(BlockField src)
            => (XedInstClass)src.Value;

        public static explicit operator VsibKind(BlockField src)
            => (VsibKind)src.Value;

        public static explicit operator MachineMode(BlockField src)
            => (MachineMode)src.Value;

        public static explicit operator XedInstForm(BlockField src)
            => (XedInstForm)src.Value;

        public static explicit operator bit(BlockField src)
            => (bit)src.Value;

        public static explicit operator InstAttribs(BlockField src)
            => (InstAttribs)src.Value;

        public static BlockField Empty => new(0,EmptyString);
    }
}
