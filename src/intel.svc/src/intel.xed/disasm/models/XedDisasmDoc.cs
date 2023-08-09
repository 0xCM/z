//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

public class XedDisasmDoc
{
    public readonly XedDisasmSummary Summary;

    public readonly XedDisasmDetail Detail;

    [MethodImpl(Inline)]
    public XedDisasmDoc(XedDisasmSummary summary, XedDisasmDetail detail)
    {
        Summary = summary;
        Detail = detail;
    }

    public FilePath SourcePath => Summary.DataSource;

    public ref readonly Index<XedDisasmDetailBlock> DetailBlocks
    {
        [MethodImpl(Inline)]
        get => ref Detail.Blocks;
    }

    [MethodImpl(Inline)]
    public void Deconstruct(out XedDisasmSummary s, out XedDisasmDetail d)
    {
        s = Summary;
        d = Detail;
    }

    [MethodImpl(Inline)]
    public static implicit operator XedDisasmDoc((XedDisasmSummary s, XedDisasmDetail d) src)
        => new (src.s,src.d);
}
