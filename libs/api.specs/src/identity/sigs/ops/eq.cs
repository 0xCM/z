//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct ApiSigs
    {
        [Op]
        public static bool eq(in ApiSig a, in ApiSig b)
        {
            var count = a.Components.Length;
            if(count != b.Components.Length)
                return false;

            if(a.Class != b.Class)
                return false;

            var left = a.Components.View;
            var right = b.Components.View;
            for(var i=0; i<count; i++)
            {
                ref readonly var x = ref skip(left,i);
                ref readonly var y = ref skip(right,i);
                if(!x.Equals(y))
                    return false;
            }
            return true;
        }
    }
}