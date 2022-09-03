//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    public class LlvmTests
    {
        //const string CodeProp = CharText.Quote + nameof(LlvmTestLogEntry.code) + CharText.Quote;
        const string CodeProp = "code\": ";

        const byte CodePropLength = 7;

        const string ElapsedProp = "elapsed\": ";

        const byte ElapsedPropLength = 10;

        const string NameProp = "name\": ";

        const byte NamePropLength = 7;

        const string OutputProp = "output\": ";

        const byte OutputPropLength = 9;

        public static bool parse(string src, ref TestResult dst)
        {
            var i = text.index(src, CodeProp);
            var result = false;
            if(i > 0)
            {
                dst.code = text.remove(text.right(src, i + CodePropLength - 1), Chars.Comma, Chars.Quote);
                return result;
            }

            i = text.index(src, ElapsedProp);
            if(i > 0)
            {
                dst.elapsed = text.remove(text.right(src, i + ElapsedPropLength - 1), Chars.Comma);
                return result;
            }

            i = text.index(src, NameProp);
            if(i > 0)
            {
                dst.name = text.remove(text.right(src, i + NamePropLength - 1), Chars.Comma, Chars.Quote);
                return result;
            }

            i = text.index(src, OutputProp);
            if(i > 0)
            {
                dst.output = text.right(src, i + OutputPropLength - 1);
                result = true;
            }
            return result;
        }

        public static Index<TestResult> logs(FilePath src)
        {
            using var reader = src.Utf8LineReader();
            var entries = list<TestResult>();
            var entry = new TestResult();
            while(reader.Next(out var line))
            {
                var result = parse(line.Content, ref entry);
                if(result)
                {
                    entries.Add(entry);
                    entry = new TestResult();
                }
            }
            return entries.ToIndex();
        }
    }
}