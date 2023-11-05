//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using Asm;

using static XedModels;
using static MachineModes;

partial class XedRules
{
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly record struct FieldValue : IEquatable<FieldValue>
    {
        public readonly FieldKind Field;

        public readonly ulong Data;

        public readonly RuleCellKind CellKind;

        [MethodImpl(Inline)]
        public FieldValue(FieldKind field, bit data)
        {
            Field = field;
            Data = (byte)data;
            CellKind = 0;
        }

        [MethodImpl(Inline)]
        public FieldValue(FieldKind field, byte data)
        {
            Field = field;
            Data = data;
            CellKind = 0;
        }

        [MethodImpl(Inline)]
        public FieldValue(FieldKind field, num3 data)
        {
            Field = field;
            Data = data;
            CellKind = 0;
        }


        [MethodImpl(Inline)]
        public FieldValue(FieldKind kind, ushort data)
        {
            Field = kind;
            Data = data;
            CellKind = 0;
        }

        [MethodImpl(Inline)]
        public FieldValue(FieldSeg src)
        {
            Field = src.Field;
            Data = (ulong)src.Seg;
            CellKind = RuleCellKind.FieldSeg;
        }

        [MethodImpl(Inline)]
        public FieldValue(FieldKind field, InstSegType type)
        {
            Field = field;
            Data = (ulong)new InstFieldSeg(field, type);
            CellKind = RuleCellKind.InstSeg;
        }

        [MethodImpl(Inline)]
        public FieldValue(RuleKeyword src)
        {
            Field = 0;
            Data = (byte)src;
            CellKind = RuleCellKind.Keyword;
        }

        [MethodImpl(Inline)]
        public FieldValue(WidthVar src)
        {
            Field = 0;
            Data = (byte)src;
            CellKind = RuleCellKind.WidthVar;
        }

        [MethodImpl(Inline)]
        public FieldValue(FieldKind kind, ulong data, RuleCellKind ck = 0)
        {
            Field = kind;
            Data = data;
            CellKind = ck;
        }

        [MethodImpl(Inline)]
        public FieldValue(FieldKind kind, MachineMode data)
        {
            Field = kind;
            Data = (ushort)data;
            CellKind = 0;
        }

        [MethodImpl(Inline)]
        public FieldValue(FieldKind kind, XedRegId data)
        {
            Field = kind;
            Data = (ushort)data;
            CellKind = 0;
        }

        [MethodImpl(Inline)]
        public FieldValue(FieldKind kind, RuleName data)
        {
            Field = kind;
            Data = (ushort)data;
            CellKind =  kind != 0 ? RuleCellKind.NtExpr : RuleCellKind.NtCall;
        }

        [MethodImpl(Inline)]
        public FieldValue(FieldKind kind, XedInstKind data)
        {
            Field = kind;
            Data = (ushort)data;
            CellKind = 0;
        }

        [MethodImpl(Inline)]
        public FieldValue(FieldKind kind, LLRC data)
        {
            Field = kind;
            Data = (ushort)data;
            CellKind = 0;
        }

        [MethodImpl(Inline)]
        public FieldValue(FieldKind kind, EASZ data)
        {
            Field = kind;
            Data = (ushort)data;
            CellKind = 0;
        }

        [MethodImpl(Inline)]
        public FieldValue(FieldKind kind, EOSZ data)
        {
            Field = kind;
            Data = (ushort)data;
            CellKind = 0;
        }

        [MethodImpl(Inline)]
        public FieldValue(FieldKind kind, ChipCode data)
        {
            Field = kind;
            Data = (uint)data;
            CellKind = 0;
        }

        [MethodImpl(Inline)]
        public FieldValue(FieldKind kind, AsmVL data)
        {
            Field = kind;
            Data = (uint)data;
            CellKind = 0;
        }

        [MethodImpl(Inline)]
        public FieldValue(FieldKind kind, BroadcastKind data)
        {
            Field = kind;
            Data = (uint)data;
            CellKind = 0;
        }

        public readonly bit IsNontermCall
        {
            [MethodImpl(Inline)]
            get => CellKind == RuleCellKind.NtCall;
        }

        public readonly bit IsNontermExpr
        {
            [MethodImpl(Inline)]
            get => CellKind == RuleCellKind.NtExpr;
        }

        public readonly bit IsNonterm
        {
            [MethodImpl(Inline)]
            get => IsNontermCall || IsNontermExpr;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Field == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Field != 0;
        }

        [MethodImpl(Inline)]
        public bool Equals(FieldValue src)
            => Field == src.Field && Data == src.Data;

        public uint Hash
        {
            [MethodImpl(Inline)]
            get => (uint)((ulong)Field << 24 | (Data & 0xFFFFFF));
        }

        public override int GetHashCode()
            => (int)Hash;

        public string Format()
            => XedRender.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public VexValid ToVexClass()
            => (VexValid)Data;

        [MethodImpl(Inline)]
        public AsmVL ToVL()
            => (AsmVL)Data;

        [MethodImpl(Inline)]
        public XedVexKind ToVexKind()
            => (XedVexKind)Data;

        [MethodImpl(Inline)]
        public MachineMode ToMode()
            => (MachineModeClass)Data;

        [MethodImpl(Inline)]
        public RuleKeyword ToKeyword()
            => RuleKeyword.from((KeywordKind)Data);

        [MethodImpl(Inline)]
        public XedRegId ToReg()
            => (XedRegId)Data;

        [MethodImpl(Inline)]
        public SegVar ToSegVar()
            => (SegVar)Data;

        [MethodImpl(Inline)]
        public WidthVar ToWidthVar()
            => (WidthVar)Data;

        [MethodImpl(Inline)]
        public FieldSeg ToSegField()
            => new FieldSeg(Field, (SegVar)Data);

        [MethodImpl(Inline)]
        public XedInstClass ToInstClass()
            => (XedInstKind)Data;

        [MethodImpl(Inline)]
        public ChipCode ToChip()
            => (ChipCode)Data;

        [MethodImpl(Inline)]
        public XedModels.RepPrefix ToRepPrefix()
            => (XedModels.RepPrefix)Data;

        [MethodImpl(Inline)]
        public BroadcastKind ToBCast()
            => (BroadcastKind)Data;

        [MethodImpl(Inline)]
        public LLRC ToLLRC()
            => (LLRC)Data;

        [MethodImpl(Inline)]
        public EOSZ ToEOSZ()
            => (EOSZ)Data;

        [MethodImpl(Inline)]
        public EASZ ToEASZ()
            => (EASZ)Data;

        [MethodImpl(Inline)]
        public bit ToBit()
            => (bit)Data;

        [MethodImpl(Inline)]
        public byte ToByte()
            => (byte)Data;

        [MethodImpl(Inline)]
        public ushort ToWord()
            => (ushort)Data;

        [MethodImpl(Inline)]
        public Hex8 ToHex8()
            => (Hex8)Data;

        [MethodImpl(Inline)]
        public uint5 ToBinaryLiteral()
            => (uint5)Data;

        [MethodImpl(Inline)]
        public RuleName ToRuleName()
            => (RuleName)Data;

        [MethodImpl(Inline)]
        public Nonterminal ToNonterm()
            => (RuleName)Data;

        [MethodImpl(Inline)]
        public InstFieldSeg ToInstSeg()
            => (InstFieldSeg)Data;

        [MethodImpl(Inline)]
        public static implicit operator EASZ(FieldValue src)
            => src.ToEASZ();

        [MethodImpl(Inline)]
        public static implicit operator LLRC(FieldValue src)
            => src.ToLLRC();

        [MethodImpl(Inline)]
        public static implicit operator EOSZ(FieldValue src)
            => src.ToEOSZ();

        [MethodImpl(Inline)]
        public static implicit operator VexValid(FieldValue src)
            => src.ToVexClass();

        [MethodImpl(Inline)]
        public static implicit operator AsmVL(FieldValue src)
            => src.ToVL();

        [MethodImpl(Inline)]
        public static implicit operator XedVexKind(FieldValue src)
            => src.ToVexKind();

        [MethodImpl(Inline)]
        public static implicit operator MachineModeClass(FieldValue src)
            => src.ToMode();

        [MethodImpl(Inline)]
        public static implicit operator XedInstKind(FieldValue src)
            => src.ToInstClass();

        [MethodImpl(Inline)]
        public static implicit operator ChipCode(FieldValue src)
            => src.ToChip();

        [MethodImpl(Inline)]
        public static implicit operator BroadcastKind(FieldValue src)
            => src.ToBCast();

        [MethodImpl(Inline)]
        public static implicit operator XedModels.RepPrefix(FieldValue src)
            => src.ToRepPrefix();

        [MethodImpl(Inline)]
        public static implicit operator bit(FieldValue src)
            => src.ToBit();

        public static FieldValue Empty => default;
    }
}
