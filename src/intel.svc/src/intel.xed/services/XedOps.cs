//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static XedModels;

[ApiHost]
public partial class XedOps : AppService<XedOps>
{
    static readonly Index<XedRegId> Regs;

    static readonly ReadOnlySeq<OpWidthRecord> _Widths;

    static readonly ConstLookup<WidthCode,OpWidthRecord> _WidthLookup;

    static readonly Index<PointerWidth> _PointerWidths;

    static readonly Index<PointerWidthInfo> _PointerWidthInfo;

    static XedOps()
    {
        Regs = Symbols.index<XedRegId>().Kinds.ToArray();
        _Widths = Xed.CalcOpWidths();
        _WidthLookup = _Widths.Select(x => (x.Code,x)).ToDictionary();
        _PointerWidths = map(Symbols.index<PointerWidthKind>().View, s => (PointerWidth)s.Kind);
        _PointerWidthInfo = mapi(_PointerWidths.Where(x => x.Kind != 0), (i,w) => w.ToRecord((byte)i));
    }
}
