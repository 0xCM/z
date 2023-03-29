//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public readonly struct AsmExpr : IEquatable<AsmExpr>, IComparable<AsmExpr>
    {
        [Parser]
        public static bool parse(string src, out AsmExpr dst)
        {
            var body = src.Trim();
            var i = text.index(body, Chars.Space);
            dst = i > 0 ? new AsmExpr(string.Format("{0} {1}", text.left(body,i), text.right(body,i).Trim())) : new AsmExpr(body);
            return true;
        }

        public static Outcome parse(ReadOnlySpan<AsciCode> src, out AsmExpr dst)
        {
            dst = AsmExpr.Empty;
            var outcome = Outcome.Success;
            var i = SQ.SkipWhitespace(src);
            if(i == NotFound)
                return (false,"Input was empty");

            var remainder = slice(src,i);
            i = SQ.index(remainder, AsciCode.Space);
            if(i == NotFound)
            {
                var monic = new AsmMnemonic(AsciSymbols.format(remainder).Trim());
                var operands = Span<char>.Empty;
                dst = AsmExpr.define(monic, operands);
            }
            else
            {
                var monic = new AsmMnemonic(AsciSymbols.format(slice(remainder,0, i)).Trim());
                var operands = AsciSymbols.format(slice(remainder,i)).Trim();
                dst = AsmExpr.define(monic, operands);
            }

            return outcome;
        }

        [Op]
        public static AsmExpr define(AsmMnemonic monic, ReadOnlySpan<char> operands)
            => new AsmExpr(string.Format("{0} {1}", monic.Format(MnemonicCase.Lowercase), text.format(operands)));

        public readonly TextBlock Content;

        const sbyte DefaultPadding = -46;

        [MethodImpl(Inline)]
        public AsmExpr(TextBlock content)
            => Content = content;

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public string Format()
            => Content.Format();

        public ReadOnlySpan<char> Data
        {
            [MethodImpl(Inline)]
            get => Content.View;
        }

        public string FormatPadded(int padding = DefaultPadding)
            => string.Format(RpOps.pad(padding), Content);

        [MethodImpl(Inline)]
        public bool Equals(AsmExpr src)
            => Content.Equals(src.Content);

        public override int GetHashCode()
            => Content.GetHashCode();

        public override bool Equals(object src)
            => src is AsmExpr x && Equals(x);

        public AsmExpr Replace(string src, string dst)
            => new AsmExpr(Content.Replace(src,dst));

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Content.IsNonEmpty;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Content.IsEmpty;
        }

        public bool IsValid
        {
            [MethodImpl(Inline)]
            get => IsNonEmpty && !Content.StartsWith("(bad)");
        }

        public bool IsInvalid
        {
            [MethodImpl(Inline)]
            get => IsEmpty || Content.StartsWith("(bad)");
        }

        [MethodImpl(Inline)]
        public int CompareTo(AsmExpr src)
            => Content.CompareTo(src.Content);

        [MethodImpl(Inline)]
        public static implicit operator AsmExpr(string src)
            => new AsmExpr(src);

        [MethodImpl(Inline)]
        public static implicit operator AsmExpr(ReadOnlySpan<char> src)
            => new AsmExpr(new string(src));

        [MethodImpl(Inline)]
        public static implicit operator AsmExpr(Span<char> src)
            => new AsmExpr(new string(src));

        public static AsmExpr Empty
        {
            [MethodImpl(Inline)]
            get => new AsmExpr(TextBlock.Empty);
        }
    }
}