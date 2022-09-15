//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ICmdRunner
    {
        void RunCmd(string name);

        void RunCmd(string name, CmdArgs args);
    }
}