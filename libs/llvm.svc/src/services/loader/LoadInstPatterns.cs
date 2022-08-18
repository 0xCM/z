//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    partial class LlvmTableLoader
    {
        public Index<LlvmAsmInstPattern> LoadInstPatterns()
        {
            const byte FieldCount = LlvmAsmInstPattern.FieldCount;
            var src = LlvmPaths.DbTable<LlvmAsmInstPattern>();
            var buffer = list<LlvmAsmInstPattern>();
            using var reader = src.Utf8LineReader();
            reader.Next(out var header);
            var cols = header.Split(Chars.Pipe);
            if(cols.Length != FieldCount)
            {
                Error(Tables.FieldCountMismatch.Format(cols.Length, FieldCount));
                return sys.empty<LlvmAsmInstPattern>();
            }

            while(reader.Next(out var line))
            {
                var row = new LlvmAsmInstPattern();
                cols = line.Split(Chars.Pipe);
                if(cols.Length != FieldCount)
                {
                    Error(Tables.FieldCountMismatch.Format(cols.Length, FieldCount));
                    return sys.empty<LlvmAsmInstPattern>();
                }

                var i=0;
                DataParser.parse(skip(cols,i++), out row.AsmId);
                row.InstName = skip(cols,i++);
                row.Mnemonic = skip(cols,i++);
                row.FormatPattern = skip(cols,i++);
                row.SourceData = skip(cols,i++);
                buffer.Add(row);
            }
            return buffer.ToArray();
        }
    }
}