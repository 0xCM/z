//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

partial class XedRules
{
    [DataWidth(Width), StructLayout(StructLayout,Size =1)]
    public readonly record struct InstOperator : IComparable<InstOperator>
    {
        public const byte Width = num2.Width;

        public const string EqSym = "=";

        public const string NeSym = "!=";

        public static InstOperator None => InstOperatorKind.None;

        public static InstOperator Eq => InstOperatorKind.Eq;

        public static InstOperator Ne => InstOperatorKind.Ne;

        [MethodImpl(Inline)]
        public static InstOperator parse(ReadOnlySpan<char> src)
        {
            var length = src.Length;
            var dst = Empty;
            if(length == 1)
            {
                if(skip(src,0) == '=')
                    dst = Eq;
            }
            else if(length == 2)
            {
                if(skip(src,0) == '!' && skip(src,1) == '=')
                    dst = Ne;
            }
            return dst;
        }

        [MethodImpl(Inline)]
        public static bool parse(ReadOnlySpan<char> src, out InstOperator dst)
        {
            dst = parse(src);
            return dst.IsNonEmpty;
        }

        public InstOperatorKind Kind
        {
            [MethodImpl(Inline)]
            get => @as<InstOperator,InstOperatorKind>(this);
        }

        public num2 Data
        {
            [MethodImpl(Inline)]
            get => @as<InstOperator,num2>(this);
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Data != 0;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => (uint)Data;
        }

        public override int GetHashCode()
            => Hash;

        public bool Equals(InstOperator src)
            => Data == src.Data;

        [MethodImpl(Inline)]
        public ReadOnlySpan<char> Render()
        {
            var dst = default(ReadOnlySpan<char>);
            if(this == Eq)
                dst = EqSym;
            else if(this == Ne)
                dst = NeSym;
            return dst;
        }

        [MethodImpl(Inline)]
        public string Format()
            => text.format(Render());

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public int CompareTo(InstOperator src)
            => Data.CompareTo(src.Data);

        [MethodImpl(Inline)]
        public static implicit operator InstOperator(InstOperatorKind kind)
            => @as<InstOperatorKind,InstOperator>(kind);

        [MethodImpl(Inline)]
        public static implicit operator InstOperatorKind(InstOperator src)
            => src.Kind;

        public static InstOperator Empty => default;
    }
}
