//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static HexFormatSpecs;
using static sys;

partial struct Hex
{
    [MethodImpl(Inline), Op]
    public static uint prespec(ref uint i, Span<char> dst)
    {
        seek(dst,i++) = PreSpec0;
        seek(dst,i++) = PreSpec1;
        return 2;
    }
}
