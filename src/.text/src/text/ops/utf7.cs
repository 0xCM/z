//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class text
    {
        [MethodImpl(Inline), Op]
        public static string utf7(ReadOnlySpan<byte> src)
            => Encoding.UTF7.GetString(src);
    }
}