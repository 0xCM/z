//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class StringMatcher
    {
        public class CharPositions : ConstLookup<CharIndex,List<uint>>
        {
            internal CharPositions(Dictionary<CharIndex,List<uint>> src)
                : base(src)
            {

            }
        }
    }
}