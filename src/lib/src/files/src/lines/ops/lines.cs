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
        [MethodImpl(Inline), Op]
        public static uint lines(string src, Span<string> dst, bool keepblank = false, bool trim = true)
        {
            var k=0u;
            var capacity = (uint)dst.Length;
            using(var reader = new StringReader(src))
            {
                var next = reader.ReadLine();
                while(next != null && k<capacity)
                {
                    if(text.blank(next))
                        if(keepblank)
                            seek(dst,k++) = next;
                    else
                        seek(dst, k++) = trim ? text.trim(next) : next;
                    next = reader.ReadLine();
                }
            }
            return k;
        }

        public static ReadOnlySpan<string> lines(MemoryFile src)
        {
            using var reader = new StreamReader(src.Stream, leaveOpen:true);
            return lines(reader.ReadToEnd());
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