//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost]
    public class Tools
    {
        [MethodImpl(Inline), Op]
        public static ToolFlagSpec flag(string name, string desc)
            => new ToolFlagSpec(name, desc);

        public static ReadOnlySeq<ToolFlagSpec> flags(FilePath src)
        {
            var k = z16;
            var dst = list<ToolFlagSpec>();
            using var reader = src.AsciLineReader();
            while(reader.Next(out var line))
            {
                var content = line.Codes;
                var i = SQ.index(content, AsciCode.Colon);
                if(i == NotFound)
                    i = SQ.index(content, AsciCode.Eq);
                if(i == NotFound)
                    i = SQ.index(content, AsciCode.FS);
                
                if(i == NotFound)
                    continue;


                var name = text.trim(Asci.format(SQ.left(content,i)));
                var desc = text.trim(Asci.format(SQ.right(content,i)));
                dst.Add(flag(name, desc));
            }
            return dst.ToArray();
        }
    }
}