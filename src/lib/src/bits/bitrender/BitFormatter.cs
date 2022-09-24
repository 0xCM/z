//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public class BitFormatter
    {
        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public static BitFormatter<T> formatter<T>(BitFormat config)
            where T : unmanaged
                => new BitFormatter<T>(config);

        // [MethodImpl(Inline), Op]
        // public static FixedBitFormatter @fixed()
        //     => FixedBitFormatter.Service;

        // [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        // public static FixedBitFormatter<T> @fixed<T>(uint width)
        //     where T : struct
        //         => new FixedBitFormatter<T>(width);

        [MethodImpl(Inline), Op]
        public static BitFormat configure(bool tlz)
            => define(tlz:tlz, specifier:false, blockWidth:null, blocksep:null, rowWidth:null, maxbits:null,zpad:null);

        [MethodImpl(Inline), Op]
        public static BitFormat configure()
            => define(tlz:false, specifier:false, blockWidth:null, blocksep:null, rowWidth:null, maxbits:null,zpad:null);

        [MethodImpl(Inline), Op]
        public static BitFormat limited(uint maxbits, int? zpad = null)
            => define(tlz:true, maxbits: maxbits, zpad:zpad);

        [MethodImpl(Inline), Op]
        public static BitFormat limited(uint maxbits, int zpad, bool specifier = false)
            => define(tlz:true, maxbits: maxbits, zpad:zpad, specifier:specifier);

        [MethodImpl(Inline), Op]
        public static BitFormat blocked(int width, char? sep = null, uint? maxbits = null, bool specifier = false)
            => define(tlz:false, blockWidth: width, blocksep: sep, maxbits:maxbits, specifier: specifier);

        [MethodImpl(Inline), Op]
        public static BitFormat define(bool tlz, bool specifier = false, int? blockWidth = null, char? blocksep = null, int? rowWidth = null, uint? maxbits = null, int? zpad = null)
            => new BitFormat(tlz, specifier, blockWidth, blocksep, rowWidth, maxbits, zpad);

        [MethodImpl(Inline), Op]
        public static BitFormat bitrows(int blockWidth, int rowWidth, char? blockSep = null)
            => define(tlz:false, blockWidth: blockWidth, rowWidth:rowWidth, blocksep: blockSep);
    }
}