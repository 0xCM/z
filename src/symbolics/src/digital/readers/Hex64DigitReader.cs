//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static GBlocks;

    using D = HexDigit;
    using C = AsciCode;

    struct Hex64DigitReader : IBlockReader<GBlock64<D>, char>, IBlockReader<GBlock64<D>,C>
    {
        uint Count;

        GBlock64<D> Storage;

        public uint Counter
        {
            get => Count;
        }

        public Hex64DigitReader()
        {
            Count = 0;
            Storage = default;
        }

        public GBlock64<D> Read(ReadOnlySpan<char> src)
        {
            var count = src.Length;
            var j = 0u;
            var dst = sys.recover<D>(sys.bytes(Storage));
            for(var i=0; i<count; i++)
            {
                ref readonly var c = ref skip(src,i);
                if(Digital.test(base16, c))
                    seek(dst,j++) = Digital.digit(base16,c);
            }
            Count = j;    
            return Storage;
        }

        public GBlock64<D> Read(ReadOnlySpan<C> src)
        {
            var count = src.Length;
            var j = 0u;
            var dst = sys.recover<D>(sys.bytes(Storage));
            for(var i=0; i<count; i++)
            {
                ref readonly var c = ref skip(src,i);
                if(Digital.test(base16, c))
                    seek(dst,j++) = Digital.digit(base16,c);
                else
                    break;
            }
            Count = j;
            return Storage;            
        }

        public static Hex64DigitReader Service => new();
    }
}