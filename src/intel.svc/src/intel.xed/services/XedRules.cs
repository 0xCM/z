//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using Asm;

using static sys;
using static XedModels;

[ApiHost]
public partial class XedRules : WfSvc<XedRules>
{
    const string xed = "xed";

    const NumericKind Closure = UnsignedInts;

    XedRuntime XedRuntime => Wf.XedRuntime();

    XedPaths XedPaths => XedRuntime.Paths;

    [MethodImpl(Inline)]
    StringRef String(string src)
        => XedRuntime.Alloc.String(src);

    public XedRules()
    {
    }
}
