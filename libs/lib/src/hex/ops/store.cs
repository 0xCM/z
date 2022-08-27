//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct Hex
    {
        [MethodImpl(Inline), Op]
        public static ref HexArray16 store(ReadOnlySpan<byte> src, ref HexArray16 dst)
        {
            ref var target = ref @as<HexArray16,byte>(dst);
            var count = min(src.Length, 16);
            for(var i=0; i<count; i++)
                seek(target,i) = skip(src,i);
            return ref dst;
        }
    }
}