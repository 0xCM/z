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
        public static bool bitstring<S>(S src)
            where S : unmanaged, IAsciSeq<S>
        {
            var result = true;
            var counter = 0;
            var data = src.View;
            var n = data.Length;
            for(var i=0; i<n; i++)
            {
                var b = (AsciCode)skip(data,i);
                result = (b == AsciCode.Space || b == AsciCode.d0 || b == AsciCode.d1);
                if(!result)
                    break;
            }

            return result;
        }
    }
}