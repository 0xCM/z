//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using KW = XedRules.KeywordKind;

partial class XedRules
{
    public readonly struct RuleKeyword
    {
        internal const byte PackedWidth = 3;

        internal const byte AlignedWidth = 8;

        public static DataSize DataSize => new (PackedWidth, AlignedWidth);

        public const XedRegId WildcardReg = (XedRegId)(XedRegId.ZMM31 + 1);

        [MethodImpl(Inline)]
        public static bool IsWildcard(XedRegId src)
            => src == WildcardReg;

        [MethodImpl(Inline)]
        public static bool IsWildcard(string src)
            => src == "@";

        public static RuleKeyword keyword(XedRegId src)
            => IsWildcard(src) ? RuleKeyword.Wildcard : Empty;

        public static RuleKeyword from(KeywordKind kind)
            => kind switch
            {
                KW.Else => Else,
                KW.Default => Default,
                KW.Error => Error,
                KW.Null => Null,
                KW.Wildcard => Wildcard,
                _ => RuleKeyword.Empty
            };

        public static bool parse(string src, out RuleKeyword dst)
        {
            var result = false;
            var input = text.trim(src);
            dst = RuleKeyword.Empty;
            switch(input)
            {
                case "default":
                    dst = RuleKeyword.Default;
                    result = true;
                    break;
                case "otherwise":
                    dst = RuleKeyword.Else;
                    result = true;
                break;
                case "nothing":
                    dst = RuleKeyword.Null;
                    result = true;
                break;
                case "error":
                    dst = RuleKeyword.Error;
                    result = true;
                break;
                case "@":
                    dst = RuleKeyword.Wildcard;
                    result = true;
                break;
            }

            return result;
        }

        public static RuleKeyword Wildcard => new RuleKeyword(KW.Wildcard, "@");

        public static RuleKeyword Null => new RuleKeyword(KW.Null, "null");

        public static RuleKeyword Default => new RuleKeyword(KW.Default, "default");

        public static RuleKeyword Else => new RuleKeyword(KW.Else, "else");

        public static RuleKeyword Error => new RuleKeyword(KW.Error, "error");

        readonly ByteBlock16 Data;

        [MethodImpl(Inline)]
        RuleKeyword(KeywordKind kind, asci8 src)
        {
            var data = ByteBlock16.Empty;
            data = (ulong)src;
            data[15] = (byte)kind;
            Data = data;
        }

        public KeywordKind KeywordKind
        {
            [MethodImpl(Inline)]
            get => sys.@as<KeywordKind>(Data[15]);
        }

        [MethodImpl(Inline)]
        public asci8 ToAsci()
            => (asci8)Data.A;

        [MethodImpl(Inline)]
        public bool Equals(RuleKeyword src)
            => Data.Equals(src.Data);

        public override int GetHashCode()
            => Data.GetHashCode();

        public override bool Equals(object src)
            => src is RuleKeyword x && Equals(x);

        public string Format()
            => XedRender.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static bool operator ==(RuleKeyword a, RuleKeyword b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator !=(RuleKeyword a, RuleKeyword b)
            => !a.Equals(b);

        [MethodImpl(Inline)]
        public static explicit operator byte(RuleKeyword src)
            => (byte)src.KeywordKind;

        [MethodImpl(Inline)]
        public static implicit operator RuleKeyword(KeywordKind src)
            => from(src);

        [MethodImpl(Inline)]
        public static implicit operator KeywordKind(RuleKeyword src)
            => src.KeywordKind;

        [MethodImpl(Inline)]
        public static explicit operator asci8(RuleKeyword src)
            => src.ToAsci();

        public static RuleKeyword Empty => default;
    }
}
