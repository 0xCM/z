//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

public class XedRuntime : WfSvc<XedRuntime>
{
    bool Started = false;

    readonly object StartLocker = new();

    public ref readonly Alloc Alloc => ref _Alloc;

    public XedDb XedDb => Wf.XedDb();

    public XedRules Rules => Wf.XedRules();


    readonly Alloc _Alloc;

    public XedRuntime()
    {
        _Alloc = Z0.Alloc.create();
        Disposing += HandleDispose;
    }

    void HandleDispose()
    {
        _Alloc?.Dispose();
    }


}
