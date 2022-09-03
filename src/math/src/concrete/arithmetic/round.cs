//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class math
    {
        [MethodImpl(Inline), Round]
        public static float round(float src, int scale)
            => MathF.Round(src, scale);

        [MethodImpl(Inline), Round]
        public static double round(double src, int scale)
            => Math.Round(src, scale);
    }
}