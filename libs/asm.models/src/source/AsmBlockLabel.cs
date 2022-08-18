//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Represents a syntactically-valid label
    /// </summary>
    public readonly struct AsmBlockLabel : IAsmSourcePart
    {
        public static Outcome parse(in AsciLineCover src, out AsmBlockLabel label, out AsmExpr expr)
        {
            label = AsmBlockLabel.Empty;
            expr = AsmExpr.Empty;
            var content = src.Codes;
            var i = SQ.index(content, AsciCode.Colon);
            if(i < 0)
                return false;

            label = new AsmBlockLabel(Asci.format(SQ.left(content, i)).Trim());
            expr = Asci.format(SQ.right(content, i)).Replace(Chars.Tab,Chars.Space).Trim();

            return true;
        }

        [Parser]
        public static bool parse(string src, out AsmBlockLabel dst)
        {
            var i = text.index(src, Chars.Colon);
            if(i > 0)
            {
                dst = new AsmBlockLabel(text.left(src,i).Trim());
                return true;
            }
            else
            {
                dst = AsmBlockLabel.Empty;
                return false;
            }
        }

        public readonly Identifier Name;

        [MethodImpl(Inline)]
        public AsmBlockLabel(Identifier name)
            => Name = name;

        AsmCellKind IAsmSourcePart.PartKind
        {
            [MethodImpl(Inline)]
            get => AsmCellKind.BlockLabel;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsNonEmpty;
        }

        public string Format()
            => Name.IsEmpty ? EmptyString : string.Format("{0}:", Name);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator AsmBlockLabel(string src)
            => new AsmBlockLabel(src);

        [MethodImpl(Inline)]
        public static implicit operator AsmLabel(AsmBlockLabel src)
            => new AsmLabel(src.Name);

        [MethodImpl(Inline)]
        public static implicit operator AsmCell(AsmBlockLabel src)
            => AsmCell.define(src.Format(), AsmCellKind.BlockLabel);

        public static AsmBlockLabel Empty
        {
            [MethodImpl(Inline)]
            get => new AsmBlockLabel(Identifier.Empty);
        }
    }
}