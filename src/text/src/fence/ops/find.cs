//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class Fenced
    {
        [Op]
        public static bool find(string src, Fence<char> fence, out Pair<int> location)
        {
            location = Tuples.pair((int)NotFound,(int)NotFound);
            if(nonempty(src))
            {
                var chars = span(src);
                var count = chars.Length;
                for(var i=0; i<count; i++)
                {
                    ref readonly var c = ref skip(chars,i);
                    if(location.Left == NotFound)
                    {
                        if(c == fence.Left)
                            location.Left = i;
                    }

                    else if(location.Left != NotFound && location.Right == NotFound)
                    {
                        if(c == fence.Right)
                        {
                            location.Right = i;
                            break;
                        }
                    }

                }
            }

            return location.Left != NotFound && location.Right != NotFound;
        }
    }
}