//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    partial class LlvmTableLoader
    {
        public LlvmList LoadList(string id)
            => LoadList(LlvmPaths.ListTargetPath(id));

        LlvmList LoadList(FS.FilePath src)
        {
            var dst = list<LlvmListItem>();
            using var reader = src.Utf8LineReader();
            var counter = 0u;
            while(reader.Next(out var line))
            {
                if(counter++ == 0)
                    continue;
                else
                {
                    var parts = line.Content.SplitClean(Chars.Pipe);
                    if(parts.Length != 2)
                    {
                        Error(Tables.FieldCountMismatch.Format(parts.Length, 2));
                        break;
                    }
                    DataParser.parse(skip(parts,0), out uint key);
                    dst.Add((key, text.trim(skip(parts,1))));
                }
            }
            return (src, dst.ToArray());
        }
    }
}