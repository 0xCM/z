//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public partial class BinaryCalcs
    {
        [MethodImpl(Inline)]
        public static BitWidth align(BitWidth width, BitWidth segment)
        {
            if(width <= segment)
                return segment;
                        
            var mod = width % segment;
            if(mod == 0)            
                return width;
            
            return width + (segment - mod);
        }
    }
}