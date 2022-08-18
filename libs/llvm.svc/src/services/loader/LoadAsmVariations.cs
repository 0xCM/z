//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using Asm;

    using static core;

    partial class LlvmTableLoader
    {
        public Index<LlvmAsmVariation> LoadAsmVariations()
        {
            const char Delimiter = Chars.Pipe;
            const byte FieldCount = LlvmAsmVariation.FieldCount;
            var src = LlvmPaths.DbTable<LlvmAsmVariation>();
            var lines = src.ReadLines();
            var records = Index<LlvmAsmVariation>.Empty;
            if(lines.Length < 1)
            {
                Error(string.Format("Empty file"));
                return records;
            }

            ref readonly var header = ref lines[0];
            var columns = header.SplitClean(Delimiter);
            if(columns.Length != FieldCount)
            {
                Error(Tables.FieldCountMismatch.Format(columns.Length, FieldCount));
                return records;
            }

            var count = lines.Length - 1;
            records = alloc<LlvmAsmVariation>(count);
            for(var i=1;i<count; i++)
            {
                ref readonly var line = ref lines[i];
                var values = @readonly(line.SplitClean(Delimiter));
                if(values.Length != FieldCount)
                {
                    Error(Tables.FieldCountMismatch.Format(values.Length, FieldCount));
                    break;
                }

                if(text.empty(skip(values,1).Trim()))
                    continue;

                var j=0;
                ref var dst = ref records[i-1];
                DataParser.parse(skip(values,j++), out dst.Seq);
                dst.Name = skip(values,j++);
                dst.Mnemonic = skip(values,j++);
                dst.Code = new AsmVariationCode(text.trim(skip(values,j++)));
            }
            return records;
        }
    }
}