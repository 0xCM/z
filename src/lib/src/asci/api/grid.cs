//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct Asci
    {
        [Op,Closures(UInt8k)]
        public static AsciGrid<T> grid<T>(Symbols<T> src, uint width)
            where T : unmanaged
        {
            var count = src.Count;
            var size = count*width;
            var dst = alloc<byte>(size);
            var offset = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var symbol = ref src[i];
                offset += encode(w8, n5, symbol.Expr, symbol.Kind, offset, dst);
            }
            return new AsciGrid<T>(seq(dst), width);
        }
    }
}