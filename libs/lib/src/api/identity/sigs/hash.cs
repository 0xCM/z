//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct ApiSigs
    {
        [Op]
        public static uint hash(in ApiSig src)
        {
            var result = Hash32.Zero;
            for(var i=0; i<src.Components.Count; i++)
            {
                ref readonly var part = ref src.Components[i];
                var hc = Algs.hash(part.Name);
                if(i == 0)
                    result = hc;
                else
                    result |= hc;
            }

            return alg.hash.combine(result, (uint)src.Class);
        }
    }
}