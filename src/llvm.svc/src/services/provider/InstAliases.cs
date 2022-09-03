//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    partial class LlvmDataProvider
    {
        public Index<LlvmInstAlias> InstAliases()
        {
            return (Index<LlvmInstAlias>)DataSets.GetOrAdd(nameof(InstAliases),_ => Load());

            Index<LlvmInstAlias> Load()
            {
                var entities = Entities();
                var count = entities.Length;
                var buffer = list<LlvmInstAlias>();
                for(var i=0; i<count; i++)
                {
                    ref readonly var entity = ref entities[i];
                    if(entity.IsInstAlias())
                    {
                        var alias = entity.ToInstAlias();
                        var str = alias.AsmString;
                        var dst = new LlvmInstAlias();
                        dst.InstName = str.InstName;
                        dst.Mnemonic = str.Mnemonic;
                        dst.AsmString = str.FormatPattern;
                        dst.Syntax = alias.ResultInst;
                        buffer.Add(dst);
                    }
                }

                return buffer.ToArray().Sort();
            }
        }
    }
}