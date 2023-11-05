//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

partial struct Bitfields
{
    public static Dictionary<F,uint> indices<F>()
        where F : unmanaged,Enum
    {
        var symbols = Symbols.index<F>();
        var kinds = symbols.Kinds.ToArray().Index();
        var count = symbols.Count;
        var indices = dict<F,uint>();
        for(var i=0u; i<count; i++)
            indices[kinds[i]] = i;
        return indices;
    }
}