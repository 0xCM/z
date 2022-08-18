//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class sys
    {
        /// <summary>
        /// The handle for the current process
        /// </summary>
        public static IntPtr CurrentProcessHandle
        {
            [MethodImpl(Options), Op]
            get => Process.GetCurrentProcess().Handle;
        }
    }
}