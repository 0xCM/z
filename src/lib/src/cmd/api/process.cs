//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Cmd
    {
        [Op]
        public static ProcessAdapter process(ProcessStartSpec spec)
            => Process.Start(spec);
    }
}