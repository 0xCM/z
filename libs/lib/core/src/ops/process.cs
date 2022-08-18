//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct core
    {
        [MethodImpl(Inline), Op]
        public static Process process()
            => Process.GetCurrentProcess();

        [MethodImpl(Inline), Op]
        public static Process process(int id)
            => Process.GetProcessById(id);
    }
}