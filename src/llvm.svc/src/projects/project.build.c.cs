//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ProjectCmd
    {
        [CmdOp("project/build/c")]
        void BuildC()
            => Scripts.BuildC(Project());

        [CmdOp("project/build/cpp")]
        void BuildCpp()
            => Scripts.BuildCpp(Project());

        [CmdOp("project/build+run/cpp")]
        void BuildRunCpp()
            => Scripts.BuildCpp(Project(), true);

        [CmdOp("project/build+run/c")]
        void BuildRunC()
            => Scripts.BuildC(Project(), true);
    }
}