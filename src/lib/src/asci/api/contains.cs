//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct Asci
    {
        [MethodImpl(Inline)]
        public static bool contains<T>(in T src, AsciCharSym match)
            where T : unmanaged,IAsciSeq
        {
            var code = (byte)match;
            var count = src.Length;
            var data = sys.bytes(src);
            for(var i=0; i<count; i++)
                if(skip(data,i) == code)
                    return true;
            return false;
        }

        [MethodImpl(Inline)]
        public static int index<T>(in T src, AsciCharSym match)
            where T : unmanaged, IAsciSeq
        {
            var code = (byte)match;
            var count = src.Length;
            var data = sys.bytes(src);
            for(var i=0; i<count; i++)
                if(skip(data,i) == code)
                    return i;

            return NotFound;
        }
    }
}