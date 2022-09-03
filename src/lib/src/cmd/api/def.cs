//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
 
    partial class Cmd
    {
        public static AppCmdDef def(object host, MethodInfo method)
        {
            var attrib = method.Tag<CmdOpAttribute>().Require();
            return new AppCmdDef(attrib.Name, classify(method), method, host);
        }
    }
}