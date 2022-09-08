//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    
    partial struct grids
    {
        [Parser]
        public static Outcome parse(string s, out GridDim dst)
        {
            dst = GridDim.Empty;

            var n = 0u;
            var parts = @readonly(s.Split('x'));
            if(parts.Length == 2)
            {
                if(DataParser.parse(skip(parts,0), out uint m) && DataParser.parse(skip(parts,1), out n))
                {
                    dst = new GridDim(m, n);
                    return true;
                }
            }
            return false;
        }
    }
}