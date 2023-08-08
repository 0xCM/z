//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static XedRules;
    using static XedFields;

    partial class XedCmd
    {
        public void Etl(IProject project)
        {
            var context = ApiCmd.context(project);
            XedRuntime.Disasm.Collect(context);
        }
                
   }
}