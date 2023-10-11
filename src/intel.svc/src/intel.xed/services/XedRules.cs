//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

[ApiHost]
public partial class XedRules : WfSvc<XedRules>
{
    const string xed = "xed";

    const NumericKind Closure = UnsignedInts;

    XedRuntime XedRuntime => Wf.XedRuntime();

    [MethodImpl(Inline)]
    StringRef String(string src)
        => XedRuntime.Alloc.String(src);

    public XedRules()
    {
    }
}
