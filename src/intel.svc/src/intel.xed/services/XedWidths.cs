//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static sys;

    public class XedWidths
    {
        internal XedWidths(ReadOnlySeq<OpWidthDetail> widths)
        {
            _Widths = widths;
            _WidthLookup = _Widths.Select(x => (x.Code,x)).ToDictionary();
            _PointerWidths = map(Symbols.index<PointerWidthKind>().View, s => (PointerWidth)s.Kind);
            _PointerWidthInfo = mapi(_PointerWidths.Where(x => x.Kind != 0), (i,w) => w.ToRecord((byte)i));
        }

        ReadOnlySeq<OpWidthDetail> _Widths;

        ConstLookup<WidthCode,OpWidthDetail> _WidthLookup;

        ReadOnlySeq<PointerWidth> _PointerWidths;

        ReadOnlySeq<PointerWidthInfo> _PointerWidthInfo;

        public ref readonly ReadOnlySeq<OpWidthDetail> OpWidths => ref _Widths;

        public ref readonly ReadOnlySeq<PointerWidth> PointerWidths => ref _PointerWidths;

        public ref readonly ReadOnlySeq<PointerWidthInfo> PointerWidthDescriptions => ref _PointerWidthInfo;


    }
}