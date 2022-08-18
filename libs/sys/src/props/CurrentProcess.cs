//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class sys
    {
        public static Process CurrentProcess
        {
            [MethodImpl(Options), Op]
            get => Process.GetCurrentProcess();
        }
    }
}