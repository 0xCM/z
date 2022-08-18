//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential,Size=4)]
        public readonly record struct RuleCaller : IComparable<RuleCaller>
        {
            public ushort Value
            {
                [MethodImpl(Inline)]
                get => (ushort)(core.@as<RuleCaller,uint>(this) >> 16);
            }

            public Kind Sort
            {
                [MethodImpl(Inline)]
                get => core.@as<RuleCaller,Kind>(this);
            }

            [MethodImpl(Inline)]
            public RuleCaller(RuleSig src)
                => this = Bitfields.join((ushort)Kind.Rule, (ushort)src);

            [MethodImpl(Inline)]
            public RuleCaller(InstPattern src)
                => this = Bitfields.join((ushort)Kind.Rule, (ushort)src.PatternId);

            public string Format()
            {
                var dst = EmptyString;
                if(Sort == Kind.Rule)
                    dst = ((RuleSig)this).Format();
                else
                    dst = string.Format("Inst_{0:D5}", (ushort)Value);
                return dst;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Sort == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Sort != 0;
            }

            public bool IsRule
            {
                [MethodImpl(Inline)]
                get => Sort == Kind.Rule;
            }

            [MethodImpl(Inline)]
            public RuleSig ToRule()
                => @as<ushort,RuleSig>(Value);

            public override string ToString()
                => Format();

            public override int GetHashCode()
                => (int)this;

            [MethodImpl(Inline)]
            public bool Equals(RuleCaller src)
                => (uint)this == (uint)src;

            public int CompareTo(RuleCaller src)
            {
                var result = ((byte)Sort).CompareTo((byte)src.Sort);
                if(result == 0)
                {
                    if(Sort == Kind.Rule)
                        result = ((RuleSig)this).CompareTo((RuleSig)src);
                    else
                        result = Value.CompareTo(src.Value);
                }
                return result;
            }

            [MethodImpl(Inline)]
            public static implicit operator RuleCaller(uint src)
                => @as<uint,RuleCaller>(src);

            [MethodImpl(Inline)]
            public static implicit operator RuleCaller(RuleSig src)
                => new RuleCaller(src);

            [MethodImpl(Inline)]
            public static implicit operator RuleCaller(InstPattern src)
                => new RuleCaller(src);

            [MethodImpl(Inline)]
            public static explicit operator RuleSig(RuleCaller src)
                => (RuleSig)src.Value;

            [MethodImpl(Inline)]
            public static explicit operator uint(RuleCaller src)
                => @as<RuleCaller,uint>(src);

            [MethodImpl(Inline)]
            public static explicit operator int(RuleCaller src)
                => @as<RuleCaller,int>(src);

            public enum Kind : byte
            {
                None,

                Rule,

                Inst,
            }

            public static RuleCaller Empty => default;
        }
    }
}