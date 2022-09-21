//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    using static sys;

    partial class LlvmDataCalcs
    {
        public LlvmList CalcList(Index<LlvmEntity> src, string @class)
        {
            var count = src.Length;
            var items = list<LlvmListItem>();
            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var entity = ref src[i];
                ref readonly var def = ref entity.Def;
                var ancestors = def.AncestorNames;
                if(ancestors.Contains(@class))
                    items.Add(new LlvmListItem(counter++, entity.EntityName));
            }

            return (@class,items.ToArray());
        }
    }
}