//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    partial class LlvmTableLoader
    {
        readonly struct NameParser : IParser<string>
        {
            public Outcome Parse(string src, out string dst)
            {
                dst = text.ifempty(src,EmptyString);
                return true;
            }
        }

        static bool parse(string src, out LineInterval<string> dst)
            => Lines.parse(src, new NameParser(), out dst);

        public LineMap<string> LoadLineMap(FS.FilePath src)
        {
            using var reader = src.Utf8LineReader();
            var lines = reader.ReadAll();
            var interval = LineInterval<string>.Empty;
            var count = lines.Length;
            var intervals = alloc<LineInterval<string>>(count);
            var result = Outcome.Success;
            for(var i=0u; i<count; i++)
            {
                ref var dst = ref seek(intervals, i);
                result = parse(skip(lines,i).Content,  out seek(intervals,i));
                if(result.Fail)
                {
                    Wf.Error(result.Message);
                    break;
                }
            }

            if(result)
                return new LineMap<string>(intervals);
            else
                return new LineMap<string>(sys.empty<LineInterval<string>>());
        }
    }
}