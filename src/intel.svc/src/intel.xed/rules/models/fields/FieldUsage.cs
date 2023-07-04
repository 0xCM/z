//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public readonly record struct FieldUsage : IArrow<RuleSig,RuleField>, IComparable<FieldUsage>
        {
            [MethodImpl(Inline)]
            public static FieldUsage left(RuleSig rule, RuleField field)
                => new FieldUsage(rule.IsEncTable ? UsageKind.EncLeft : UsageKind.DecLeft, rule.TableName, field);

            [MethodImpl(Inline)]
            public static FieldUsage right(RuleSig rule, RuleField field)
                => new FieldUsage(rule.IsEncTable ? UsageKind.EncRight : UsageKind.DecRight, rule.TableName, field);

            public readonly UsageKind Kind;

            public readonly RuleName RuleName;

            public readonly RuleField Field;

            [MethodImpl(Inline)]
            public FieldUsage(UsageKind kind, RuleName rule, RuleField field)
            {
                Kind = kind;
                RuleName = rule;
                Field = field;
            }

            public bit Antecedant
            {
                [MethodImpl(Inline)]
                get => (bit)(((byte)Kind >> 2) == 0b01);
            }

            public bit Consequent
            {
                [MethodImpl(Inline)]
                get => (bit)(((byte)Kind >> 2) == 0b10);
            }

            public RuleTableKind TableKind
            {
                [MethodImpl(Inline)]
                get => (RuleTableKind)((byte)Kind & num2.MaxValue);
            }

            public readonly RuleSig Rule
            {
                [MethodImpl(Inline)]
                get => new RuleSig(TableKind, RuleName);
            }

            public Hash32 Hash
            {
                [MethodImpl(Inline)]
                get => Rule.Hash | Field.Hash;
            }

            [MethodImpl(Inline)]
            public bool Equals(FieldUsage src)
                => Rule == src.Rule && Field == src.Field;

            RuleSig IArrow<RuleSig,RuleField>.Source
                => Rule;

            RuleField IArrow<RuleSig,RuleField>.Target
                => Field;

            public override int GetHashCode()
                => Hash;

            [MethodImpl(Inline)]
            public int CompareTo(FieldUsage src)
            {
                var result = Rule.CompareTo(src.Rule);
                if(result == 0)
                {
                    result = ((byte)Kind).CompareTo((byte)src.Kind);
                    if(result == 0)
                        result = Field.CompareTo(src.Field);
                }
                return result;
            }
        }
    }
}