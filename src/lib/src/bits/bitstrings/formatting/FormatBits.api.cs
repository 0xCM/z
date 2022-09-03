//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public static partial class FormatBits
    {
        static string format(BitString src, BitFormat config)
            => src.Format(config.TrimLeadingZeros, config.SpecifierPrefix, config.BlockWidth, config.BlockSep, config.RowWidth);
    }
}