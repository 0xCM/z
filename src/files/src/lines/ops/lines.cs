//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using System.IO;

    partial class Lines
    {
        //public static ReadOnlySpan<char> AsciFormat(ReadOnlySpan<)
        public static ReadOnlySpan<string> lines(MemoryFile src)
        {
            var symbols = recover<AsciSymbol>(src.Bytes);
            var content = span<char>(symbols.Length);
            var length = AsciSymbols.decode(src.Bytes, content);
            return lines(sys.@string(sys.slice(content,0,length)));
        
            //using var reader = new StreamReader(src.Stream, leaveOpen:false);
            //return lines(content);
        }

        [Op]
        public static ReadOnlySpan<string> lines(string src, bool keepblank = false, bool trim = true)
        {            
            var lines = list<string>();
            var lineNumber = 0u;
            using(var reader = new StringReader(src))
            {
                var next = reader.ReadLine();
                while(next != null)
                {
                    if(text.blank(next))
                    {
                        if(keepblank)
                        {
                            lines.Add(next);
                            ++lineNumber;
                        }
                    }
                    else
                    {
                        lines.Add(trim ? text.trim(next) : next);
                        ++lineNumber;
                    }

                    next = reader.ReadLine();
                }
            }
            return lines.ViewDeposited();
        }
    }
}