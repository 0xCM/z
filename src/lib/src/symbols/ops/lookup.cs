//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct Symbols
    {
        public static ConstLookup<Name,ReadOnlySeq<SymInfo>> lookup(params Type[] src)
        {
            var types = src.Tagged<SymSourceAttribute>();
            var groups = dict<Name,List<Type>>();
            var individuals = list<Type>();
            foreach(var type in types)
            {
                var tag = type.Tag<SymSourceAttribute>().Require();
                var name = tag.SymGroup;
                if(nonempty(name))
                {
                    if(groups.TryGetValue(name, out var list))
                        list.Add(type);
                    else
                    {
                        list = new();
                        list.Add(type);
                        groups[name] = list;
                    }
                }
                else
                    individuals.Add(type);
            }

            var dst = dict<Name,ReadOnlySeq<SymInfo>>();
            foreach(var g in groups.Keys)
                dst[g] = Symbols.syminfo(groups[g].ViewDeposited());

            foreach(var i in individuals)
                dst[i.Name] = Symbols.syminfo(i);

            return dst;
        }
    }
}