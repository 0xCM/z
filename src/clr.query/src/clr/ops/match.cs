//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Clr
    {
        [Op]
        public static bool match(Index<Type> src, EcmaToken id, out Type matched)
        {
            for(var i=0; i<src.Length; i++)
            {
                var candidate = src[i];
                if(candidate.MetadataToken == id)
                {
                    matched = candidate;
                    return true;
                }

            }
            matched = default;
            return false;
        }
    }
}