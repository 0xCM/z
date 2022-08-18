//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;

    partial class Settings
    {
        public static EnvVars<string> env(FS.FilePath src, char sep = Chars.Eq)
        {
            var k = z16;
            var dst = list<EnvVar<string>>();
            var line = AsciLineCover.Empty;
            var buffer = sys.alloc<char>(1024*4);
            using var reader = src.AsciLineReader();
            while(reader.Next(out line))
            {
                var content = line.Codes;
                var i = SQ.index(content, sep);
                if(i == NotFound)
                    continue;

                var _name = Asci.format(SQ.left(content,i), buffer);
                var _value = Asci.format(SQ.right(content,i), buffer);
                dst.Add(new (_name, _value));
            }
            return dst.ToArray().Sort();
        }
    }
}