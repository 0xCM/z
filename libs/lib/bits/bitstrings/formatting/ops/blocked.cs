//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    partial class FormatBits
    {
        public static string blocked<T>(T src, BitFormat config)
            where T : unmanaged
                => blocked(src, config.BlockWidth, config.MaxBitCount, config.SpecifierPrefix, config.BlockSep);

        static string blocked<T>(T src, int? blocksize = null, uint? maxbits = null, bool specifier = false, char sep = Chars.Underscore)
            where T : unmanaged
                => text.bracket(BitStrings.scalar(src,(int?)maxbits).Format(false, specifier, blocksize ?? 8, sep , null));
    }
}