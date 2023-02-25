//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using M = System.Diagnostics.ProcessModule;
    using T = System.Diagnostics.ProcessThread;
    using P = System.Diagnostics.Process;

    public static partial class XTend
    {
        public static ProcessAdapter Adapt(this P src)
            => src;

        public static ProcessThreadAdapter Adapt(this T src)
            => src;

        public static ProcessModule Adapt(this M src)
            => src;
    }
}