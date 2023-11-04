//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using Asm;

partial class XedModels
{
    public readonly record struct InstBlockField
    {
        public readonly BlockFieldName Name;

        readonly dynamic Value;

        public InstBlockField(BlockFieldName name, bit value)
        {
            Name = name;
            Value = value;
        }

        public InstBlockField(BlockFieldName name, InstAttribs value)
        {
            Name = name;
            Value = value;
        }

        public InstBlockField(BlockFieldName name, WidthCode value)
        {
            Name = name;
            Value = value;
        }

        public InstBlockField(BlockFieldName name, NativeSize value)
        {
            Name = name;
            Value = value;
        }

        public InstBlockField(BlockFieldName name, PatternOps value)
        {
            Name = name;
            Value = value;
        }

        public InstBlockField(BlockFieldName name, byte value)
        {
            Name = name;
            Value = value;
        }

        public InstBlockField(BlockFieldName name, InstCells value)
        {
            Name = name;
            Value = value;
        }

        public InstBlockField(BlockFieldName name, InstExtension value)
        {
            Name = name;
            Value = value;
        }

        public InstBlockField(BlockFieldName name, InstIsa value)
        {
            Name = name;
            Value = value;
        }

        public InstBlockField(BlockFieldName name, EOSZ value)
        {
            Name = name;
            Value = value;
        }

        public InstBlockField(BlockFieldName name, EASZ value)
        {
            Name = name;
            Value = value;
        }

        public InstBlockField(BlockFieldName name, CategoryKind value)
        {
            Name = name;
            Value = value;
        }

        public InstBlockField(BlockFieldName name, RuleName value)
        {
            Name = name;
            Value = value;
        }

        public InstBlockField(BlockFieldName name, OperandClasses value)
        {
            Name = name;
            Value = value;
        }

        public InstBlockField(BlockFieldName name, VL value)
        {
            Name = name;
            Value = value;
        }

        public InstBlockField(BlockFieldName name, XedInstClass value)
        {
            Name = name;
            Value = value;
        }

        public InstBlockField(BlockFieldName name, AsmOpCodeClass value)
        {
            Name = name;
            Value = value;
        }

        public InstBlockField(BlockFieldName name, bool value)
        {
            Name = name;
            Value = value;
        }

        public InstBlockField(BlockFieldName name, Hex8 value)
        {
            Name = name;
            Value = value;
        }

        public InstBlockField(BlockFieldName name, VsibKind value)
        {
            Name = name;
            Value = value;
        }

        public InstBlockField(BlockFieldName name, MachineMode value)
        {
            Name = name;
            Value = value;
        }

        public InstBlockField(BlockFieldName name, XedInstForm value)
        {
            Name = name;
            Value = value;
        }

        InstBlockField(BlockFieldName name)
        {
            Name = name;
            Value = null;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Value is null || Name == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !IsEmpty;
        }

        public dynamic Unwrap()
            => Value;
            
        public string Format()
            => IsEmpty ? EmptyString : $"{Name}: {Value}";

        public override string ToString()
            => Format();

        public static explicit operator InstExtension(InstBlockField src)
            => src.IsEmpty ? default : (InstExtension)src.Value;

        public static explicit operator InstIsa(InstBlockField src)
            =>  src.IsEmpty ? default : (InstIsa)src.Value;

        public static explicit operator EASZ(InstBlockField src)
            => src.IsEmpty ? default : (EASZ)src.Value;

        public static explicit operator EOSZ(InstBlockField src)
            => src.IsEmpty ? default : (EOSZ)src.Value;

        public static explicit operator InstCells(InstBlockField src)
            => src.IsEmpty ? default : (InstCells)src.Value;

        public static explicit operator PatternOps(InstBlockField src)
            => src.IsEmpty ? default : (PatternOps)src.Value;

        public static explicit operator VL(InstBlockField src)
            => src.IsEmpty ? default :  (VL)src.Value;

        public static explicit operator byte(InstBlockField src)
            => src.IsEmpty ? default : (byte)src.Value;

        public static explicit operator Hex8(InstBlockField src)
            => src.IsEmpty ? default : (Hex8)src.Value;

        public static explicit operator AsmOpCodeClass(InstBlockField src)
            => src.IsEmpty ? default : (AsmOpCodeClass)src.Value;

        public static explicit operator XedInstClass(InstBlockField src)
            => src.IsEmpty ? default : (XedInstClass)src.Value;

        public static explicit operator VsibKind(InstBlockField src)
            => src.IsEmpty ? default : (VsibKind)src.Value;

        public static explicit operator MachineMode(InstBlockField src)
            => src.IsEmpty ? default : (MachineMode)src.Value;

        public static explicit operator XedInstForm(InstBlockField src)
            => src.IsEmpty ? default : (XedInstForm)src.Value;

        public static explicit operator bit(InstBlockField src)
            => src.IsEmpty ? default : (bit)src.Value;

        public static explicit operator InstAttribs(InstBlockField src)
            => src.IsEmpty ? default : (InstAttribs)src.Value;

        public static InstBlockField Empty => new(0);
    }
}
