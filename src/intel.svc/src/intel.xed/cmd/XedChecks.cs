//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public partial class XedChecks : CheckCmd<XedChecks>
    {
        XedPaths XedPaths => Wf.XedPaths();

        XedRuntime XedRuntime => Wf.XedRuntime();
   }
}