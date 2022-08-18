//-----------------------------------------------------------------------------
// Copyright   :  (c) Microsoft/.NET Foundation
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class SRM
    {
        public static class StringUtils
        {
            [MethodImpl(Inline), Op]
            public static int IgnoreCaseMask(bool ignoreCase)
                => ignoreCase ? 0x20 : 0xff;

            [MethodImpl(Inline), Op]
            public static bool IsEqualAscii(int a, int b, int ignoreCaseMask)
            {
                // When not ignoring case (most often):
                // - only the first condition is evaluated multiple times during the loop.
                // - the remaining condition is false since ignoreCaseMask is 0xff.
                // When ignoring case
                // - the most likely case is still a == b
                // - ignoreCaseMask is 0x20
                return a == b || ((a | 0x20) == (b | 0x20) && unchecked((uint)((a | ignoreCaseMask) - 'a')) <= 'z' - 'a');
            }
        }
    }
}