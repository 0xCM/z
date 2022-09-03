//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Text;

    using C = AsciCode;

    [ApiHost]
    public class AsciCodes
    {
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<C> whitespace()
            => Whitespace;

        static ReadOnlySpan<C> Whitespace
            => new C[]{C.CR, C.FF, C.NL, C.Space, C.Tab, C.VTab};
    }
}