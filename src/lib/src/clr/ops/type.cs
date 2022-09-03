//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct Clr
    {
        [MethodImpl(Inline), Op]
        public static Type type(Module src, CliToken token)
            => src.ResolveType((int)token);

        [MethodImpl(Inline), Op]
        public static bool type(in ClrTypeLookup src, string name, out Type dst)
        {
            dst = default;
            for(var i=0u; i<src.Count; i++)
            {
                ref readonly var x = ref skip(src.Pairs,i);
                if(x.Value.Name == name)
                {
                    dst = x.Value;
                    return true;
                }
            }
            return false;
        }
    }
}