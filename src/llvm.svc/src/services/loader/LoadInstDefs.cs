//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using Asm;

    using static core;

    partial class LlvmTableLoader
    {
        public Index<LlvmInstDef> LoadInstDefs()
        {
            const byte FieldCount = LlvmInstDef.FieldCount;
            const char Delimiter = Chars.Pipe;
            var src = LlvmPaths.DbTable<LlvmInstDef>();
            var lines = src.ReadLines();
            var records = Index<LlvmInstDef>.Empty;
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
            records = alloc<LlvmInstDef>(count);
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
                DataParser.parse(skip(values,j++), out dst.AsmId);
                DataParser.parse(skip(values,j++), out dst.CgOnly);
                DataParser.parse(skip(values,j++), out dst.Pseudo);
                DataParser.parse(skip(values,j++), out dst.InstName);
                dst.Mnemonic = skip(values,j++);
                dst.VarCode = new AsmVariationCode(skip(values,j++));
                DataParser.parse(skip(values,j++), out dst.FormatPattern);
                dag.parse(skip(values,j++), out dst.InOperandList);
                dag.parse(skip(values,j++), out dst.OutOperandList);
            }
            return records;
        }
    }
}