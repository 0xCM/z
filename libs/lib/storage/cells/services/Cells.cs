//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Root;
    using static core;

    [Free, ApiHost]
    public partial class Cells
    {
        const NumericKind Closure = UnsignedInts;
    }

    partial class XTend
    {
        [Op]
        public static string FormatHexData(this Cell128 src, byte? count = null)
        {
            var c = count ?? 16;
            if(c <= 16)
            {
                return HexFormatter.format(slice(bytes(src), 0, c), HexOptionData.HexDataOptions);
            }
            return "!!FormatError!!";
        }
    }
}