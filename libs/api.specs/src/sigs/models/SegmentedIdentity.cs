//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct SegmentedIdentity
    {
        [MethodImpl(Inline)]
        public static SegmentedIdentity define(TypeIndicator indicator, NativeTypeWidth w, NumericKind nk)
            => new SegmentedIdentity(indicator, (CpuCellWidth)w, nk);

        [MethodImpl(Inline)]
        public static SegmentedIdentity from(string text)
            => new SegmentedIdentity(text);

        public NativeTypeWidth TypeWidth {get;}

        public TypeIndicator Indicator {get;}

        public NumericKind SegKind {get;}

        public string Identifier {get;}

        [MethodImpl(Inline)]
        public SegmentedIdentity(NumericKind nk)
        {
            Identifier = nk.KeywordNot();
            Indicator = TypeIndicator.Empty;
            SegKind = nk;
            TypeWidth = (NativeTypeWidth)nk.Width();
        }

        [MethodImpl(Inline)]
        public SegmentedIdentity(string text)
        {
            Identifier = text;
            Indicator = TypeIndicator.Empty;
            SegKind = NumericKind.None;
            TypeWidth = 0;
        }

        [MethodImpl(Inline)]
        public SegmentedIdentity(NativeTypeWidth tw, CpuCellWidth cw, NumericKind nk)
        {
            TypeWidth = tw;
            Indicator = default;
            SegKind = nk;
            Identifier = EmptyString;
        }

        [MethodImpl(Inline)]
        public SegmentedIdentity(TypeIndicator indicator, CpuCellWidth width, NumericKind kind)
        {
            Indicator = indicator;
            TypeWidth = (NativeTypeWidth)width;
            SegKind = kind;
            if(TypeWidth == 0 && kind == 0)
                Identifier = string.Empty;
            else
                Identifier = $"{indicator}{(int)TypeWidth}{IDI.SegSep}{kind.Width()}{(char)kind.Indicator()}";
        }

        public TypeIdentity AsTypeIdentity()
            => TypeIdentity.define(Identifier);

        [MethodImpl(Inline)]
        public bool Equals(SegmentedIdentity src)
            => Identifier.Equals(src.Identifier);

        public string Format()
            => Identifier;

        public int CompareTo(SegmentedIdentity src)
            => Identifier.CompareTo(src.Identifier);

         public override int GetHashCode()
            => (int)Identifier.GetHashCode();

        public override bool Equals(object src)
            => src is SegmentedIdentity x && Equals(x);

        public override string ToString()
            => Identifier;

        [MethodImpl(Inline)]
        public static implicit operator SegmentedIdentity(NumericKind src)
            => new SegmentedIdentity(src);

        [MethodImpl(Inline)]
        public static implicit operator string(SegmentedIdentity src)
            => src.Identifier;

        [MethodImpl(Inline)]
        public static implicit operator TypeIdentity(SegmentedIdentity src)
            => src.AsTypeIdentity();

        [MethodImpl(Inline)]
        public static bool operator==(SegmentedIdentity a, SegmentedIdentity b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator!=(SegmentedIdentity a, SegmentedIdentity b)
            => !a.Equals(b);

        public static implicit operator SegmentedIdentity((TypeIndicator si, CpuCellWidth w, CpuCellWidth t, NumericIndicator i) src)
            => new SegmentedIdentity(src.si, src.w, ((NumericWidth)src.t).ToNumericKind(src.i));

        public static SegmentedIdentity Empty
            => new SegmentedIdentity(TypeIndicator.Empty, CpuCellWidth.None, NumericKind.None);
    }
}