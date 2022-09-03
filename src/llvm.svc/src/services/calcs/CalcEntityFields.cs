//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    partial class LlvmDataCalcs
    {
        public Index<EntityFieldSet> CalcEntityFields(ReadOnlySpan<RecordField> src)
        {
            var count = src.Length;
            var dst = list<EntityFieldSet>();
            var subset = list<RecordField>();
            var current = Identifier.Empty;
            for(var i=0; i<count; i++)
            {
                ref readonly var f = ref skip(src,i);
                ref readonly var id = ref f.RecordName;
                if(id != current)
                {
                    if(subset.Count != 0)
                    {
                        dst.Add(new EntityFieldSet(current, subset.ToArray()));
                        subset.Clear();
                        current = id;
                    }
                }
                subset.Add(f);
            }

            if(subset.Count != 0)
                dst.Add(new EntityFieldSet(current, subset.ToArray()));
            return dst.ToArray();
        }
    }
}