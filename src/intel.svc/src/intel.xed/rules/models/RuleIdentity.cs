//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static XedModels;

partial class XedRules
{
    [DataWidth(PackedWidth)]
    public readonly record struct RuleIdentity : IComparable<RuleIdentity>
    {
        public const byte PackedWidth = num2.Width + num9.Width;

        const ushort KindMask = 0xF000;

        const ushort NameMask = 0x0FFF;

        const ushort KindOffset = 12;

        readonly ushort Data;

        [MethodImpl(Inline)]
        public RuleIdentity(RuleTableKind kind, RuleName name)
        {
            Data = (ushort)((ushort)name | ((ushort)kind << KindOffset));
        }

        [MethodImpl(Inline)]
        public RuleIdentity(ushort data)
        {
            Data = data;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public RuleName TableName
        {
            [MethodImpl(Inline)]
            get => (RuleName)(Data & NameMask);
        }

        public RuleTableKind TableKind
        {
            [MethodImpl(Inline)]
            get => (RuleTableKind)((Data & KindMask) >> KindOffset);
        }

        public bool IsEncTable
        {
            [MethodImpl(Inline)]
            get => TableKind == RuleTableKind.ENC;
        }

        public bool IsDecTable
        {
            [MethodImpl(Inline)]
            get => TableKind == RuleTableKind.DEC;
        }

        public readonly bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data == 0;
        }

        public readonly bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => TableKind != 0 && TableName != 0;
        }

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public int CompareTo(RuleIdentity src)
        {
            var result = Xed.cmp(TableName,src.TableName);
            if(result == 0)
                result = Xed.cmp(TableKind, src.TableKind);
            return result;
        }

        public string Format()
            => IsEmpty ? EmptyString : string.Format("{0}.{1}", TableName, TableKind.ToString().ToUpper());

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static explicit operator ushort(RuleIdentity src)
            => src.Data;

        [MethodImpl(Inline)]
        public static explicit operator RuleIdentity(ushort src)
            => new (src);

        [MethodImpl(Inline)]
        public static implicit operator RuleIdentity((RuleTableKind kind, RuleName name) src)
            => new (src.kind,src.name);

        public static RuleIdentity Empty => default;
    }
}
