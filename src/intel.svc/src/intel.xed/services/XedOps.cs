//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static XedModels;

    [ApiHost]
    public partial class XedOps : AppService<XedOps>
    {
        static Index<XedRegId> Regs;

        static Index<OpWidthRecord> _Widths;

        static ConstLookup<OpWidthCode,OpWidthRecord> _WidthLookup;

        static Index<PointerWidth> _PointerWidths;

        static Index<PointerWidthInfo> _PointerWidthInfo;

        static XedOps()
        {
            Regs = Symbols.index<XedRegId>().Kinds.ToArray();
            _Widths = CalcOpWidths();
            _WidthLookup = _Widths.Select(x => (x.Code,x)).ToDictionary();
            _PointerWidths = map(Symbols.index<PointerWidthKind>().View, s => (PointerWidth)s.Kind);
            _PointerWidthInfo = mapi(PointerWidths.Where(x => x.Kind != 0), (i,w) => w.ToRecord((byte)i));
        }
    }
}