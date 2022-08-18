//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Digital
    {
        const char Zero = (char)0;

        [MethodImpl(Inline), Op]
        public static bool nonzero(char c0, char c1)
            => c0 != Zero && c1 != Zero;
   }
}