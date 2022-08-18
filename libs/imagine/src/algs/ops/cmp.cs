//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Algs
    {
        [Op]
        public static int cmp(ReadOnlySpan<byte> a, ReadOnlySpan<byte> b)
        {
            var result = 0;
            var kLeft = a.Length;
            var kRight = b.Length;

            if(kLeft == kRight)
            {
                var count = kLeft;
                for(var i=0; i<count; i++)
                {
                    ref readonly var x = ref Spans.skip(a,i);
                    ref readonly var y = ref Spans.skip(b,i);
                    result = x.CompareTo(y);
                    if(result != 0)
                        break;
                }
            }
            else
                result = kLeft.CompareTo(kRight);

            return result;
        }
    }
}