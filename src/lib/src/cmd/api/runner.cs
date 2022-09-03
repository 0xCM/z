//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class Cmd
    {
        [Op]
        public static AppCmdRunner runner(string name, object host, MethodInfo method)
            => new AppCmdRunner(name, host, method);
    }
}