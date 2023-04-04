//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Windows;

    using static sys;
    using static WinImage;

    class Win64Cmd : WfAppCmd<Win64Cmd>
    {

        [CmdOp("win64/procs")]
        void ProcAddress(CmdArgs args)
        {
            INativeImage kernel32 = WinImage.Kernel32.load();
            var address = kernel32.GetProcAddress("GetProcAddress");
            Channel.Row((MemoryAddress)address);
        }

        [CmdOp("win64/sys")]
        void SysImages(CmdArgs args)
        {
            var li = LinkInfo.load();
            Channel.Row(li.Format());
        }
    }

}