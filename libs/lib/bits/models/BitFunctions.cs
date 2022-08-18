//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct BitFunctions
    {
        [MethodImpl(Inline), Op]
        public static ByteSize size(in BitFunctionDim src)
        {
            var width = (uint)(src.TotalInputWidth + src.TotalOutputWidth);
            return width/8 + (width % 8 == 0 ? 0 : 1);
        }

        [MethodImpl(Inline), Op]
        public static BitFunctionDim dim(uint cIn, uint wIn, uint cOut, uint wOut)
            => new BitFunctionDim(cIn, wIn, cOut, wOut);
    }
}